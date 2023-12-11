using Domain.Entities.Location;
using Domain.Interfaces.Location;
using Persistence.Data;

namespace Application.Repository.Location;

public class AddressRepo : GenericRepository<Address>, IAddress
{
    private readonly ApiClayBioSecurutyContext _context;

    public AddressRepo(ApiClayBioSecurutyContext context) : base(context)
    {
        _context = context;
    }
}