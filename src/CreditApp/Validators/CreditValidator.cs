using CreditApp.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditApp.Validators
{
    public class CreditValidator : AbstractValidator<Request>
    {
        public CreditValidator()
        {
            RuleFor(c => c.CreditValue).GreaterThan(2000);
            RuleFor(c => c.CreditValue).LessThanOrEqualTo(69000);


        }

    }
}
