using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.Model
{
    public class EmployeeModel
    {
        public string? EmployeeId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? DateOfBirth { get; set; }
        public string? Email { get; set; }
        public string? MobileNumber { get; set; }
        public string? JoiningDate { get; set; }
        public string? EmployeeProfilePic { get; set; } = null!;
        public string? ManagerId { get; set; } = null!;
        public int? ProjectId { get; set; }= null!;
        public string ProjectName { get; set; }= null!;
        public int? StatusId { get; set; } = null!;
        public string StatusName { get; set; } = null!;
        public int RoleId { get; set; }
        public string RoleName { get; set; } = null!;
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; } = null!;
        public int LocationId {  get; set; }
        public string LocationName { get; set; } = null!;


    }
}
