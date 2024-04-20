using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Stock;
using api.Models;

namespace api.Mappers
{
    public static class StockMappers
    {
        public static StockDto toStockDto(this Stock StockModel)
        {
            return new StockDto
            {
                Id = StockModel.Id,
                Symbol = StockModel.Symbol,
                companyName = StockModel.companyName,
                Purchase = StockModel.Purchase,
                lastDiv = StockModel.lastDiv,
                Industry = StockModel.Industry,
                marketCap = StockModel.marketCap,
            };
        }

        public static Stock ToStockFromCreateDTO(this CreateStockRequestDto stockDto)
        {
            return new Stock
            {
                Symbol = stockDto.Symbol,
                companyName = stockDto.companyName,
                Purchase = stockDto.Purchase,
                lastDiv = stockDto.lastDiv,
                Industry = stockDto.Industry,
                marketCap = stockDto.marketCap,    
            };
        }
    }
}