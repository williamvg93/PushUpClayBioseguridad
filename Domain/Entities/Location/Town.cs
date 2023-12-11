using System;
using System.Collections.Generic;

namespace Domain.Entities.Location;

public partial class Town : BaseEntity
{
    public string Name { get; set; }

    public int FkIdDepartment { get; set; }

    public virtual Department FkIdDepartmentNavigation { get; set; }

    public virtual ICollection<Person> People { get; set; } = new List<Person>();
}
