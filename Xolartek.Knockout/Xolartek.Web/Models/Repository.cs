using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Xolartek.ORM;

namespace Xolartek.Web.Models
{
    public class Repository : IDisposable
    {
        private IXolarDB db;

        public Repository(IXolarDB ctx)
        {
            db = ctx;
        }

        #region IDisposable
        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    (db as DbContext).Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}