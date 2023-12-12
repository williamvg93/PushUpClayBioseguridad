using Domain.Entities.PersonF;
using Domain.Interfaces.PersonF;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Application.Repository.PersonF;

public class PersontypeRepo : GenericRepository<Persontype>, IPersontype
{
    private readonly ApiClayBioSecurutyContext _context;

    public PersontypeRepo(ApiClayBioSecurutyContext context) : base(context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Persontype>> GetAllEmployees()
    {
        /*         return await (from tper in _context.Persontypes
                              join per in _context.People
                              on tper.Id equals per.FkIdPersonType
                              where tper.Description == "Employee"
                              select tper
                ).ToListAsync(); */
        return await _context.Persontypes
        .Include(p => p.People)
        .Where(pt => pt.Description == "Employee")
        .ToListAsync();
    }

}