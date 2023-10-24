using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPITest.DAL;
using WebAPITest.Repositories;
using BCrypt.Net;
using WebAPITest.Modeles;
using Microsoft.Extensions.Configuration;
using System.Configuration;

namespace WebAPITest.Controllers
{
    using Microsoft.Extensions.Configuration;
    using WebAPITest.DTO;

    [ApiController]
    [Route("api/login")]
    public class APILoginController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _configuration;


        public APILoginController(IUserRepository userRepository, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _configuration = configuration;
        }





        [HttpPost]
        [AllowAnonymous]
        public IActionResult UserLogin([FromBody] LoginDTO loginDto)
        {
            // Retrieve the user from DB using his email
            var existingUser = _userRepository.GetUserByEmail(loginDto.Email);

            // Check if exist and pwd match, else bye bye
            if (existingUser == null || !BCrypt.Net.BCrypt.Verify(loginDto.Password, existingUser.password))
            {
                return Unauthorized();
            }



            
            var secretKey = _configuration["JwtSettings:SecretKey"];

            // Generate a JWT token
            var jwtHelper = new JwtHelper(secretKey);
            string token = jwtHelper.GenerateToken(existingUser.email);

            // All good, return a token
            return Ok(new { Token = token });
        }
    }

}
