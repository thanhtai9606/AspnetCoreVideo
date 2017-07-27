using System;
namespace VideoCatalog.Models
{
    public class Item
    {
        public int ItemID { set; get; }
        public string Title { set; get; }
        public string Detail { set; get; }
        public string Src { set; get; }
        public string PostedBy { set; get; }
        public Rating Rating { set; get; }
        public int View { set; get; }
        public DateTime ModifiedDate { set; get; }
        public int CategoryID { set; get; }

        public Category Category { set; get; }
    }
    public enum Rating {
        A,B,C,D,E
    }
}