using System;
using System.Collections.Generic;

namespace Domain.Entities.Location;

public partial class Address : BaseEntity
{
    public string Address1 { get; set; }

    public int FkIdPerson { get; set; }

    public int FkIdAddressType { get; set; }

    public virtual Addresstype FkIdAddressTypeNavigation { get; set; }

    public virtual Person FkIdPersonNavigation { get; set; }
}
