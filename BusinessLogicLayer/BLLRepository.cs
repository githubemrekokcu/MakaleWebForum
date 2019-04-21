using DataLogicLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class BLLRepository<T> where T:class
    {
        Repository<T> BLLrepository;
        public BLLRepository()
        {
            BLLrepository = new Repository<T>();
        }

        public int Insert(T obj) { return BLLrepository.Insert(obj); }
        public int Update() { return BLLrepository.Update(); }
        public int Remove(T obj) { return BLLrepository.Remove(obj); }
        public List<T> List() { return BLLrepository.List(); }
        public List<T> List(Expression<Func<T, bool>> where) { return BLLrepository.List(where); }
        public T Find(Expression<Func<T, bool>> where) { return BLLrepository.Find(where); }
    }
}
