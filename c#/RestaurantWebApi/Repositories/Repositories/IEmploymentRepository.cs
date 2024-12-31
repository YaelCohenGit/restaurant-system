using Repositories.Models;
using System.Collections.Generic;

namespace Repositories.Repositories
{
 public interface IEmploymentRepository
  {
    List<Employment> GetEmployments();
  }
}
