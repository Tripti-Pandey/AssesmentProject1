using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TaxCalculationApplication.DataModel.Model
{
    public class Municipal
    {
        [Key]
        public Guid MunicipalId { get; set; }
        [Required,StringLength(50)]
        public string Municipality { get; set; }
    }
}
