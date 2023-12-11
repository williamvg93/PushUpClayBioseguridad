using Domain.Entities.PersonF;

namespace Domain.Interfaces.PersonF;

public interface IPerson : IGenericRepository<Person>
{
    Task<IEnumerable<Person>> GetAllEmployees();
}