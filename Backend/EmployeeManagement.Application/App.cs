using EmployeeManagement.Core.Interfaces;
using EmployeeManagement.Core.Services;
using EmployeeManagement.DataAccess;
using EmployeeManagement.DataAccess.Entities;
using EmployeeManagement.DataAccess.Interfaces;
using EmployeeManagement.Presentation;
using EmployeeManagement.Presentation.Inputs;
using EmployeeManagement.Presentation.Interfaces;
using EmployeeManagement.Presentation.Operations;
using EmployeeManagement.Presentation.Presentation;
using EmployeeManagement.Presentation.Validations;
using EmployeeManagement.Presentation.View;
using Microsoft.Extensions.DependencyInjection;

namespace EmployeeManagement.Application
{

   internal class App
    {

        static void Main()
    {
            ServiceCollection services = new ServiceCollection();
            services.AddTransient<IEmployeeService, EmployeeService>();
            services.AddTransient<IRoleService, RoleService>();
            services.AddTransient<ILocationService, LocationService>();
            services.AddTransient<IDepartmentService, DepartmentService>();
            services.AddTransient<IRoleDetailService, RoleDetailService>();
            services.AddTransient<IEmployeeDataAccess, EmployeeDataAccess>();
            services.AddTransient<ILocationDataAccess, LocationDataAccess>();
            services.AddTransient<IDepartmentDataAccess, DepartmentDataAccess>();
            services.AddTransient<IRoleDetailDataAccess, RoleDetailDataAccess>();
            services.AddTransient<IRoleDataAccess, RoleDataAccess>();
            
            services.AddScoped<EmployeeDbContext>();
            services.AddTransient<ApplicationPresenter>();


            using (ServiceProvider serviceProvider = services.BuildServiceProvider()) { 

                // Resolve and run the App
                var app =  serviceProvider.GetRequiredService<ApplicationPresenter>();
                app.Start();
            }

        }

        



    }
}