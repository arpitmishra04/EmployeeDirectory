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
    public class RoleDetailService : IRoleDetailService
    {
        private IRoleDetailDataAccess roleDetailDataAccess;
        public RoleDetailService(IRoleDetailDataAccess _roleDetailDataAccess) { 
            this.roleDetailDataAccess = _roleDetailDataAccess;
        }

        public void Build()
        {

            TinyMapper.Bind<RoleDetail, RoleDetailModel>(config => {
                config.Bind(src => src.RoleId, dest => dest.RoleId);
                config.Bind(src => src.Role.RoleName, dest => dest.RoleName);
                config.Bind(src => src.Role.Description, dest => dest.RoleDescription);
                config.Bind(src => src.DepartmentId, dest => dest.DepartmentId);
                config.Bind(src => src.Department.DepartmentName, dest => dest.DepartmentName);
                config.Bind(src => src.LocationId, dest => dest.LocationId);
                config.Bind(src => src.Location.LocationName, dest => dest.LocationName);

            });
            TinyMapper.Bind<RoleDetailModel, RoleDetail>();
        }
        public bool Add(RoleDetailModel roleDetail)
        {
            Build();
            Role roleData = TinyMapper.Map<Role>(roleDetail);
            //return roleDetailDataAccess.Set(roleData);
            return true;
        }

        public List<RoleDetailModel> ViewAll()
        {
            Build();
            List<RoleDetail> roleDataList =roleDetailDataAccess.GetAll();
            List<RoleDetailModel>roles = new List<RoleDetailModel>();

            foreach (RoleDetail role in roleDataList)
            {
                RoleDetailModel roleDetail = TinyMapper.Map<RoleDetailModel>(role);
                roles.Add(roleDetail);
            }
            return roles;
        }

        public int GetId(int roleId,int deptId,int locId)
        {
            int id = roleDetailDataAccess.GetRoleDetailId(roleId, deptId, locId);
            return id;
        }
    }
}
