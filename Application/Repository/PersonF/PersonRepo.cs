using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
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
}