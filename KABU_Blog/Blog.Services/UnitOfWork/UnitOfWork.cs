using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Services.UnitOfWork
{
    public class UnitOfWork: IUnitOfWork
    {
        private DbContext _dbContext;

        public UnitOfWork(DbContext context)
        {
            _dbContext = context;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public int Commit()
        {
            return _dbContext.SaveChanges();
        }

        private void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_dbContext != null)
                {
                    _dbContext.Dispose();
                    _dbContext = null;
                }
            }
        }

    }
}
