﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StoreManagementSystem.BLL.Interface;
using StoreManagementSystem.DTO;
using StoreManagementSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreManagementSystem.Controllers
{
    [ApiController]
    [Route("api/stocks")]
    public class StockController : ControllerBase
    {

        private readonly IStockBLL _stockBLL;
        private readonly IMapper _mapper;
        public StockController(IStockBLL stockBLL, IMapper mapper)
        {
            _stockBLL = stockBLL;
            _mapper = mapper;
        }

        [HttpPut]
        [Route("updateStock")]
        public async Task<IActionResult> UpdateStock(StockDTO stockDTO)
        {
            StockDTO stockDTOResponse;
            try
            {
                Stock stock = _mapper.Map<Stock>(stockDTO);
                var stockResponse = await _stockBLL.UpdateStock(stock);
                stockDTOResponse = _mapper.Map<StockDTO>(stockResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return base.Ok(stockDTOResponse);
        }
    }
}
