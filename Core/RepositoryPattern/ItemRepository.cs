using VideoCatalog.Models;
using VideoCatalog.Data;
namespace VideoCatalog.Core.RepositoryPattern
{
    public class ItemRepository : Repository<Item>
    {
        public ItemRepository(VideoCatalogContext context) : base(context){}
    }
}