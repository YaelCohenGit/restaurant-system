using Repositories.Models;
using System.Collections.Generic;

namespace ServiceBL
{
    public interface IMealCategoryService
    {
     List<MealCategory> GettAllCategories();
    }
}
