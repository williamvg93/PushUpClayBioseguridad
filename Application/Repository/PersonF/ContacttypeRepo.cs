using Domain.Entities.PersonF;
using Domain.Interfaces.PersonF;
using Persistence.Data;

namespace Application.Repository.PersonF;

public class ContacttypeRepo : GenericRepository<Contacttype>, IContacttype
{
    private readonly ApiClayBioSecurutyContext _context;

    public ContacttypeRepo(ApiClayBioSecurutyContext context) : base(context)
    {
        _context = context;
    }
}