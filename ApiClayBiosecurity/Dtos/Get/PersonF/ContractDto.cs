using System;
using System.Collections.Generic;
using Domain.Entities.Company;

namespace ApiClayBiosecurity.Dtos.Get.PersonF;

public class ContractDto
{
    public int Id { get; set; }
    public DateTime ContractStartDate { get; set; }
    public DateTime ContractEndDate { get; set; }
    public int FkIdClient { get; set; }
    public int FkIdEmployee { get; set; }
    public int FkIdContractStatus { get; set; }

}
