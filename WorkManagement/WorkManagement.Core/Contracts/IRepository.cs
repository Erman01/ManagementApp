using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkManagement.Core.Models;

namespace WorkManagement.Core.Contracts
{
    public interface IRepository<T> where T : BaseEntity
    {
        IQueryable<T> Collection();
        void Commit();
        T Find(int Id);
        void Insert(T TEntity);
        void Update(T TEntity);
        void Delete(int Id);
    }
}
