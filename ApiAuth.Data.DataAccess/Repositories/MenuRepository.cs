using ApiAuth.Domain.Contracts;
using ApiAuth.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiAuth.Data.DataAccess.Repositories
{
    public class MenuRepository : IGenericGetRepository<Menu>
    {
        private readonly db_test_userContext _context;
        private DbSet<Menu> _dbSet;

        public MenuRepository(db_test_userContext context) {
            this._context = context;
            _dbSet = _context.Set<Menu>();
        }

        public async Task<IEnumerable<Menu>> GetAllAsync()
        {
            try
            {
                var result = await _dbSet.GetListAsync("sp_GetMenu");
                return result;
            }
            catch (Exception ex)
            {
                throw;
            }            
        }

        public Task<Menu> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
