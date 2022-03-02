using CreditApp.Models;
using CreditApp.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditApp.Services
{
    public class CreditService
    {
        private readonly CreditValidator _creditValidator;
        public CreditService(CreditValidator creditValidator)
        {
            _creditValidator = creditValidator;
        }
        public Details GetOffer(Request requestData)
        {
            var validationResult = _creditValidator.Validate(requestData);
            if (validationResult.IsValid)
            {
                return FormOffer(requestData);
            }
            return new Details()
            {
                Decision = false,
                CreditValue = requestData.CreditValue,
                InterestRate = 0
            };
        }

            private static Details FormOffer(Request request)
            { 
                Details offer = new Details()
                {
                    Decision = true,
                    CreditValue = request.CreditValue
                };

                if(request.CreditValue < 20000)
                {
                    offer.InterestRate = 3;
                }
                if(request.CreditValue >= 20000 && request.CreditValue <=39999)
                {
                    offer.InterestRate = 4;
                }
                if(request.CreditValue >= 40000 && request.CreditValue <= 59999)
                {
                    offer.InterestRate = 5;
                }
                if(request.CreditValue > 60000)
                {
                    offer.InterestRate = 6;
                }
                return offer;

            }

        
    }
}
