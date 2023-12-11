using Domain.Entities.PersonF;
using Domain.Interfaces.PersonF;
using Persistence.Data;

namespace Application.Repository.PersonF;

public class ContractRepo : GenericRepository<Contract>, IContract
{
    private readonly ApiClayBioSecurutyContext _context;

    public ContractRepo(ApiClayBioSecurutyContext context) : base(context)
    {
        _context = context;
    }
}