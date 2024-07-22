using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Model
{
    public class RoleDetailModel
    {
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; } = null!;
        public int LocationId { get; set; }
        public string LocationName { get; set; } = null!;
        public int RoleId { get; set; }
        public string RoleName { get; set; } = null!;   
        public string RoleDescription { get; set; } = null!;

    }
}
