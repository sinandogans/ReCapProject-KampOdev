using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidator:AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(c => c.CarName).MinimumLength(2);
            RuleFor(c => c.DailyPrice).GreaterThan(0);
            
            //RuleFor(c => c.CarName).Must(StartWithA);

        }

        //private bool StartWithA(string arg)
        //{
        //    return arg.StartsWith("A");
        //}

        //Yukarıda, hazır olmayan bir kuralı nasıl yazacağımızı gösterdik.
    }
}
