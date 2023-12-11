using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces.PersonF;
using Persistence.Data;

namespace Application.Repository.PersonF;

public class PersoncategoryRepo : GenericRepository<Personcategory>, IPersoncategory
{
    private readonly ApiClayBioSecurutyContext _context;

    public PersoncategoryRepo(ApiClayBioSecurutyContext context) : base(context)
    {
        _context = context;
    }
}