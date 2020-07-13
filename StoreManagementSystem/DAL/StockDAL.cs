using Microsoft.EntityFrameworkCore;
using StoreManagementSystem.DAL.Interface;
using StoreManagementSystem.Model;
using StoreManagementSystem.Model.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreManagementSystem.DAL
{
    public class StockDAL:IStockDAL
    {
        private readonly InventoryDBContext _inventoryDBContext;

        public StockDAL(InventoryDBContext inventoryDBContext)
        {
            _inventoryDBContext = inventoryDBContext;
        }

        public async Task<Stock> UpdateStock(Stock stock)
        {
            Stock existingStock = await _inventoryDBContext.Stocks.Where(temp => temp.StockId == stock.StockId).FirstOrDefaultAsync();

            if (existingStock != null)
            {
                existingStock.Quantity = stock.Quantity;
                existingStock.UpdatedDate = DateTime.Now;
                _inventoryDBContext.SaveChanges();

                return existingStock;
            }
            else
            {
                return null;
            }
        }

    }
}
