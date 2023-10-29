using FluentValidation;
using OrderService.DTOs;

namespace OrderService.Validations
{
    public class CreateOrderValidator : AbstractValidator<CreateOrderDto>
    {
        public CreateOrderValidator()
        {
            RuleFor(order => order.CustomerId).NotNull().NotEmpty();

            RuleFor(order => order.Items).NotNull().NotEmpty();
        }
    }
}
