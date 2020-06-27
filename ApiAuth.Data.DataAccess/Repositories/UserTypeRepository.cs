using ApiAuth.Domain.Contracts;
using ApiAuth.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiAuth.Data.DataAccess.Repositories
{
    public class UserTypeRepository : IGenericRepository<UserType>
    {
        public Task<UserType> Add(UserType entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<UserType>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<UserType> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<UserType> Update(UserType entity)
        {
            throw new NotImplementedException();
        }
    }
}
