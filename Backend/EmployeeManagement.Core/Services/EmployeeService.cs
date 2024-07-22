using EmployeeManagement.Model;
using System.Text.RegularExpressions;
using EmployeeManagement.DataAccess;
using EmployeeManagement.Core.Interfaces;
using EmployeeManagement.DataAccess.Interfaces;
using EmployeeManagement.DataAccess.Entities;
using Nelibur.ObjectMapper;
using Microsoft.EntityFrameworkCore;
namespace EmployeeManagement.Core.Services
{
    public class EmployeeService:IEmployeeService
    {
      
        private IEmployeeDataAccess employeeDataAccess;
        private IRoleDetailDataAccess roleDetailDataAccess;
       
        public EmployeeService(IEmployeeDataAccess _employeeDataAccess,IRoleDetailDataAccess _roleDetailDataAccess) {
            this.employeeDataAccess = _employeeDataAccess;
            this.roleDetailDataAccess = _roleDetailDataAccess;
        }
        
        private List<EmployeeModel> ?employeeList;

        public void Build()
        {
            TinyMapper.Bind<Employee, EmployeeModel>(config => {
                config.Bind(src => src.RoleDetail.RoleId, dest => dest.RoleId);
                config.Bind(src => src.RoleDetail.Role.RoleName, dest => dest.RoleName);
                config.Bind(src => src.RoleDetail.DepartmentId, dest => dest.DepartmentId);
                config.Bind(src => src.RoleDetail.Department.DepartmentName, dest => dest.DepartmentName);
                config.Bind(src => src.RoleDetail.LocationId, dest => dest.LocationId);
                config.Bind(src => src.RoleDetail.Location.LocationName, dest => dest.LocationName);
                config.Bind(src => src.ProjectId, dest => dest.ProjectId);
                config.Bind(src => src.Project!.ProjectName, dest => dest.ProjectName);
                config.Bind(src => src.StatusId, dest => dest.StatusId);
                config.Bind(src => src.Status!.StatusValue, dest => dest.StatusName);


            });
            TinyMapper.Bind<EmployeeModel, Employee>();
        }
        public bool Add(EmployeeModel employee)
        {
            Build();
            int id = roleDetailDataAccess.GetRoleDetailId(employee.RoleId, employee.DepartmentId, employee.LocationId);
            Employee employeeEntity = null!;
            employeeEntity = TinyMapper.Map<Employee>(employee);
            employeeEntity.RoleDetailId = id;   
            return employeeDataAccess.Set(employeeEntity); 
        }
            

        public bool Delete(string employeeNumber)
        {
            Employee employeeToDelete = employeeDataAccess.GetOne(employeeNumber);
            if (employeeToDelete != null)
            {
                employeeToDelete.StatusId = 3;
                return employeeDataAccess.Delete(employeeToDelete);
            }
            else
            {
                return false;
            }

            
        }

        public bool Edit(EmployeeModel updatedEmployee)
        {

            Employee employeeToUpdate=employeeDataAccess.GetOne(updatedEmployee.EmployeeId!);
            if (employeeToUpdate != null)
            {
                TinyMapper.Map(updatedEmployee, employeeToUpdate);
                return employeeDataAccess.Update(employeeToUpdate);
            }
            else
            {
                return false;
            }
            
        }

        public void GoBack()
        {
            throw new NotImplementedException();
        }

        public  List<EmployeeModel> ViewAll()
        {
            Build();
            List <Employee> emps= employeeDataAccess.GetAll();
            List<EmployeeModel> emp = [];
            EmployeeModel employeeData= null;
            foreach(Employee employee in emps)
            {
                if (employee.StatusId == 3) continue;
                employeeData = TinyMapper.Map<EmployeeModel>(employee);
                emp.Add(employeeData);
            }
            return emp;
        }

        public EmployeeModel ViewOne(string employeeNumber)
        {
           
            Employee emp = employeeDataAccess.GetOne(employeeNumber);
            EmployeeModel employee = null!;
            return employee;
        }


    }
}
