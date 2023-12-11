using System;
using System.Collections.Generic;

namespace Domain.Entities.PersonF;

public partial class Persontype : BaseEntity
{
    public string Description { get; set; }

    public virtual ICollection<Person> People { get; set; } = new List<Person>();
}
