using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ManongTrade.Entity;
using ManongTrade.Repository;
using ManongTrade.WebAPI.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace ManongTrade.WebAPI.Controllers
{
    [ApiController]
    [Route("api/customer")]
    public class CustomerController : ControllerBase
    {
        private readonly ManongTradeContext _dbContext;
        private readonly ManongSettingModel _manongSettings;
        private readonly ILogger<CustomerController> _logger;

        public CustomerController(ILogger<CustomerController> Logger, IOptions<ManongSettingModel> ManongSettings, ManongTradeContext ManongTradeContext)
        {
            _logger = Logger;
            _manongSettings = ManongSettings.Value;
            _dbContext = ManongTradeContext;
        }

        [HttpGet]
        public IEnumerable<Product> GetAll()
        {
            var unitOfWork = new UnitOfWork(_dbContext);
            return unitOfWork.ProductRepo.GetAll();
        }

        //[HttpGet("{username}")]
        //public Customer CheckLogin(string Username)
        //{
        //    var unitOfWork = new UnitOfWork(_dbContext);
        //    return unitOfWork.CustomerRepo.CheckLogin(Username);
        //}


        [HttpPost("{CustomerId}")]
        public Customer GetCustomer(int CustomerId)
        {
            var unitOfWork = new UnitOfWork(_dbContext);
            return unitOfWork.CustomerRepo.Get(CustomerId);
        }
    }
}
