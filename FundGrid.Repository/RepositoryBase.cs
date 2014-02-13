using ServiceStack.OrmLite;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundGrid.Repository
{
    public abstract class RepositoryBase : IDisposable
    {
        protected IDbConnection _db;
        public RepositoryBase()
        {
            var dbFactory = new OrmLiteConnectionFactory(ConfigurationManager.ConnectionStrings["FundGridConnection"].ConnectionString, SqlServerDialect.Provider, true);
            _db = dbFactory.OpenDbConnection();
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Close();
            }
        }
        ~RepositoryBase()
        {
            Dispose(false);
        }
    }
}
