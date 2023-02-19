using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace web_ban_hoa.Models
{
    public class Product
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int ViewCount { get; set; }
        public double OldPrice { get; set; }
        public double CurrentPrice { get; set; }
        public int Quantity { get; set; }
        public int Sold { get; set; }
        public int CategoryId { get; set; }
        public string ThumbnailPath { get; set; }

        public bool Sale { get; set; }

    }
}