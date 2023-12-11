using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces.Company;
using Persistence.Data;

namespace Application.Repository.Company;

public class ShiftschedulingRepo : GenericRepository<Shiftscheduling>, IShiftscheduling
{
    private readonly ApiClayBioSecurutyContext _context;

    public ShiftschedulingRepo(ApiClayBioSecurutyContext context) : base(context)
    {
        _context = context;
    }
}