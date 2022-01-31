using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.DTO;
using Service.Models;
using System.Net.Http.Headers;
using System.Text;

namespace API.Controllers
{
    [Route("api/")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private UserService _us = new UserService();
        [HttpPost("create")]
        public IActionResult CreateUser([FromBody] UserDTO userDTO)
        {
            try
            {
                _us.RegisterUser(userDTO);
                return Ok(userDTO);
            }

           catch (Exception err)
            {
                return BadRequest(err.Message);
            }  
        }
        [HttpPost("login")]
        public IActionResult LoginUser()
        {
            var header = AuthenticationHeaderValue.Parse(Request.Headers["Authorization"]); //This corresponds to using basic authorization in postman. Remember to turn "Enable SSL certificate verification off" under settings and select Type Basic Auth under Authorization  
            var credentialsAsbase64 = header.Parameter;
            byte[] data = Convert.FromBase64String(credentialsAsbase64);
            string decodedString = Encoding.UTF8.GetString(data);
            var splitString = decodedString.Split(":");
            var Username = splitString[0];
            var Password = splitString[1];
            try
            {
                _us.LoginUser(Username, Password);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok("User Logged In"); 
        }
        [HttpPost("logout")]
        public IActionResult LogoutUser()
        {
            var header = AuthenticationHeaderValue.Parse(Request.Headers["Authorization"]); //This corresponds to using basic authorization in postman. Remember to turn "Enable SSL certificate verification off" under settings and select Type Basic Auth under Authorization  
            var credentialsAsbase64 = header.Parameter;
            byte[] data = Convert.FromBase64String(credentialsAsbase64);
            string decodedString = Encoding.UTF8.GetString(data);
            var splitString = decodedString.Split(":");
            var Username = splitString[0];
            var Password = splitString[1];
            try
            {
                _us.LogoutUser(Username, Password);
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
            return Ok("User logged out");
        }
    }
}
