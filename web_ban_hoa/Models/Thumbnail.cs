using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace web_ban_hoa.Models
{
    public class Thumbnail
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
        public int  CategoryId { get; set; }
        public int ProductId { get; set; }
    }
}