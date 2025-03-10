using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using ServiceBL;

namespace RestaurantWebApi
{
  public class Startup
  {
    // This method gets called by the runtime. Use this method to add services to the container.
    // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
    public void ConfigureServices(IServiceCollection services)
    {
      services.AddMvc().AddJsonOptions(options =>
      {
        options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
        options.SerializerSettings.DateFormatHandling = DateFormatHandling.IsoDateFormat;
        options.SerializerSettings.DateTimeZoneHandling = DateTimeZoneHandling.Local;
        options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
      }).SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

      //Services lifetime: Transient / Scope / Singelton
      services.AddScoped<IEmployeeService, EmployeeService>();
      services.AddScoped<ITableSrvice, TableService>();
      services.AddScoped<IOrdersService, OrdersService>();
      services.AddScoped<IMealService, MealService>();
      services.AddScoped<IMealCategoryService, MealCategoryService>();
      services.AddScoped<IRoleService, RoleService>();
      services.AddScoped<IOrderDetailsService, OrderDetailsService>();
      services.AddScoped<IEmploymentService, EmploymentService>();
      services.AddScoped<IWorkingHoursService, WorkingHoursService>();
      services.AddDependencies();
      services.AddCors(c =>
      {
        c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin());

        c.AddPolicy("CorsPolicy",
         builder => builder.AllowAnyOrigin()
         .AllowAnyMethod()
         .AllowAnyHeader()
         .AllowCredentials());
      });
    }
    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }
      app.UseMvc();
      app.UseCors("CorsPolicy");
    }
  }
}
