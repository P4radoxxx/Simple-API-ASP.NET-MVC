using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPITest.Repositories;
using WebAPITest.DAL;
using WebAPITest.Modeles;
using Newtonsoft.Json;
using System.Text.Json.Serialization;
using BCrypt.Net;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace WebAPITest.Controllers
{
    [ApiController]
    [Route("/api/Users")]
    public class UsersAPI : ControllerBase
    {

        private readonly IUserRepository _userRepository;
        public UsersAPI(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }





        
        [HttpPost]
        public IActionResult CreateUser([FromBody] Users user)
        {
            if(user == null)
            {
                return BadRequest("Données d'enregistrement invalides");
            }

            string password = user.password;
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password);
            user.password = hashedPassword;



            _userRepository.CreateUser(user);
            return Ok();
        }




        [HttpGet]
        public IActionResult GetAllUsers()
        {
            var users = _userRepository.GetAllUsers();

            return Ok(users);
        }
        
        [HttpGet("{id}")]
        public IActionResult GetUserById(int id)
        {
            var user = _userRepository.ReadUserID(id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }



        
        [HttpPut("{id}")]
        public IActionResult UpdateUser(int id, [FromBody] Users user)
        {
            if (user == null)
            {
                return BadRequest("Donnée invalides");
            }

            var existingUser = _userRepository.ReadUserID(id);

            if (existingUser == null)
            {
                return NotFound();
            }

            user.UserID = id;
            _userRepository.UpdateUser(user);

            return Ok();
        }



        
        [HttpDelete("{id}")]
        [Authorize]
        public IActionResult DeleteUser(int id)
        {
            var existingUser = _userRepository.ReadUserID(id);

            if (existingUser == null)
            {
                return NotFound();
            }

            _userRepository.DeleteUser(id);

            return Ok();
        }
    }
}