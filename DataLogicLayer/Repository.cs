using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataLogicLayer
{
    public class Repository<T>:Singleton where T : class
    {
        //private MakaleWebDB dbContext;
        private DbSet<T> _objectset;
        public Repository()
        {
            //dbContext = Singleton.CreateContext();
            _objectset = _dbContext.Set<T>();

        }

        private int SaveChance() { return _dbContext.SaveChanges(); }
        public int Insert(T obj) { _objectset.Add(obj); return SaveChance(); }
        public int Update() { return SaveChance(); }
        public int Remove(T obj) { _objectset.Remove(obj); return SaveChance(); }
        public List<T> List() { return _objectset.ToList(); }
        public List<T> List(Expression<Func<T,bool>> where) { return _objectset.Where(where).ToList(); }
        public T Find(Expression<Func<T,bool>> where) { return _objectset.FirstOrDefault(where); }

    }
}
