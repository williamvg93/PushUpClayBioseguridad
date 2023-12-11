using System;
using System.Collections.Generic;
using Domain.Entities.Company;
using Domain.Entities.Location;

namespace ApiClayBiosecurity.Dtos.Post.PersonF;

public class PersonPDto
{
    public int Id { get; set; }
    public string Idperson { get; set; }
    public string Name { get; set; }
    public DateTime CreationDate { get; set; }
    public int FkIdPersonType { get; set; }
    public int FkIdPersonCate { get; set; }
    public int FkIdTown { get; set; }
}
