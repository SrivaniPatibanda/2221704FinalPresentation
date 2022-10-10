using System;
using System.Collections.Generic;

#nullable disable

namespace SharedData.Models
{
    public partial class TblProduct
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public int? Inventory { get; set; }
    }
}
