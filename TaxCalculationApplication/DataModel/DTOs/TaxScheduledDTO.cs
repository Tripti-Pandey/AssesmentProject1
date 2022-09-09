using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaxCalculationApplication.DataModel.DTOs
{
    public class TaxScheduledDTO
    {
        public string Muncipality { get; set; }
        public DateTime Date { get; set; }
        public String TaxRule { get; set; }
        public decimal TaxRate { get; set; }
    }
}
