using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.Stock
{
    public class UpdateStockRequest
    {
        public string Symbol { get; set; } = string.Empty;
        public string companyName { get; set; } = string.Empty;
        public decimal Purchase { get; set; }
        public decimal lastDiv { get; set; }
        public string Industry { get; set; } = string.Empty;
        public string marketCap { get; set; } = string.Empty;
    
    }
}