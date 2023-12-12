using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiClayBiosecurity.Dtos.Get.PersonF;

namespace ApiClayBiosecurity.Dtos.Querys;
public class CategoryPersonPersonDto
{
    public string Description { get; set; }
    public List<PersonDto> People { get; set; }
}
