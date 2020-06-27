using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiAuth.Domain.Contracts
{
    public interface IGenericGetRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(int id);
    }
}
