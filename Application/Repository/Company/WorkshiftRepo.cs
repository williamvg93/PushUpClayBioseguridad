using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces.Company;
using Persistence.Data;

namespace Application.Repository.Company;

public class WorkshiftRepo : GenericRepository<Workshift>, IWorkshift
{
    private readonly ApiClayBioSecurutyContext _context;

    public WorkshiftRepo(ApiClayBioSecurutyContext context) : base(context)
    {
        _context = context;
    }
}