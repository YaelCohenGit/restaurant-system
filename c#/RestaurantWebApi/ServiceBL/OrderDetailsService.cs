using Repositories.Models;
using Repositories.Repositories;
using System.Collections.Generic;

namespace ServiceBL
{
  public class OrderDetailsService : IOrderDetailsService
  {
    IOrderDetailesRepository orderDetailsRepo;
    public OrderDetailsService(IOrderDetailesRepository orderDetailesRepository)
    {
      //Dependency Injection
      orderDetailsRepo = orderDetailesRepository;
    }

    public bool addOrderdetails(OrderDetails orderDetails)
    {
      return orderDetailsRepo.AddOrderdetails(orderDetails);
    }

    public StringOrderDetails CheckForNewOrderDetails()
    {
      return orderDetailsRepo.CheckForNewOrderDetails();
    }

    public bool DeleteMeal(OrderDetails orderDetails)
    {
      return orderDetailsRepo.DeleteMeal(orderDetails);
    }

    public bool DeleteMealByOrderCode(int orderCode)
    {
      return orderDetailsRepo.DeleteMealByOrderCode(orderCode);
    }

    public List<StringOrderDetails> GetOrderDetailsByOrderCode(int orderCode)
    {
      return orderDetailsRepo.GetOrderDetailsByOrderCode(orderCode);
    }

    public List<OrderDetailsReceipt> GetOrderDetailsReceiptsByOrderCode(int orderCode)
    {
      return orderDetailsRepo.GetOrderDetailsReceiptsByOrderCode(orderCode);
    }

        public int GetSoldMealsAmount()
        {
            return orderDetailsRepo.GetSoldMealsAmount();
        }

        public bool IsMealCreated(int orderCode, int mealCode)
    {
      return orderDetailsRepo.IsMealCreated(orderCode, mealCode);
    }

    public void UpdateMealAfterCreating(UpdateOrderDetailsData data)
    {
      orderDetailsRepo.UpdateMealAfterCreating(data);
    }

    public void UpdateServingAmount(OrderDetails orderDetails)
    {
      orderDetailsRepo.UpdateServingAmount(orderDetails);
    }
  }
}
