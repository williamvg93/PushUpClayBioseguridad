using Domain.Entities.PersonF;

namespace Domain.Interfaces.PersonF;

public interface IPersoncategory : IGenericRepository<Personcategory>
{
    Task<IEnumerable<Personcategory>> GetVigilantEmployees();
}