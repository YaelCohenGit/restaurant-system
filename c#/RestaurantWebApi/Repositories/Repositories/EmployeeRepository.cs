using System.Collections.Generic;
using System.Linq;
using Repositories.Models;

namespace Repositories.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        RestaurantObject context = new RestaurantObject();
        public EmployeeRepository(RestaurantObject context)
        {
            this.context = context;
        }
        public Employees GetById(int eployeeId)
        {
            return context.Employees.Where(e => e.EmployeeCode == eployeeId).FirstOrDefault();
        }
        public List<Employees> GetAllEmployees()
        {
            return context.Employees.ToList();
        }
        public int AddEmployee(Employees employee)
        {
            var isExists = context.Employees.Any(e => e.employeeId == employee.employeeId);
            if (!isExists)
            {
                var result = context.Employees.Add(employee);
                context.SaveChanges();
                return result.Entity.EmployeeCode;
            }
            return -1;
        }
        public void Update(Employees employee)
        {
            var result = context.Employees.Update(employee);
            context.SaveChanges();
        }

        public bool Remove(int employeeIdToRemove)
        {
            var employeeToRemove = context.Employees.Find(employeeIdToRemove);
#pragma warning disable CS0472 // The result of the expression is always the same since a value of this type is never equal to 'null'
            if (employeeIdToRemove != null)
#pragma warning restore CS0472 // The result of the expression is always the same since a value of this type is never equal to 'null'
            {
                var Result = context.Employees.Remove(employeeToRemove);
                return true;
            }
            return false;
        }

        private bool checkFullName(string fullName)
        {
            string[] nameArray = fullName.Split(' ');
            if (nameArray.Length == 1)
                return false;
            bool re = context.Employees.Any(check => (
            check.EmployeeFirstName.ToUpper() == nameArray[0].ToUpper() && check.EmployeeLastName.ToUpper() == nameArray[1].ToUpper()
            || check.EmployeeFirstName.ToUpper() == nameArray[1].ToUpper() && check.EmployeeLastName.ToUpper() == nameArray[0].ToUpper()));
            if (re == true)
                return true;
            return false;
        }
        public string checkAndGetRoleName(string name, int pass)
        {
            var fn = "";
            var ln = "";
            string[] nameArray = name.Split(' ');
            Employees empl = context.Employees.Where(check => check.EmployeeCode == pass).FirstOrDefault();
            if (empl != null)
            {
                fn = empl.EmployeeFirstName;
                ln = empl.EmployeeLastName;
                if ((fn.Trim().ToUpper() == nameArray[0].ToUpper() ||
                            fn.Trim().ToUpper() == nameArray[1].ToUpper()) &&
                            (ln.Trim().ToUpper() == nameArray[0].ToUpper() ||
                            ln.Trim().ToUpper() == nameArray[1].ToUpper()))
                {
                    Roles role = context.Roles.Where(r => r.RoleCode == empl.RoleCode).FirstOrDefault();
                    return role.RoleName;
                }
            }
            return "";
        }

        public int checkIdAndName(int id, string fullName)
        {
            Employees employee = context.Employees.Where(check => check.employeeId == id).FirstOrDefault();
            if (employee != null)
            {
                string[] nameArray = fullName.ToUpper().Split(' ');
                if (employee.EmployeeLastName.ToUpper() == nameArray[0] || employee.EmployeeLastName.ToUpper() == nameArray[1] &&
                  employee.EmployeeLastName.ToUpper() == nameArray[0] || employee.EmployeeLastName.ToUpper() == nameArray[1])
                    return employee.EmployeeCode;
            }
            return -1;
        }
        public Employees GetEmployeeByOrderCode(int orderCode)
        {
            int employeeCode = context.Orders.Where(o => o.OrderCode == orderCode).FirstOrDefault().EmployeeCode.GetValueOrDefault();
            return context.Employees.Where(e => e.EmployeeCode == employeeCode).FirstOrDefault();
        }

        public Employees GetByCode(int code)
        {
            return context.Employees.Where(w => w.EmployeeCode == code).FirstOrDefault();
        }
    }
}
