using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Repositories.Models;
using ServiceBL;
using System.Collections.Generic;

namespace RestaurantWebApi.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  [EnableCors("CorsPolicy")]
  public class EmploymentController : ControllerBase
  {
    IEmploymentService employmentService;
    public EmploymentController(IEmploymentService employmentService)
    {
      this.employmentService = employmentService;
    }
    [HttpGet("getEmployments")]
    [EnableCors("CorsPolicy")]
    public List<Employment> GetEmployments()
    {
      return employmentService.GetEmployments();
    }
  }
}
