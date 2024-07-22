using System;
using System.Collections.Generic;

namespace EmployeeManagement.DataAccess.Entities;

public partial class Status
{
    public int StatusId { get; set; }

    public string? StatusValue { get; set; }

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
