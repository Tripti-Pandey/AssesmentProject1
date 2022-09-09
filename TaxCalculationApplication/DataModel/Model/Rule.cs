using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TaxCalculationApplication.DataModel.Model
{
    public class Rule
    {
        [Key]
        public Guid RuleId { get; set; }
        [Required, StringLength(10), Display(Name = "Tax rule")]
        public string Name { get; set; }
    }
}
