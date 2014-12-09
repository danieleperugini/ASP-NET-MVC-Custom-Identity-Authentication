using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace MyFishEye.DataAccess
{
    public interface IBaseRepository<TEntity> : IDisposable where TEntity : class
    {
        IList<TEntity> GetAll();
        IList<TEntity> GetAll(string[] include);
        IList<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate);
        TEntity GetSingle(int id);
        TEntity GetSingle(Expression<Func<TEntity, bool>> predicate);

        void Edit(TEntity entity);
        bool Add(TEntity entity);
        TEntity Delete(TEntity entity);
        bool IsValid(TEntity entity);
        void Save();
    }

}
