using System.Threading.Tasks;

namespace ApiAuth.Domain.Contracts
{
    public interface IGenericCUDRepository<T> where T : class
    {
        Task<T> Add(T entity);
        Task<T> Update(T entity);
        Task<bool> Delete(int id);
    }
}
