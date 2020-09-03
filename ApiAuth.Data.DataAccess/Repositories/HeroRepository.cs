using ApiAuth.Domain.Contracts;
using ApiAuth.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace ApiAuth.Data.DataAccess.Repositories
{
    public class HeroRepository : IGenericRepository<Hero>
    {
        #region Attributes
        private readonly db_test_userContext _context;
        private DbSet<Hero> _dbSet;
        #endregion

        #region Constructors
        public HeroRepository(db_test_userContext context) {
            this._context = context;
            this._dbSet = _context.Set<Hero>();
        }
        #endregion

        public async Task<Hero> AddAsync(Hero entity) {
            entity.Active = true;

            try {
                _context.Hero.Add(entity);

                return await _context.SaveChangesAsync() > 0 ? entity : new Hero();
            }
            catch (Exception) {
                throw;
            }
        }

        public async Task<bool> DeleteAsync(int id) {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteAsync(string id) {
            var resultSearch = _dbSet.FirstOrDefault(hero => hero.Id == id);
            resultSearch.Active = false;

            try {
                return await _context.SaveChangesAsync() > 0 ? true : false;
            }
            catch (Exception) {
                throw;
            }
        }

        public async Task<IEnumerable<Hero>> GetAllAsync() {
            var result = await _dbSet.Include(x => x.Editorial).Where(hero => hero.Active == true).ToListAsync();

            return result;
        }

        public async Task<Hero> GetByIdAsync(int id) {
            throw new NotImplementedException();
        }

        public async Task<Hero> GetByIdAsync(string id)
        {
            var result = await _dbSet.Include(x => x.Editorial).FirstOrDefaultAsync(hero => hero.Id == id && hero.Active == true);

            return result;
        }

        public async Task<bool> UpdateAsync(Hero entity) {
            var resultSearch = _dbSet.FirstOrDefault(hero => hero.Id == entity.Id);
            resultSearch.HeroName = entity.HeroName;
            resultSearch.SuperHero = entity.SuperHero;
            resultSearch.History = entity.History;
            resultSearch.UrlImage = entity.UrlImage;
            resultSearch.YearOfAppearance = entity.YearOfAppearance;                

            try
            {
                return await _context.SaveChangesAsync() > 0 ? true : false;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
