using System;
using System.Linq;
using VideoCatalog.Data;
using VideoCatalog.Core;
using VideoCatalog.Models;

namespace VideoCatalog.Data
{
    public static class DbInitializer
    {
       
         public static void Initialize(VideoCatalogContext context)
         {
            context.Database.EnsureCreated();
            
             UnitOfWork UnitOfWork = new UnitOfWork(context);

             //Look for any students.
            if (context.Catalogs.Any())
            {
                return;   // DB has been seeded
            }

            var catalogs = new Catalog[]
            {
                new Catalog{ CatalogName = "Article", ModifiedDate = DateTime.Now},
                new Catalog{ CatalogName = "Document", ModifiedDate = DateTime.Now},
                new Catalog{ CatalogName = "Music", ModifiedDate = DateTime.Now},
                new Catalog{ CatalogName = "Video", ModifiedDate = DateTime.Now}

            };

            foreach( var a in catalogs)
            {
                UnitOfWork.CatalogRepository.Add(a);
            }

            var categories = new Category[]
            {
                new Category{CategoryName = "Phim khoa học", CatalogID =4},
                new Category{CategoryName = "Phim hoạt hình ", CatalogID =4},
                new Category{CategoryName = "Phim Người lớn", CatalogID =4},
                new Category{CategoryName = "Tạp chí", CatalogID =1},
                new Category{CategoryName = "Sách hay", CatalogID =1}
            };

            foreach( var b in categories)
            {
                UnitOfWork.CategoryRepository.Add(b);
            }

            var items = new Item[]
            {
                new Item{ Title = "zxy",Detail ="aaa",Src= "cv.flv",PostedBy ="Dunglt",View =0, Rating = Rating.A, CategoryID =3,  ModifiedDate =DateTime.Now},
                new Item{ Title = "Nana Ninomiya",Detail ="aaa",Src= "cv.flv",PostedBy ="Dunglt",View =0, Rating = Rating.A,CategoryID =2, ModifiedDate =DateTime.Now},
                new Item{ Title = "Thien than ao tam",Detail ="aaa",Src= "cv.flv",PostedBy ="Dunglt",View =0, Rating = Rating.A,CategoryID =3, ModifiedDate =DateTime.Now},
                new Item{ Title = "Maria Ozawa",Detail ="aaa",Src= "cv.flv",PostedBy ="Dunglt",View =0, Rating = Rating.A,CategoryID =1, ModifiedDate =DateTime.Now},
                new Item{ Title = "mkx",Detail ="aaa",Src= "cv.flv",PostedBy ="Dunglt",View =0, Rating = Rating.A,CategoryID =3, ModifiedDate =DateTime.Now}
            };

            foreach(var c in items)
            {
                UnitOfWork.ItemRepository.Add(c);
            }
            UnitOfWork.Complete();
         }
    }
}