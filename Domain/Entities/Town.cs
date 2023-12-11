using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Town
{
    public int Id { get; set; }

    public string Name { get; set; }

    public int FkIdDepartment { get; set; }

    public virtual Department FkIdDepartmentNavigation { get; set; }

    public virtual ICollection<Person> People { get; set; } = new List<Person>();
}
