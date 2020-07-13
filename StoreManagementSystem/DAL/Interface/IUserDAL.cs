using StoreManagementSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreManagementSystem.DAL.Interface
{
    public interface IUserDAL
    {
        Task<User> GetUserDetail(string username);
    }
}
