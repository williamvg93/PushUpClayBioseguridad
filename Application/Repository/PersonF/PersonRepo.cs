using Domain.Entities.PersonF;
using Domain.Interfaces.PersonF;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Application.Repository.PersonF;

public class PersonRepo : GenericRepository<Person>, IPerson
{
    private readonly ApiClayBioSecurutyContext _context;

    public PersonRepo(ApiClayBioSecurutyContext context) : base(context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Person>> GetPhoneNumbersVigilant(int id)
    {
        return await _context.People
        .Where(p => p.Id == id)
        .Include(p => p.Personcontacts)
        .ToListAsync();
    }
}