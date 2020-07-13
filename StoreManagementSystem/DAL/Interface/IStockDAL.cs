using StoreManagementSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreManagementSystem.DAL.Interface
{
    public interface IStockDAL
    {
        Task<Stock> UpdateStock(Stock stock);
    }
}
