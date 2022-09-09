using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaxCalculationApplication.DataModel.DTOs;
using TaxCalculationApplication.Repositories;

namespace TaxCalculationApplication.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("api/TaxCalculation")]
    public class TaxCalculationController : ControllerBase
    {
        private readonly ITaxCalculationRepository _taxCalculationRepo;
        private readonly ILogger<TaxCalculationController> _logger;



        public TaxCalculationController(ITaxCalculationRepository taxCalculationRepository , ILogger<TaxCalculationController> logger)

        {
            _taxCalculationRepo = taxCalculationRepository;
            _logger = logger;
        }
        [HttpGet, Route("GetTax/{MunicipalId}/{Date}")]
        public async Task<List<TaxScheduledDTO>> GetData([FromRoute] Guid MunicipalId, [FromRoute] DateTime Date)
        {
            try
            {
                _logger.LogInformation(string.Format("Calling Method at {0}", DateTime.UtcNow.ToLongTimeString()));
                return await _taxCalculationRepo.GetScheduledTax(MunicipalId, Date);
            }
            catch (Exception ex)
            {
                _logger.LogError(string.Format("Message: {0}, Inner Exception: {1}, Stack Trace: {2}", ex.Message, ex.InnerException, ex.StackTrace));
                throw;
            }
        }


    }

}
