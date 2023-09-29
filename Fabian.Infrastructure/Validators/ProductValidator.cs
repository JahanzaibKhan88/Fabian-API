using Fabian.Infrastructure.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fabian.Infrastructure.Validators
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator() {
            RuleFor(product => product.ProductId).NotNull().WithMessage("Product Id Cannot be null or Empty");
            RuleFor(product => product.Sku).NotNull().WithMessage("Product Must have a SKU number.");
            RuleFor(product => product.Name).NotNull().MinimumLength(3).MaximumLength(25).WithSeverity(Severity.Warning).WithMessage("Product Name should be between 3 and 25 characters long.");
            RuleFor(product => product.Expiry).NotEmpty().WithSeverity(Severity.Info).WithMessage("Expiry date should be present on each product.");
        }
    }
}
