using EmployeeManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Core.Interfaces
{
    public interface IRoleDetailService
    {
        bool Add( RoleDetailModel role);
        List<RoleDetailModel> ViewAll();
    }
}
