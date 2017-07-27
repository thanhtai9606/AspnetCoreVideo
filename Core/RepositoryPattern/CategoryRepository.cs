using VideoCatalog.Data;
using VideoCatalog.Models;
namespace VideoCatalog.Core.RepositoryPattern
{
    public class CategoryRepository : Repository<Category>
    {
        public CategoryRepository(VideoCatalogContext context) : base(context){ }
    }
}