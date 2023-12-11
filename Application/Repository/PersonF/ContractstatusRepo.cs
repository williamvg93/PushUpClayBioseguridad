using Domain.Entities.PersonF;
using Domain.Interfaces.PersonF;
using Persistence.Data;

namespace Application.Repository.PersonF;

public class ContractstatusRepo : GenericRepository<Contractstatus>, IContractstatus
{
    private readonly ApiClayBioSecurutyContext _context;

    public ContractstatusRepo(ApiClayBioSecurutyContext context) : base(context)
    {
        _context = context;
    }
}