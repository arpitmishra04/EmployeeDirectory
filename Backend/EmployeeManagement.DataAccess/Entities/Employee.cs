using System;
using System.Collections.Generic;

namespace EmployeeManagement.DataAccess.Entities;

public partial class Employee
{
    public string EmployeeId { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string? DateOfBirth { get; set; }

    public string Email { get; set; } = null!;

    public string? MobileNumber { get; set; }

    public string JoiningDate { get; set; } = null!;

    public string? EmployeeProfilePic { get; set; }

    public int RoleDetailId { get; set; }

    public string? ManagerId { get; set; }

    public int? ProjectId { get; set; }

    public int? StatusId { get; set; }

    public virtual ICollection<Employee> InverseManager { get; set; } = new List<Employee>();

    public virtual Employee? Manager { get; set; }

    public virtual Project? Project { get; set; }

    public virtual RoleDetail RoleDetail { get; set; } = null!;

    public virtual Status? Status { get; set; }
}
