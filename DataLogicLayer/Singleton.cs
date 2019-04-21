using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLogicLayer
{
    public class Singleton
    {

        
        protected static MakaleWebDB _dbContext;
        private static object obj = new object();

        protected Singleton()
        {
            CreateContext();
        }

        public static void CreateContext() {
            if (_dbContext==null)
                lock (obj) // multhread uygulamalarda context nesnesinin çoklu oluşturulamasını önler.
                {
                    _dbContext = new MakaleWebDB();

                }
            //return _dbContext;
        }

    }
}
