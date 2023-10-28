using FluentValidation;
using FreshFinds.Product.API.DTOs;

namespace FreshFinds.Product.API.Validations
{
    public sealed class CreateProductValidator : AbstractValidator<CreateProductDto>
    {
       public CreateProductValidator()
       {
            RuleFor(product => product.Name).NotNull().NotEmpty();
       }
    }
}
