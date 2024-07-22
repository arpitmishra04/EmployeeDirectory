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
using Microsoft.EntityFrameworkCore;
using Nelibur.ObjectMapper;
using Newtonsoft.Json;

namespace EmployeeManagement.DataAccess
{
    public class RoleDetailDataAccess:IRoleDetailDataAccess
    {
        private EmployeeDbContext context;
        public RoleDetailDataAccess(EmployeeDbContext _context ) { 
            this.context = _context;
        }
       
        public List<RoleDetail> GetAll()
        {
           
            // Initialize the list
            List<RoleDetail>roleDetailsDataList= new List<RoleDetail>();
           
                context.Database.EnsureCreated();
                List<RoleDetail> roleDetails = context.RoleDetails
            .Include(e => e.Department)
            .Include(e => e.Location)
            .Include(e => e.Role)
            .ToList();

                context.SaveChanges();

                return roleDetails;

            
           
        }

        public int GetRoleDetailId( int RoleId,int DepartmentId, int locationId)
        {
            
                context.Database.EnsureCreated();
                int roleDetailId=context.RoleDetails.FirstOrDefault(r => (r.RoleId == RoleId && r.DepartmentId==DepartmentId && r.LocationId==locationId))!.RoleDetailId;
                return roleDetailId;
            
        }


        public bool Set(RoleDetail roleDetails)
        {
           
                context.Database.EnsureCreated();
                context.RoleDetails.Add(roleDetails);
                context.SaveChanges();

            
                return true;
        }

    }
}
