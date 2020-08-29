using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Linq.Expressions;
using BO_API.Entities; 
namespace BO_API.IRepo
{
   public interface IRepo<TEntity> where TEntity: class, IEntityBase
    {
        Task<TEntity> GetByIdAsync(int id);

        Task<IEnumerable<TEntity>> List();

        Task<IEnumerable<TEntity>> FindBy(Expression<Func<TEntity,bool>> predicate);

        void Add(TEntity entity);

        void Update(TEntity entity);

        void Delete(TEntity entity);


    }
}
