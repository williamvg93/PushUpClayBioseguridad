using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiClayBiosecurity.Dtos.Querys.PersonF;

namespace ApiClayBiosecurity.Dtos.Querys;

public class VigilantPhoneNumberDto
{
    public string Idperson { get; set; }
    public string Name { get; set; }
    public List<VigilantNumberDto> Personcontacts { get; set; }
}
