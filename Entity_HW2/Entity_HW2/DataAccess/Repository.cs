using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_HW2.DataAccess
{
    internal class Repository<T> : IRepository<T> where T : class,IEntity
    {
        protected readonly DbContext DataContext;
        protected readonly DbSet<T> DataSet;
        public Repository(DbContext dataContext)
        {
            DataContext = dataContext;
            DataSet = dataContext.Set<T>();
        }
        public IQueryable<T> Query()
        {
            return DataSet;
        }

        public IEnumerable<T> All()
        {
            return  DataSet.ToList();
        }

        public T Get(int id)
        {
            return DataSet.FirstOrDefault(x => x.Id == id); ;
        }

        public void Add(T entity)
        {
            DataSet.Add(entity);
        }
    }
}
