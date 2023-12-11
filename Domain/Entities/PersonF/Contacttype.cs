﻿using System;
using System.Collections.Generic;

namespace Domain.Entities.PersonF;

public partial class Contacttype : BaseEntity
{
    public string Description { get; set; }

    public virtual ICollection<Personcontact> Personcontacts { get; set; } = new List<Personcontact>();
}
