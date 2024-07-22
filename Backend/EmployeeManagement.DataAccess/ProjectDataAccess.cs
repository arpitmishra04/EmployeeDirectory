using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using EmployeeManagement.DataAccess.Entities;
using EmployeeManagement.DataAccess.Interfaces;
using EmployeeManagement.Model;
using Nelibur.ObjectMapper;
using Newtonsoft.Json;

namespace EmployeeManagement.DataAccess
{
    public class ProjectDataAccess:IProjectDataAccess
    {
        private EmployeeDbContext context;
        public ProjectDataAccess(EmployeeDbContext _context ) { 
            this.context = _context;
        }
       
        public List<Project> GetAll()
        {
           
            // Initialize the list
            List<Project>ProjectDataList= new List<Project>();
           
                context.Database.EnsureCreated();
                ProjectDataList=context.Projects.ToList();

              
                context.SaveChanges();

            
            return ProjectDataList;
        }


        public bool Set(Project project)
        {
            
                context.Database.EnsureCreated();
                context.Projects.Add(project);
                context.SaveChanges();

            
                return true;
        }

    }
}
