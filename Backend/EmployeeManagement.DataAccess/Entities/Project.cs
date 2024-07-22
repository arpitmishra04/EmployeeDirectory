using System;
using System.Collections.Generic;

namespace EmployeeManagement.DataAccess.Entities;

public partial class Project
{
    public int ProjectId { get; set; }

    public string? ProjectName { get; set; }

    public bool? IsDeleted { get; set; }

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
