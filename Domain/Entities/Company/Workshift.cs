﻿using System;
using System.Collections.Generic;

namespace Domain.Entities.Company;

public partial class Workshift : BaseEntity
{
    public string Name { get; set; }

    public DateTime ShiftStartTime { get; set; }

    public DateTime ShiftEndTime { get; set; }

    public virtual ICollection<Shiftscheduling> Shiftschedulings { get; set; } = new List<Shiftscheduling>();
}
