using FluentValidation;
using ShopApp.Contracts.DTO.Order;

namespace ShopApp.Web.FluentValidations.Product
{
  public class ProductOrderDtoValidator : AbstractValidator<ProductOrderDTO>
  {
    public ProductOrderDtoValidator()
    {
      RuleFor(e => e.Quantity).GreaterThan(0);
      RuleFor(e=> e.Price).GreaterThan(0);
    }
  }
}
