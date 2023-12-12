using Domain.Entities.PersonF;

namespace Domain.Interfaces.PersonF;

public interface IPersontype : IGenericRepository<Persontype>
{
    Task<IEnumerable<Persontype>> GetAllEmployees();
}