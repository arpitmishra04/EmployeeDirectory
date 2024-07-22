using System;
using System.Collections.Generic;

namespace EmployeeManagement.DataAccess.Entities;

public partial class RoleDetail
{
    public int RoleDetailId { get; set; }

    public int RoleId { get; set; }

    public int DepartmentId { get; set; }

    public int LocationId { get; set; }

    public bool? IsDeleted { get; set; } = false;

    public virtual Department Department { get; set; } = null!;

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();

    public virtual Location Location { get; set; } = null!;

    public virtual Role Role { get; set; } = null!;
}
