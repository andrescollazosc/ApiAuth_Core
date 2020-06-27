using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiAuth.Domain.Contracts
{
    public interface IGenericRepository<T> : IGenericGetRepository<T> where T : class
    {
        Task<T> Add(T entity);
        Task<T> Update(T entity);        
        Task<bool> Delete(int id);
    }
}
