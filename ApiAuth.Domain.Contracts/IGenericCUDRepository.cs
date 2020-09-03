using System.Threading.Tasks;

namespace ApiAuth.Domain.Contracts
{
    public interface IGenericCUDRepository<T> where T : class
    {
        Task<T> AddAsync(T entity);
        Task<bool> UpdateAsync(T entity);
        Task<bool> DeleteAsync(int id);
        Task<bool> DeleteAsync(string id);
    }
}
