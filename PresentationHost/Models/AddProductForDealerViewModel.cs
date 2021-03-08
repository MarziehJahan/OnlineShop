using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PresentationHost.Models
{
    public class AddProductForDealerViewModel
    {
        public string DealerName { get; set; }
        public string DealerSurname { get; set; }
        public int phoneNumber { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public string CategoryName { get; set; }
        public string Path { get; set; }
        public IFormFile img { get; set; }
    }
}
