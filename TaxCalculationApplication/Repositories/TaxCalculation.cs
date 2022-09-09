using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaxCalculationApplication.Constants;
using TaxCalculationApplication.DataModel;
using TaxCalculationApplication.DataModel.Model;
using TaxCalculationApplication.DataModel.DTOs;

namespace TaxCalculationApplication.Repositories
{
    public class TaxCalculation : ITaxCalculationRepository
    {
        private readonly DatabaseContext _context;
        public TaxCalculation(DatabaseContext context)
        {
            this._context = context;
        }
        public async Task<List<TaxScheduledDTO>> GetScheduledTax(Guid MunicipalId, DateTime Date)
        {
            //Municipal Ids list
            var municipalRuleIds = _context.municipalRules
                                    .Where(x => x.MunicipalId == MunicipalId)
                                    .Select(x => x.MunicipalRulesId)
                                    .ToList();

            //Tax schedule list
            var taxListforMunicipal = _context.taxSchedule
                                        .Include(x => x.municipalRules.municipal)
                                        .Include(x => x.municipalRules.rule)
                                        .Where(t => municipalRuleIds.Contains(t.MunicipalRulesId))
                                        .ToList();

            List<TaxScheduledDTO> newList = new List<TaxScheduledDTO> { };

            //Get rule 1 result
            var rules = _context.rule.AsQueryable();
            var lr1 = taxListforMunicipal.Where(x => x.municipalRules.RuleId == rules.FirstOrDefault(x => x.Name == Constant.Rule1).RuleId).ToList();
            if (lr1.Count > 0)
            {
                var result = GetRule1Result(lr1, Date);
                if (result != null)
                    newList.Add(result);
            }

            var lr2 = taxListforMunicipal.Where(x => x.municipalRules.RuleId == rules.FirstOrDefault(x => x.Name == Constant.Rule2).RuleId).ToList();
            if (lr2.Count > 0)
            {
                //Get rule 2 result
                var result2 = GetRule2Result(lr2, Date);
                if (result2 != null)
                    newList.Add(result2);
            }

            return newList; 
        }


        private TaxScheduledDTO GetRule1Result(List<TaxSchedule> list, DateTime Date)
        {
            decimal totalTaxRate = 0;
            TaxScheduledDTO query = null;
            foreach (var item in list)
            {
                if (Date >= item.FromDate && Date <= item.ToDate)
                {
                    totalTaxRate += item.TaxRate;
                }
            }

            if (totalTaxRate > 0)
            {
                query = new TaxScheduledDTO
                {
                    Date = Date,
                    Muncipality = list.Select(x => x.municipalRules.municipal.Municipality).FirstOrDefault(),
                    TaxRate = totalTaxRate,
                    TaxRule = list.Select(x => x.municipalRules.rule.Name).FirstOrDefault()
                };
            }
            return query;
        }

        private TaxScheduledDTO GetRule2Result(List<TaxSchedule> list, DateTime Date)
        {
            TaxScheduledDTO query = null;

            //Specific date
            var obj = list.FirstOrDefault(x => x.FromDate == null && x.SpecificDates != null);
            if (obj != null)
            {
                foreach (var item in obj?.SpecificDates.Split(','))
                {
                    if (Date == Convert.ToDateTime(item))
                    {
                        query = new TaxScheduledDTO
                        {
                            TaxRate = obj.TaxRate,
                            Muncipality = list.Select(x => x.municipalRules.municipal.Municipality).FirstOrDefault(),
                            TaxRule = list.Select(x => x.municipalRules.rule.Name).FirstOrDefault(),
                            Date = Date
                        };
                    }
                }
            }

            if (query == null)
            {
                //smallest match
                var ll = list.Where(x => x.FromDate != null && x.FromDate <= Date && x.ToDate >= Date)
                      .OrderBy(x => x.ToDate.Value.Subtract(x.FromDate.Value).TotalDays).FirstOrDefault();
                if (ll != null)
                {
                    query = new TaxScheduledDTO
                    {
                        TaxRate = ll.TaxRate,
                        Muncipality = list.Select(x => x.municipalRules.municipal.Municipality).FirstOrDefault(),
                        TaxRule = list.Select(x => x.municipalRules.rule.Name).FirstOrDefault(),
                        Date = Date
                    };
                }
            }

            return query;
        }
    }
}
