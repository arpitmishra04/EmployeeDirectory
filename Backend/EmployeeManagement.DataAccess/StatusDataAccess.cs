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
    public class StatusDataAccess:IStatusDataAccess
    {
        private EmployeeDbContext context;
        public  StatusDataAccess(EmployeeDbContext _context ) { 
            this.context = _context;
        }
       
        public List<Status> GetAll()
        {
           
            // Initialize the list
            List<Status>StatusDataList= new List<Status>();
            
                context.Database.EnsureCreated();
                StatusDataList=context.Statuses.ToList();

              
                context.SaveChanges();

            
            return StatusDataList;
        }


        public bool Set(Status status)
        {
            
                context.Database.EnsureCreated();
                context.Statuses.Add(status);
                context.SaveChanges();

            
                return true;
        }

    }
}
