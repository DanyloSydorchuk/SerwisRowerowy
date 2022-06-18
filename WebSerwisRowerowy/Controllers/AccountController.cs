using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebSerwisRowerowy.Models;
using WebSerwisRowerowy.Services;

namespace WebSerwisRowerowy.Controllers
{
    [Route("api/account")]
    [ApiController]
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost("register")]
        public ActionResult RegisterUser([FromBody] RegisterUserModel registerUser)
        {
            _accountService.RegisterUser(registerUser);
            return Ok();
        }


        [HttpPost("login")]
        public ActionResult Login([FromBody] LoginUserModel loginUser)
        {
            string token = _accountService.GenerateJwt(loginUser);
            return Ok(token);
        }
    }
}
