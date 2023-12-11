using Domain.Entities.Location;
using Domain.Interfaces.Location;
using Persistence.Data;

namespace Application.Repository.Location;

public class DepartmentRepo : GenericRepository<Department>, IDepartment
{
    private readonly ApiClayBioSecurutyContext _context;

    public DepartmentRepo(ApiClayBioSecurutyContext context) : base(context)
    {
        _context = context;
    }
}