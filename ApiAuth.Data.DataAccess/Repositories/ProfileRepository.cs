using ApiAuth.Domain.Contracts;
using ApiAuth.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAuth.Data.DataAccess.Repositories
{
    public class ProfileRepository : IGenericGetRepository<ProfileEnt>
    {
        private readonly db_test_userContext _context;
        private DbSet<ProfileEnt> _dbSet;

        #region Constructors
        public ProfileRepository(db_test_userContext context) {
            this._context = context;
            this._dbSet = _context.Set<ProfileEnt>();
        }
        #endregion

        public async Task<IEnumerable<ProfileEnt>> GetAllAsync() {
            return await _dbSet.Where(profile => profile.Active == true).ToListAsync();
        }

        public async Task<ProfileEnt> GetByIdAsync(int id) {
            return await _dbSet.FirstOrDefaultAsync(profile => profile.Id == id);
        }
    }
}
