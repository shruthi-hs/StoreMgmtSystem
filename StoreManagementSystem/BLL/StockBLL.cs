using StoreManagementSystem.BLL.Interface;
using StoreManagementSystem.DAL.Interface;
using StoreManagementSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreManagementSystem.BLL
{
    public class StockBLL:IStockBLL
    {
        private readonly IStockDAL _stockDAL;

        public StockBLL(IStockDAL stockDAL)
        {
            _stockDAL = stockDAL;
        }

        public async Task<Stock> UpdateStock(Stock stock)
        {
            return await _stockDAL.UpdateStock(stock);
        }
    }
}
