﻿using StoreManagementSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreManagementSystem.BLL.Interface
{
    public interface IProductBLL
    {
        Task<List<Product>> GetProducts();
        Task<Product> AddProduct(Product product);

        Task<Product> EditProduct(Product product);

        Task<bool> DeleteProduct(int productId);
    }
}
