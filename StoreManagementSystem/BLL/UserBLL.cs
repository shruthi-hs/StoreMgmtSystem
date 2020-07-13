using StoreManagementSystem.BLL.Interface;
using StoreManagementSystem.DAL.Interface;
using StoreManagementSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreManagementSystem.BLL
{
    public class UserBLL : IUserBLL
    {
        private readonly IUserDAL _userDAL;

        public UserBLL(IUserDAL userDAL)
        {
            _userDAL = userDAL;
        }

        public async Task<User> GetUserDetail(string username)
        {
            return await _userDAL.GetUserDetail(username);
        }
    }
}
