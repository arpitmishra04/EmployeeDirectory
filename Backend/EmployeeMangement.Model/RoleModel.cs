using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Model
{
    public class RoleModel
    {
        public required int RoleId { get; set; }
        public required string RoleName { get; set; }
        public required string Description { get; set; }
        
    }
}
