using System;
using System.Collections.Generic;

namespace VideoCatalog.Models
{
    public class Catalog
    {
        public int CatalogID { set; get; }
        public string CatalogName { set; get; }
        public DateTime ModifiedDate { set; get; }

        public ICollection<Category> Categories { set; get; }
    }
}