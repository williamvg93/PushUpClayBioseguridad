using Domain.Entities.PersonF;
using Domain.Interfaces.PersonF;
using Persistence.Data;

namespace Application.Repository.PersonF;

public class PersoncontactRepo : GenericRepository<Personcontact>, IPersoncontact
{
    private readonly ApiClayBioSecurutyContext _context;

    public PersoncontactRepo(ApiClayBioSecurutyContext context) : base(context)
    {
        _context = context;
    }
}