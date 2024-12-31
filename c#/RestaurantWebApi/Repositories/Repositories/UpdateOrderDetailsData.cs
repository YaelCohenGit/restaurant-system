namespace Repositories.Repositories
{
 public class UpdateOrderDetailsData
  {
    public int OrderCode { get; set; }
    public int MealCode { get; set; }
    public bool IsMealCreated { get; set; }
    public int HowMuchMealCreated { get; set; }
  }
}
