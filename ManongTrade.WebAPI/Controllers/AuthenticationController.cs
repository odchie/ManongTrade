
using AutoMapper;
using ManongTrade.Entity;
using ManongTrade.Repository;
using ManongTrade.WebAPI.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace ManongTrade.WebAPI.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly ILogger<CustomerController> _logger;
        private readonly IMapper _mapper;
        private readonly ManongTradeContext _dbContext;
        private readonly ManongSettingModel _manongSettings;

        public AuthenticationController(ILogger<CustomerController> Logger, IOptions<ManongSettingModel> ManongSettings, ManongTradeContext ManongTradeContext, IMapper Mapper)
        {
            _logger = Logger;
            _manongSettings = ManongSettings.Value;
            _dbContext = ManongTradeContext;
            _mapper = Mapper;
        }

        [HttpGet("{username}")]
        public ActionResult<Customer> CheckLogin(string Username)
        {
            UnitOfWork unitOfWork = new UnitOfWork(_dbContext);
            Customer cust = unitOfWork.CustomerRepo.CheckLogin(Username);
            if (cust == null)
            {
                return NotFound();
            }
            cust.Token = Helper.JWTGenerator(Username, _manongSettings);
            return Ok(cust);
        }

        [HttpPost]
        public ActionResult<Customer> Register(Customer Customer)
        {
            var unitOfWork = new UnitOfWork(_dbContext);
            Customer cust = unitOfWork.CustomerRepo.Add(Customer);
            if (unitOfWork.SaveChanges() > 0)
            {
                cust.Token = Helper.JWTGenerator(cust.Username, _manongSettings);
                return Ok(cust);
            }
            return UnprocessableEntity();
        }
    }
}
