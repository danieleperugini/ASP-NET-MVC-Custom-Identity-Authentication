using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using MyFishEye.Entities;
using EntityState = System.Data.Entity.EntityState;

namespace MyFishEye.DataAccess
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class 
    {
        public MyFishEyeContext Db;

        #region Constructors

        public BaseRepository(MyFishEyeContext db)
        {
            Db = db;
        }

        public BaseRepository() : this(new MyFishEyeContext()) { }

        #endregion

        #region GET methods
        public IList<TEntity> GetAll()
        {
            EstablishConnectionWhenDown();
            return Db.Set<TEntity>().ToList();
        }

        public IList<TEntity> GetAll(string[] include)
        {
            EstablishConnectionWhenDown();
            var entities = Db.Set<TEntity>();
            foreach (var item in include)
            {
                entities.Include(item);
            }
            return entities.ToList();
        }

        public IList<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate)
        {
            EstablishConnectionWhenDown();
            return Db.Set<TEntity>().Where(predicate).ToList();
        }

        public TEntity GetSingle(int id)
        {
            EstablishConnectionWhenDown();
            return Db.Set<TEntity>().Find(id);
        }

        public TEntity GetSingle(Expression<Func<TEntity, bool>> predicate)
        {
            EstablishConnectionWhenDown();
            return Db.Set<TEntity>().FirstOrDefault(predicate);
        } 
        #endregion

        #region ADD - EDIT - DELETE

        public void Edit(TEntity entity)
        {
            EstablishConnectionWhenDown();
            Db.Entry(entity).State = (EntityState) System.Data.EntityState.Modified;
        }

        public bool Add(TEntity entity)
        {
            EstablishConnectionWhenDown();
            if (!IsValid(entity))
                return false;
            try
            {
                Db.Set(typeof(TEntity)).Add(entity);
                return Db.Entry(entity).GetValidationResult().IsValid;
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                    throw new Exception(ex.InnerException.Message, ex);
                throw new Exception(ex.Message, ex);
            }
        }

        public TEntity Delete(TEntity entity)
        {
            EstablishConnectionWhenDown();
            return Db.Set<TEntity>().Remove(entity);
        }

        public bool IsValid(TEntity entity)
        {
            EstablishConnectionWhenDown();
            return Db.Entry(entity).GetValidationResult().IsValid;
        }

        private void EstablishConnectionWhenDown()
        {
            if (Db == null) Db = new MyFishEyeContext();
            if (Db.Database.Connection.State == ConnectionState.Closed ||
                Db.Database.Connection.State == ConnectionState.Broken)
            {
                Db = new MyFishEyeContext();
            }
        }

        #endregion

        public void Save()
        {
            EstablishConnectionWhenDown();
            Db.SaveChanges();
        }

        public void Dispose()
        {
            Db.Dispose();
        }
    }
}
