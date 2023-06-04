namespace ShopApp.Domain.Enums
{
  public enum OrderState
  {
    AwaitingConfirmation = 1,
    Forming,
    OnWay,
    PaidAwaiting,
    Paid,
    Canceled
  }
}
