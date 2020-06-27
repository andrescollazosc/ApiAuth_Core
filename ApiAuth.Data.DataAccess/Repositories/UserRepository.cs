using ApiAuth.Domain.Contracts;
using ApiAuth.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAuth.Data.DataAccess.Repositories
{
    public class UserRepository : IGenericRepository<Users>
    {
        #region Attributes
        private readonly db_test_userContext _context;
        private DbSet<Users> _dbSet;
        #endregion

        #region Constructors
        public UserRepository(db_test_userContext context)
        {
            this._context = context;
            this._dbSet = _context.Set<Users>();
        }
        #endregion


        #region Public methods
        public async Task<Users> Add(Users entity)
        {
            entity.Date = DateTime.UtcNow;
            entity.Active = true;

            try
            {
                _context.Users.Add(entity);
                return await _context.SaveChangesAsync() > 0 ? entity : new Users();
            }
            catch (Exception)
            { return new Users(); }
        }

        public async Task<bool> Delete(int id)
        {
            var resultUser = await _dbSet.FirstOrDefaultAsync(user => user.Active == true && user.Id == id);
            resultUser.Active = false;

            try
            {
                return await _context.SaveChangesAsync() > 0 ? true : false;
            }
            catch (Exception)
            { return false; }
        }

        public async Task<IEnumerable<Users>> GetAll()
        {
            var resultUsers = await _dbSet.Where(user => user.Active == true).ToListAsync();
            return resultUsers;
        }

        public async Task<Users> GetById(int id)
        {
            var resultUser = await _dbSet.FirstOrDefaultAsync(user => user.Active == true && user.Id == id);
            return resultUser;
        }

        public async Task<Users> Update(Users entity)
        {
            var resultUser = await _dbSet.FirstOrDefaultAsync(user => user.Active == true && user.Id == entity.Id);
            resultUser.FirstName = entity.FirstName;
            resultUser.LastName = entity.LastName;
            resultUser.Email = entity.LastName;
            resultUser.Profile = entity.Profile;

            try
            {
                return await _context.SaveChangesAsync() > 0 ? entity : new Users();
            }
            catch (Exception)
            { return new Users(); }
        }
        #endregion
    }
}
