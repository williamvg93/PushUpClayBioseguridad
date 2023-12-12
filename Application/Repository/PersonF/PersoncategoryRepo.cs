using Domain.Entities.PersonF;
using Domain.Interfaces.PersonF;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Application.Repository.PersonF;

public class PersoncategoryRepo : GenericRepository<Personcategory>, IPersoncategory
{
    private readonly ApiClayBioSecurutyContext _context;

    public PersoncategoryRepo(ApiClayBioSecurutyContext context) : base(context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Personcategory>> GetVigilantEmployees()
    {
        return await _context.Personcategories
        .Include(p => p.People)
        .Where(pc => pc.Description == "Vigilant")
        .ToListAsync();
    }
}