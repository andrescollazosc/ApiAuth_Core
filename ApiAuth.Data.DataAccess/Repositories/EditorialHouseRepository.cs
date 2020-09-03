using ApiAuth.Domain.Contracts;
using ApiAuth.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiAuth.Data.DataAccess.Repositories
{
    public class EditorialHouseRepository : IGenericGetRepository<EditorialHouse>
    {
        #region Attributes
        private readonly db_test_userContext _context;
        private DbSet<EditorialHouse> _dbSet;
        #endregion

        #region Constructors
        public EditorialHouseRepository(db_test_userContext context)
        {
            this._context = context;
            _dbSet = _context.Set<EditorialHouse>();
        }
        #endregion

        #region MyRegion
        public async Task<IEnumerable<EditorialHouse>> GetAllAsync()
        {
            var result = await _dbSet.ToListAsync();

            return result;
        }

        public async Task<EditorialHouse> GetByIdAsync(int id)
        {
            var result = await _dbSet.FirstOrDefaultAsync(house => house.Id == id);

            return result;
        }

        public Task<EditorialHouse> GetByIdAsync(string id)
        {
            throw new System.NotImplementedException();
        }
        #endregion

    }
}
