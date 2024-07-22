using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeManagement.Core.Interfaces;
using EmployeeManagement.DataAccess;
using EmployeeManagement.DataAccess.Entities;
using EmployeeManagement.DataAccess.Interfaces;
using EmployeeManagement.Model;
using Nelibur.ObjectMapper;

namespace EmployeeManagement.Core.Services
{
    public class RoleService : IRoleService
    {
        private IRoleDataAccess roleDataAccess;
        public RoleService(IRoleDataAccess _roleDataAccess) { 
            this.roleDataAccess = _roleDataAccess;
        }

        public void Build()
        {

            TinyMapper.Bind<Role, RoleModel>(config => {
                config.Bind(src => src.RoleId, dest => dest.RoleId);
                config.Bind(src => src.RoleName, dest => dest.RoleName);
                config.Bind(src => src.Description, dest => dest.Description);
            });
            TinyMapper.Bind<RoleModel, Role>(config =>
            {
                config.Ignore(src => src.RoleId);
            });
        }
        public bool Add(RoleModel role)
        {
            Build();
            Role roleData = TinyMapper.Map<Role>(role);
            return roleDataAccess.Set(roleData); 
        }

        public List<RoleModel> ViewAll()
        {
            Build();
            List<Role> roleDataList =roleDataAccess.GetAll();
            List<RoleModel>roles = new List<RoleModel>();

            foreach (Role role in roleDataList)
            {
                RoleModel empRole = TinyMapper.Map<RoleModel>(role);
                roles.Add(empRole);
            }
            return roles;
        }
    }
}
