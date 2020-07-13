﻿using StoreManagementSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreManagementSystem.BLL.Interface
{
    public interface IStaffBLL
    {
        Task<List<Staff>> GetStaff();

        Task<Staff> AddStaff(Staff staff);

        Task<Staff> EditStaff(Staff staff);

        Task<bool> DeleteStaff(int staffId);
    }
}
