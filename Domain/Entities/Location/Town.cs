using System;
using System.Collections.Generic;
using Domain.Entities.PersonF;

namespace Domain.Entities.Location;

public partial class Town : BaseEntity
{
    public string Name { get; set; }

    public int FkIdDepartment { get; set; }

    public virtual Department FkIdDepartmentNavigation { get; set; }

    public virtual ICollection<Person> People { get; set; } = new List<Person>();
}
