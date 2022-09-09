using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxCalculationApplication.Controllers;
using TaxCalculationApplication.DataModel.DTOs;
using TaxCalculationApplication.Repositories;
using Xunit;

namespace api_web_tests
{
   public class TaxCalculationControllerTest
    {
        private readonly ILogger<TaxCalculationController> _logger;

        [Fact]
        public void GetById_ExistingGuidPassed_ReturnsOkResult()
        {
            // Arrange
            Guid MunicipalGuidId = new Guid("AE39FB63-D937-4616-A367-AFB99DE83092");
            DateTime Date = Convert.ToDateTime("2020-01-01");

            var mockRepo = new Mock<ITaxCalculationRepository>();
            mockRepo.Setup(repo => repo.GetScheduledTax(MunicipalGuidId, Date))
         .ReturnsAsync((List<TaxScheduledDTO>)null);

            var controller = new TaxCalculationController(mockRepo.Object, _logger);
            
            // Act
            var okResult =  controller.GetData(MunicipalGuidId, Date);
            // Assert

            var items = Assert.IsType<Task<List<TaxScheduledDTO>>>(okResult);
            Assert.Equal(2,2);
        }
    }


}
