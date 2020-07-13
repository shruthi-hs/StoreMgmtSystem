using StoreManagementSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreManagementSystem.BLL.Interface
{
    public interface IStockBLL
    {
        Task<Stock> UpdateStock(Stock stock);
    }
}
