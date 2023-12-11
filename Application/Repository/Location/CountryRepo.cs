using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities.Location;
using Domain.Interfaces.Location;
using Persistence.Data;

namespace Application.Repository.Location;

public class CountryRepo : GenericRepository<Country>, ICountry
{
    private readonly ApiClayBioSecurutyContext _context;

    public CountryRepo(ApiClayBioSecurutyContext context) : base(context)
    {
        _context = context;
    }
}