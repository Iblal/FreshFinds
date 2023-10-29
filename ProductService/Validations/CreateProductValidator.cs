using FluentValidation;
using ProductService.DTOs;

namespace ProductService.Validations
{
    public sealed class CreateProductValidator : AbstractValidator<CreateProductDto>
    {
       public CreateProductValidator()
       {
            RuleFor(product => product.Name).NotNull().NotEmpty();
       }
    }
}
