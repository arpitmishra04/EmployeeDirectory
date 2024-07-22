using EmployeeManagement.Core.Interfaces;
using EmployeeManagement.DataAccess;
using EmployeeManagement.DataAccess.Entities;
using EmployeeManagement.DataAccess.Interfaces;
using EmployeeManagement.Model;
using Nelibur.ObjectMapper;


namespace EmployeeManagement.Core.Services
{
    public class DepartmentService:IDepartmentService
    {
        private IDepartmentDataAccess departmentDataAccess;
        public DepartmentService(IDepartmentDataAccess _departmentDataAccess) {
            this.departmentDataAccess = _departmentDataAccess;
        }

        public void Build()
        {
            TinyMapper.Bind<Department, DepartmentModel>();
            TinyMapper.Bind<DepartmentModel, Department>(config =>
            {
                config.Ignore(src => src.DepartmentId);
            });
        }
        public bool Add(DepartmentModel department)
        {
            Build();
            Department dept = TinyMapper.Map<Department>(department);
            return departmentDataAccess.Set(dept); 
        }

        public List<DepartmentModel> ViewAll()
        {
            Build();
            
            List<DepartmentModel> departments = [];
            List<Department> depts = departmentDataAccess.GetAll();

            foreach (Department dept in depts)
            {
                DepartmentModel department = TinyMapper.Map<DepartmentModel>(dept);
                departments.Add(department);

            }
            return departments;
        }
    }
}
