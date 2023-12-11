using System;
using System.Collections.Generic;

namespace ApiClayBiosecurity.Dtos.Get.PersonF;

public class PersoncontactDto
{
    public int Id { get; set; }
    public string Description { get; set; }
    public int FkIdPerson { get; set; }
    public int FkIdContactType { get; set; }
}
