﻿using System;
using System.Collections.Generic;

namespace ApiClayBiosecurity.Dtos.Post.Location;

public class DepartmentPDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int FkIdCountry { get; set; }
}
