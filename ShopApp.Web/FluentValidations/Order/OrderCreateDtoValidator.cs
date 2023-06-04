using FluentValidation;
using ShopApp.Contracts.DTO.Order;
using ShopApp.Web.FluentValidations.Product;

namespace ShopApp.Web.FluentValidations.Order
{
  public class OrderCreateDtoValidator : AbstractValidator<OrderCreateDTO>
  {
    public OrderCreateDtoValidator()
    {
      RuleFor(e=> e.Phone).NotNull().NotEmpty();
      RuleFor(e=> e.Products).NotNull().NotEmpty();
      RuleForEach(e => e.Products).SetValidator(new ProductOrderDtoValidator());
      RuleFor(e => e.DeliveryAdress).NotNull().When(e => e.IsRequiredDelivery);
      RuleFor(e => e.ShopPointDto).NotNull().When(e => !e.IsRequiredDelivery);
    }
  }
}
