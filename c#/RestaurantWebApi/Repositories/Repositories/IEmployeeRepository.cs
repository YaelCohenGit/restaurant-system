using Repositories.Models;
using System.Collections.Generic;

namespace Repositories.Repositories
{
  public interface IEmployeeRepository
  {
    Employees GetById(int eployeeId);
    Employees GetByCode(int code);
    List<Employees> GetAllEmployees();
    int AddEmployee(Employees employee);
    string checkAndGetRoleName(string name, int pass);
    int checkIdAndName(int id, string fullName);
    Employees GetEmployeeByOrderCode(int orderCode);
  }
}
