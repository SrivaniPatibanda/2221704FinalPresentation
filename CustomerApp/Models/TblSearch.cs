using System;
using System.Collections.Generic;

#nullable disable

namespace CustomerApp.Models
{
    public partial class TblSearch
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public string ReleaseDate { get; set; }
    }
}
