using ApiAuth.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiAuth.Domain.Contracts
{
    public interface IUserRepository
    {
        List<Users> GetUsers();
        Task<List<Users>> GetUsersAsync();
    }
}
