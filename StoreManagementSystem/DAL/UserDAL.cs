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
    public class UserDAL : IUserDAL
    {
        private readonly InventoryDBContext _inventoryDBContext;

        public UserDAL(InventoryDBContext inventoryDBContext)
        {
            _inventoryDBContext = inventoryDBContext;
        }

        public async Task<User> GetUserDetail(string username)
        {
            return await _inventoryDBContext.Users.Where(x => x.UserName == username).FirstOrDefaultAsync();
        }
    }
}
