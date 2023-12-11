﻿using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Address
{
    public int Id { get; set; }

    public string Address1 { get; set; }

    public int FkIdPerson { get; set; }

    public int FkIdAddressType { get; set; }

    public virtual Addresstype FkIdAddressTypeNavigation { get; set; }

    public virtual Person FkIdPersonNavigation { get; set; }
}
