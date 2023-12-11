using System;
using System.Collections.Generic;
using Domain.Entities.Company;

namespace Domain.Entities.PersonF;

public partial class Contract : BaseEntity
{
    public DateTime ContractStartDate { get; set; }

    public DateTime ContractEndDate { get; set; }

    public int FkIdClient { get; set; }

    public int FkIdEmployee { get; set; }

    public int FkIdContractStatus { get; set; }

    public virtual Person FkIdClientNavigation { get; set; }

    public virtual Contractstatus FkIdContractStatusNavigation { get; set; }

    public virtual Person FkIdEmployeeNavigation { get; set; }

    public virtual ICollection<Shiftscheduling> Shiftschedulings { get; set; } = new List<Shiftscheduling>();
}
