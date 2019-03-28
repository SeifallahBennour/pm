using Epione.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Infrastructure
{
    public class DataBaseFactory :Disposable, IDataBaseFactory
    {
        private Context dataContext;
        public DataBaseFactory()
        {
            dataContext=new Context();
        }
        public Context DataContext
        {
            get
            {
                return dataContext;
            }
        }

        protected override void DisposeCore()
        {
            if(DataContext!=null)
            DataContext.Dispose();
        }
    }
}
