using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkManagement.Core.Contracts;
using WorkManagement.Core.Models;

namespace WorkManagement.DAL
{
    public class SQLRepository<T> : IRepository<T> where T : BaseEntity
    {
        internal DataContext _dataContext;
        internal DbSet<T> _dbSet;
        public SQLRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
            _dbSet = _dataContext.Set<T>();
        }
        public IQueryable<T> Collection()
        {
            return _dbSet;
        }

        public void Commit()
        {
            _dataContext.SaveChanges();
        }

        public void Delete(int Id)
        {
            var delete = _dbSet.Find(Id);
            if (_dataContext.Entry(delete).State == EntityState.Detached)
                _dbSet.Attach(delete);
            _dbSet.Remove(delete);
        }

        public T Find(int Id)
        {
            return _dbSet.Find(Id);
        }

        public void Insert(T TEntity)
        {
            _dbSet.Add(TEntity);
        }

        public void Update(T TEntity)
        {
            _dbSet.Attach(TEntity);
            _dataContext.Entry(TEntity).State = EntityState.Modified;
        }
    }
}
