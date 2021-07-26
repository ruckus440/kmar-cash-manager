using CashManager.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace CashManager.Data
{
    [Route("api/login")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly LoginRepository loginRepository = new LoginRepository();        

        [HttpGet]
        public void Get()
        {
            loginRepository.GenerateHashedPassword("testing");            
        }

        [HttpPost]
        public ActionResult Login([FromBody]Login login)
        {
            bool loggedIn = loginRepository.CompareHashedPasswords(login);

            return Ok(loggedIn ? "Passwords match. Login approved." : "Username and password do not match.");            
        }
    }
}
