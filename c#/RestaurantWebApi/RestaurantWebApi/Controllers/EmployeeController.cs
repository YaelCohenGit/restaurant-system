using System.Collections.Generic;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Repositories.Models;
using ServiceBL;

namespace RestaurantWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("CorsPolicy")]
    public class EmployeeController : ControllerBase
    {
        IEmployeeService employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }
        [HttpGet("checkAndGetRoleName/{name}/{password}")]
        public string checkAndGetRoleName(string name, int password)
        {
            return employeeService.checkAndGetRoleName(name, password);
        }

        [HttpGet("getAllEmployees")]
        public List<Employees> Get()
        {
            return employeeService.GetAllEmployees();
        }

        [HttpGet("employeeId/{employeeId}")]
        public Employees GetById(int employeeId)
        {
            return employeeService.GetById(employeeId);
        }

        [HttpGet("checkIdAndName/{id}/{fullName}")]
        public int checkIdAndName(int id, string fullName)
        {
            return employeeService.checkIdAndName(id, fullName);
        }

        [HttpPost("addEmployee")]
        public int AddEmployee(Employees employee)
        {
            return employeeService.AddEmployee(employee);
        }
        [HttpGet("getByCode/{code}")]
        public Employees GetByCode(int code)
        {
            return employeeService.GetByCode(code);
        }
    }
}
