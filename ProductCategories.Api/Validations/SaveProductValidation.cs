using FluentValidation;
using ProductCategories.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductCategories.Api.Validations
{
    public class SaveProductValidator    : AbstractValidator<Product>
    {

        public SaveProductValidator()
        {

            RuleFor(m => new { m.Sku, m.CategoryId }).Must(x => BeCorrectCategory(x.Sku, x.CategoryId))
                                      .WithMessage("Invalid combination of SKU and Category specified");



            //RuleFor(a => a.Sku).NotEmpty().Must ( ())

            //     GreaterThan(0).DependentRules(() =>
            //     {
            //         RuleFor(x => x.CategoryId).
            //          Must(BeCorrectCategory).WithMessage("Invalid category specified.");
            //     });


        }
        private bool BeCorrectCategory(int Sku , int CategoryId)
        {

            if (
                ((Sku >= 10000 && Sku < 19999) && CategoryId == 1)  ||
                ((Sku >= 20000 && Sku < 29999) && CategoryId == 2  ) ||
                     (( Sku >= 30000 && Sku < 39999 ) && CategoryId == 2  ) ||
                     (( Sku >= 40000 && Sku < 49999 ) && CategoryId == 2  ) )
            {
                return true;
            }
            return false;
           
        }



    }
}
