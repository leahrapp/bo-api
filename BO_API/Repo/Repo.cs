using BO_API.IRepo;
using BO_API.EntityFramework;
using BO_API.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using System.Linq;
using System.Linq.Expressions;
namespace BO_API.Repo
{
    public class Repo<TEntity> : IRepo<TEntity>
where TEntity : class, IEntityBase
    {
        protected readonly BOContext _dbContext;
        public Repo(BOContext context) => _dbContext = context;

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await _dbContext.Set<TEntity>().FindAsync(id);
        }
        public async Task<IEnumerable<TEntity>> List()
        {
            return await _dbContext.Set<TEntity>().ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> FindBy(Expression<Func<TEntity, bool>> predicate)
        {
            var result = await
            _dbContext.Set<TEntity>().Where(predicate).ToListAsync();
            return result;
        }
        public void Add(TEntity entity)
        {
            entity.CreateDate = DateTime.Now;
            entity.ModifiedBy = entity.CreatedBy;
            entity.ModifiedDate = DateTime.Now;
            _dbContext.Set<TEntity>().Add(entity);
        }
        public void Update(TEntity entity)

        {
            entity.ModifiedDate = DateTime.Now;
            _dbContext.Entry(entity).State = EntityState.Modified;
        }
        public void Delete(TEntity entity)
        {
            _dbContext.Remove(entity);
        }

    }
}
