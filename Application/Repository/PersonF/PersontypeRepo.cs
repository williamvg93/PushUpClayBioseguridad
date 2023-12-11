using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces.PersonF;
using Persistence.Data;

namespace Application.Repository.PersonF;

public class PersontypeRepo : GenericRepository<Persontype>, IPersontype
{
    private readonly ApiClayBioSecurutyContext _context;

    public PersontypeRepo(ApiClayBioSecurutyContext context) : base(context)
    {
        _context = context;
    }
}