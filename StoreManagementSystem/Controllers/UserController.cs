using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StoreManagementSystem.BLL.Interface;
using StoreManagementSystem.DAL.Interface;
using StoreManagementSystem.DTO;
using StoreManagementSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreManagementSystem.Controllers
{
    [ApiController]
    [Route("api/user")]
    public class UserController : ControllerBase
    {
        private readonly IUserBLL _userBLL;
        private readonly IMapper _mapper;
        public UserController(IUserBLL userBLL, IMapper mapper)
        {
            _userBLL = userBLL;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("getUserDetail/{username}")]
        public async Task<IActionResult> GetUserDetail(string username)
        {
            UserDTO userDTO;
            try
            {
                var userResponse = await _userBLL.GetUserDetail(username);
                userDTO = _mapper.Map<UserDTO>(userResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return base.Ok(userDTO);
        }
    }
}
