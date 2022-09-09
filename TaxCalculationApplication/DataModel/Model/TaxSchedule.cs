using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TaxCalculationApplication.DataModel.Model
{
    public class TaxSchedule
    {

        [Key]
        public Guid TaxScheduleId { get; set; }
        public Guid MunicipalRulesId { get; set; }
        public MunicipalRules municipalRules { get; set; }
        [Required, StringLength(50), Display(Name = "Tax Period")]
        public String TaxPeriodName { get; set; }
        public decimal TaxRate { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public string SpecificDates { get; set; }
    }
}