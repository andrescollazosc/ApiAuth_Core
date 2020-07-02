using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiAuth.Domain.Contracts
{
    public interface IGenericGetRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
    }
}
