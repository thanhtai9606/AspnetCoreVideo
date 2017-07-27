
using VideoCatalog.Core.RepositoryPattern;
using System;
using VideoCatalog.Data;

namespace VideoCatalog.Core
{
    public class UnitOfWork
    {
        private VideoCatalogContext _context;
        public CatalogRepository  CatalogRepository { set; get;}
        public CategoryRepository CategoryRepository { set; get;}
        public ItemRepository ItemRepository { set; get;}

        public UnitOfWork(VideoCatalogContext context)
        {
           this._context = context;
            CatalogRepository = new CatalogRepository(context);
            CategoryRepository = new CategoryRepository(context);
            ItemRepository = new ItemRepository(context);
        }
         public int Complete()
        {
            return _context.SaveChanges();
        }

        /// <summary>
        /// Disposes the current object
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Disposes all external resources.
        /// </summary>
        /// <param name="disposing">The dispose indicator.</param>
        private void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_context != null)
                {
                    _context.Dispose();
                    _context = null;
                }
            }
        }
    }
}