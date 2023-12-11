using System;
using System.Collections.Generic;
using Domain.Entities.Company;
using Domain.Entities.Location;

namespace ApiClayBiosecurity.Dtos.Get.PersonF;

public class PersonDto
{
    public int Id { get; set; }
    public string Idperson { get; set; }
    public string Name { get; set; }
    public DateTime CreationDate { get; set; }

}
