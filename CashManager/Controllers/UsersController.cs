using CashManager.Models;
using CashManager.Data;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CashManager.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserRepository _repository = new UserRepository();

        [HttpGet]
        public ActionResult<IEnumerable<User>> GetAllUsers()
        {
            var userItems = _repository.GetAllUsers();

            return Ok(userItems);
        }

        [HttpGet("{id}")]
        public ActionResult<User> GetUserById(int id)
        {
            string user = _repository.GetUserById(id);

            return Ok(user);
        }

        [HttpPost]
        public ActionResult<User> CreateUser([FromBody]User user)
        {            
            int i = _repository.CreateUser(user);

            return GenerateResponse(i, "created");
        } 

        [HttpPut("{id}")]
        public ActionResult<User> UpdateUser(int id, [FromBody]User user)
        {
            int i = _repository.UpdateUser(id, user);

            return GenerateResponse(i, "updated");            
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteUser(int id)
        {
            int i = _repository.DeleteUser(id);

            return GenerateResponse(i, "deleted");
        }

        public ActionResult GenerateResponse(int i, string action)
        {
            if (i > 0)
            {
                return Ok($"User {action}");
            }
            else
            {
                return BadRequest("Something went wrong");
            }
        }
    }
}
