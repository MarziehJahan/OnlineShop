using System;
using System.Collections.Generic;

namespace TK.Core.Entites
{
    public class Product
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public Category Category { get; set; }
        public List<Media> Medias { get; set; }
        public DateTime InseretTime { get; set; }
    }
}
