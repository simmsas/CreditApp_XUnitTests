using CreditApp.Models;
using CreditApp.Services;
using CreditApp.Validators;
using System;
using Xunit;

namespace CreditApp.UnitTests
{
    public class CreditServiceTests
    {
        private readonly CreditService _creditService;
        private readonly CreditValidator _creditValidator;

        public CreditServiceTests()
        {
            _creditValidator = new CreditValidator();
            _creditService = new CreditService(_creditValidator);
        }
        [Fact]
        public void GetOffer_GivenTooLowValues_GetNegativeDecision()
        {
            Request request = new Request()
            {
                CreditValue = 1000
            };

            var response = _creditService.GetOffer(request);

            Assert.False(response.Decision);
            Assert.Equal(request.CreditValue, response.CreditValue);
            Assert.Equal(0, response.InterestRate);
        }

        [Fact]
        public void GetOffer_GivenTooHighValues_GetNegativeDecision()
        {
            Request request = new Request()
            {
                CreditValue = 77000
            };
            var response = _creditService.GetOffer(request);

            Assert.False(response.Decision);
            Assert.Equal(request.CreditValue, response.CreditValue);
            Assert.Equal(0,response.InterestRate);
        }

        [Fact]
        public void GetOffer_GivenValidValues_GetPositiveDecision3()
        {
            var request = new Request()
            {
                CreditValue = 11000
            };
            var response = _creditService.GetOffer(request);

            Assert.True(response.Decision);
            Assert.Equal(3, response.InterestRate);
            Assert.Equal(request.CreditValue,response.CreditValue);

        }

        [Fact]
        public void GetOffer_GivenValidValues_GetPositiveDecision4()
        {
            var request = new Request()
            {
                CreditValue = 21000
            };
            var response = _creditService.GetOffer(request);

            Assert.True(response.Decision);
            Assert.Equal(4, response.InterestRate);
            Assert.Equal(request.CreditValue, response.CreditValue);
        }

        [Fact]
        public void GetOffer_GivenValidValues_GetPositiveDecision5()
        {
            var request = new Request()
            {
                CreditValue = 44000
            };
            var response = _creditService.GetOffer(request);

            Assert.True(response.Decision);
            Assert.Equal(5, response.InterestRate);
            Assert.Equal(request.CreditValue, response.CreditValue);
        }

        [Fact]
        public void GetOffer_GivenValidValues_GetPositiveDecision6()
        {
            var request = new Request()
            {
                CreditValue = 67000
            };
            var response = _creditService.GetOffer(request);

            Assert.True(response.Decision);
            Assert.Equal(6, response.InterestRate);
            Assert.Equal(request.CreditValue, response.CreditValue);
        }
    }
}
