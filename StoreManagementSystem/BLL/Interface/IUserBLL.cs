using StoreManagementSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreManagementSystem.BLL.Interface
{
    public interface IUserBLL
    {
        Task<User> GetUserDetail(string username);
    }
}
