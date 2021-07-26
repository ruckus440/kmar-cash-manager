using CashManager.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace CashManager.Data
{
    /// <summary>
    /// This class is a controller for the "api/login" endpoint.
    /// The HTTP request body is expected in the following JSON:
    /// {
    ///     "UserName": "<username>",    
    ///     "Password": "<password>"    
    /// }

    /// </summary>
    [Route("api/login")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly LoginRepository loginRepository = new LoginRepository();        

        [HttpPost]
        public ActionResult Login([FromBody]Login login)
        {
            bool loggedIn = loginRepository.CompareHashedPasswords(login);

            return Ok(loggedIn ? "Passwords match. Login approved." : "Username and password do not match.");            
        }
    }
}
