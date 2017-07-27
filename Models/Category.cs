using System;
using System.Collections.Generic;

namespace VideoCatalog.Models
{
    public class Category
    {
        public int CategoryID { set; get; }
        public string CategoryName { set; get; }
        public int CatalogID { set; get; }
        public DateTime ModifiedDate { set; get; }

        public Catalog Catalog { set; get; }
        public virtual ICollection<Item> Items { set; get; }
        
    }
}