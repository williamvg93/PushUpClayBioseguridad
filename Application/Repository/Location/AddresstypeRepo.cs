using Domain.Entities.Location;
using Domain.Interfaces.Location;
using Persistence.Data;

namespace Application.Repository.Location;

public class AddresstypeRepo : GenericRepository<Addresstype>, IAddresstype
{
    private readonly ApiClayBioSecurutyContext _context;

    public AddresstypeRepo(ApiClayBioSecurutyContext context) : base(context)
    {
        _context = context;
    }
}