using VideoCatalog.Core.RepositoryPattern;
using VideoCatalog.Data;
using VideoCatalog.Models;

namespace VideoCatalog.Core.RepositoryPattern
{
    public class CatalogRepository : Repository<Catalog>
    {
        public CatalogRepository(VideoCatalogContext context) : base(context){}
    }
}