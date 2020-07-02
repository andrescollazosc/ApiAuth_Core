using ApiAuth.Domain.Contracts;
using ApiAuth.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAuth.Data.DataAccess.Repositories
{
    public class UserTypeRepository : IGenericGetRepository<UserType>
    {
        #region Attributes
        private readonly db_test_userContext _context;
        private DbSet<UserType> _dbSet;
        #endregion

        #region Constructors
        public UserTypeRepository(db_test_userContext context) {
            this._context = context;
            this._dbSet = _context.Set<UserType>();
        }
        #endregion

        public async Task<IEnumerable<UserType>> GetAllAsync() {
            var resultListUserTypes = await _dbSet.Where(userType => userType.Active == true).ToListAsync();
            return resultListUserTypes;
        }

        public async Task<UserType> GetByIdAsync(int id) {
            var resultListUserType = await _dbSet.FirstOrDefaultAsync(userType => userType.Active == true);
            return resultListUserType;
        }
    }
}
