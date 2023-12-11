using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiClayBiosecurity.Dtos.Get.Location;

public class AddressDto
{
    public int Id { get; set; }
    public string Address1 { get; set; }
    public int FkIdPerson { get; set; }
    public int FkIdAddressType { get; set; }
}
