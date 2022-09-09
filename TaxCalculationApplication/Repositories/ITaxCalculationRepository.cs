using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaxCalculationApplication.DataModel.DTOs;

namespace TaxCalculationApplication.Repositories
{
    public interface ITaxCalculationRepository
    {
        Task<List<TaxScheduledDTO>> GetScheduledTax(Guid MunicipalId, DateTime Date);
    }
}
