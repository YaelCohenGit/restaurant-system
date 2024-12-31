using Repositories.Models;
using System.Collections.Generic;

namespace Repositories.Repositories
{
  public interface IOrderDetailesRepository
  {
    bool AddOrderdetails(OrderDetails orderDetails);
    bool DeleteMealByOrderCode(int orderCode);
    bool DeleteMeal(OrderDetails orderDetails);
    List<StringOrderDetails> GetOrderDetailsByOrderCode(int orderCode);
    void UpdateServingAmount(OrderDetails orderDetails);
    StringOrderDetails CheckForNewOrderDetails();
    void UpdateMealAfterCreating(UpdateOrderDetailsData data);
    List<OrderDetailsReceipt> GetOrderDetailsReceiptsByOrderCode(int orderCode);
    bool IsMealCreated(int orderCode, int mealCode);
    int GetSoldMealsAmount();
  }
}
