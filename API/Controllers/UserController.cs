using DAL.Models;
using Microsoft.AspNetCore.Cors;
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
        [EnableCors("corsapp")]
        [HttpPost("createUser")]
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
        [EnableCors("corsapp")]
        [HttpPost("login")]
        public IActionResult LoginUser()
        {
            //var header = AuthenticationHeaderValue.Parse(Request.Headers["Authorization"]); //This corresponds to using basic authorization in postman. Remember to turn "Enable SSL certificate verification off" under settings and select Type Basic Auth under Authorization  
            //var credentials = UserNameAndPassword.GetUserNameAndPassword(header);
                try
                {   
                    var request = Request; 
                    AuthenticationHandler.CheckUser(request, _us);
                    var credentials = UserNameAndPassword.GetUserNameAndPassword(request);
                    _us.LoginUser(credentials[0], credentials[1]);
                    return Ok("User Logged In");
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            
        }
        [EnableCors("corsapp")]
        [HttpPost("logout")]
        public IActionResult LogoutUser()
        {
            //var header = AuthenticationHeaderValue.Parse(Request.Headers["Authorization"]); //This corresponds to using basic authorization in postman. Remember to turn "Enable SSL certificate verification off" under settings and select Type Basic Auth under Authorization  
            //var credentials = UserNameAndPassword.GetUserNameAndPassword(header);
            var request = Request;   
            var credentials = UserNameAndPassword.GetUserNameAndPassword(request);    
            try
            {
         
                AuthenticationHandler.CheckUser(request,_us);
                _us.LogoutUser(credentials[0], credentials[1]);
                return Ok("User logged out");
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
            
        }
    }
}

