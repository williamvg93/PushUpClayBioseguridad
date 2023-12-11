﻿using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Shiftscheduling : BaseEntity
{
    public int FkIdContract { get; set; }

    public int FkIdPerson { get; set; }

    public int FkIdWorkShifts { get; set; }

    public virtual Contract FkIdContractNavigation { get; set; }

    public virtual Person FkIdPersonNavigation { get; set; }

    public virtual Workshift FkIdWorkShiftsNavigation { get; set; }
}
