using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TaxCalculationApplication.DataModel.Model
{
    public class MunicipalRules
    {
        [Key]
        public Guid MunicipalRulesId { get; set; }
        public Guid RuleId { get; set; }
        public Rule rule { get; set; }
        public Guid MunicipalId { get; set; }
        public Municipal municipal { get; set; }
    }
}
