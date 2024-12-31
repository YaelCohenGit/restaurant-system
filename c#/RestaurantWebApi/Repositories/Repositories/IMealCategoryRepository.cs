using Repositories.Models;
using System.Collections.Generic;

namespace Repositories.Repositories
{
    public interface IMealCategoryRepository
    {
       List<MealCategory> GettAllCategories();
    }
}
