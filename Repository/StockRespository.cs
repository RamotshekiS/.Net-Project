using System;
using System.Collections.Generic;
using System.Linq;
using api.Data;
using System.Threading.Tasks;
using api.Models;
using api.Interfaces;
using api.Dtos.Stock;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class StockRespository : IStockRespository
    {
        private readonly ApplicationDBContext _context;
        public StockRespository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<List<Stock>> GetAllAsync()
        {
            return await _context.Stocks.Include(c => c.Comments).ToListAsync();
        }
        
        public async Task<Stock> CreateAsync(Stock stockModel)
        {
            await _context.Stocks.AddAsync(stockModel);
            await _context.SaveChangesAsync();
            return stockModel;
        }

        public async Task<Stock?> DeleteAsync(int id)
        {
            var stockModel = await _context.Stocks.FirstOrDefaultAsync( x => x.Id == id);

            if(stockModel == null)
            {
                return null;
            }

            _context.Stocks.Remove(stockModel);

            await _context.SaveChangesAsync();
            return stockModel;
        }

        public async Task<Stock?> GetByIdAsync(int id)
        {
            return await _context.Stocks.Include(c => c.Comments).FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<Stock?> UpdateAsync(int id, UpdateStockRequest stockDto)
        {
            var stockModel = await _context.Stocks.FirstOrDefaultAsync(x => x.Id == id);

            if(stockModel == null)
            {
                return null;
            }

            stockModel.Symbol = stockDto.Symbol;
            stockModel.companyName = stockDto.companyName;
            stockModel.Purchase = stockDto.Purchase;
            stockModel.lastDiv = stockDto.lastDiv;
            stockModel.Industry = stockDto.Industry;
            stockModel.marketCap = stockDto.marketCap;

            await _context.SaveChangesAsync();
            return stockModel;

        }

        public Task<bool> StockExists(int id)
        {
            return _context.Stocks.AnyAsync(s => s.Id == id);
        }

    }
}