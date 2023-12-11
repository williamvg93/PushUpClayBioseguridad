using Domain.Entities.PersonF;
using Domain.Interfaces.PersonF;
using Persistence.Data;

namespace Application.Repository.PersonF;

public class PersonRepo : GenericRepository<Person>, IPerson
{
    private readonly ApiClayBioSecurutyContext _context;

    public PersonRepo(ApiClayBioSecurutyContext context) : base(context)
    {
        _context = context;
    }

    public Task<IEnumerable<Person>> GetAllEmployees()
    {
        throw new NotImplementedException();
    }
}