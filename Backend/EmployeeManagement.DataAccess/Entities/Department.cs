using System;
using System.Collections.Generic;

namespace EmployeeManagement.DataAccess.Entities;

public partial class Department
{
    public int DepartmentId { get; set; }

    public string DepartmentName { get; set; } = null!;

    public bool? IsDeleted { get; set; }

    public virtual ICollection<RoleDetail> RoleDetails { get; set; } = new List<RoleDetail>();
}
