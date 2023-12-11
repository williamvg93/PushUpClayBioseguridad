using System;
using System.Collections.Generic;
using Domain.Entities.PersonF;

namespace ApiClayBiosecurity.Dtos.Post.Location;

public class TownPDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int FkIdDepartment { get; set; }
}
