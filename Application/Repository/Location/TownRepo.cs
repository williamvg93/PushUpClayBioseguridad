using Domain.Entities.Location;
using Domain.Interfaces.Location;
using Persistence.Data;

namespace Application.Repository.Location;

public class TownRepo : GenericRepository<Town>, ITown
{
    private readonly ApiClayBioSecurutyContext _context;

    public TownRepo(ApiClayBioSecurutyContext context) : base(context)
    {
        _context = context;
    }
}