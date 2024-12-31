using Repositories.Models;
using System.Collections.Generic;

namespace ServiceBL
{
  public interface IEmployeeService
  {
    List<Employees> GetAllEmployees();
    Employees GetById(int employeeId);
    int AddEmployee(Employees employee);
    string checkAndGetRoleName(string name, int pass);
    int checkIdAndName(int id, string fullName);
    Employees GetEmployeeByOrderCode(int orderCode);
    Employees GetByCode(int code);
  }
}
