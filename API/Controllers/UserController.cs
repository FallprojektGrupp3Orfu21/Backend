using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.DTO;
using System.Net.Http.Headers;
using System.Text;

namespace API.Controllers
{
    [Route("api/")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpPost("create")]
        public IActionResult CreateUser([FromBody] UserDTO userDTO)
        {
            return Ok(); //TODO Add service to add user to actual DB should return BadRequest if userName is already in DB or if  
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
            return Ok(); //TODO Add service to get user from DB, check that username and passwords match. Return error if not or of if no Authorization header has been provided. Should return BadRequest() in those cases, should also set UserIsLogedIn to true. otherwise should return ok. 
        }
        [HttpPost("register")]
        //public IActionResult RegisterUser(RegisterUserDTO newUser)
        //{
        //    if(UserService.GetUserByUserName(newUser.UserName)){return BadRequest("Username allready exists")}
        //    Check Password Strenght. 
        //    if(PasswordStrength())
        //    return Ok();
        //}
    }
}
