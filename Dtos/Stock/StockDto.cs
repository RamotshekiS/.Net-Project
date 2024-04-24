using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;

namespace api.Dtos.Stock
{
    public class StockDto
    {
        public int Id { get; set;}
        public string Symbol { get; set; } = string.Empty;
        public string companyName { get; set; } = string.Empty;
        //[Column(TypeName = "decimal(18,2)")]
        public decimal Purchase { get; set; }
         // [Column(TypeName = "decimal(18,2)")]
        public decimal lastDiv { get; set; }
        public string Industry { get; set; } = string.Empty;
        public string marketCap { get; set; } = string.Empty;

        //public List<Comment> Comments { get; set; } = new List<Comment>();

    }
}