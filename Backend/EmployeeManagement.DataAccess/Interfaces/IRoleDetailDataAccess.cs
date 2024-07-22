using EmployeeManagement.DataAccess.Entities;
using EmployeeManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.DataAccess.Interfaces
{
    public interface IRoleDetailDataAccess
    {
        public List<RoleDetail> GetAll();
        public bool Set(RoleDetail role);
        public int GetRoleDetailId(int RoleId, int DepartmentId, int locationId);
    }
}
