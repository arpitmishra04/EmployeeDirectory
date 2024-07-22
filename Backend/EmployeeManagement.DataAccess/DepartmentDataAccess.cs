using EmployeeManagement.DataAccess.Entities;
using EmployeeManagement.DataAccess.Interfaces;
using EmployeeManagement.Model;
using Nelibur.ObjectMapper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.DataAccess
{
    public class DepartmentDataAccess:IDepartmentDataAccess
    {
        private EmployeeDbContext context;
        public DepartmentDataAccess(EmployeeDbContext _context)
        {
            this.context = _context;
        }

        public List<Department> GetAll()
        {

            List<Department> depts = [];
           
            
                context.Database.EnsureCreated();
                depts=context.Departments.ToList();
                context.SaveChanges();
            

             return depts;

        }

        public bool Set(Department department)
        {
            
            
                context.Database.EnsureCreated();
                context.Departments.Add(department);
                context.SaveChanges();

            

               
            return true;
        } 
    }
}
