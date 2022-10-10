using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerApp.Models
{
    public class CreateBook
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Category { get; set; }
        public  IFormFile Image { get; set; }
        public string Price { get; set; }
        public string Publisher { get; set; }
        public string Active { get; set; }
        public string Content { get; set; }
    }
}
