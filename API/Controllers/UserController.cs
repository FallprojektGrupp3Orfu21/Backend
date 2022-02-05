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
        [EnableCors("corsapp")]
        [HttpPost("login")]
        public IActionResult LoginUser()
        {
            var header = AuthenticationHeaderValue.Parse(Request.Headers["Authorization"]); //This corresponds to using basic authorization in postman. Remember to turn "Enable SSL certificate verification off" under settings and select Type Basic Auth under Authorization  
            var credentials = UserNameAndPassword.GetUserNameAndPassword(header);
            if (!_us.DoesUserExist(credentials[0]))
            {
                return BadRequest("Invalid Username");
            }
            else
            {
                try
                {
                    _us.LoginUser(credentials[0], credentials[1]);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
                return Ok("User Logged In");
            }
        }
        [EnableCors("corsapp")]
        [HttpPost("logout")]
        public IActionResult LogoutUser()
        {
            var header = AuthenticationHeaderValue.Parse(Request.Headers["Authorization"]); //This corresponds to using basic authorization in postman. Remember to turn "Enable SSL certificate verification off" under settings and select Type Basic Auth under Authorization  
            var credentials = UserNameAndPassword.GetUserNameAndPassword(header);
            if (!_us.DoesUserExist(credentials[0]))
            {
                return BadRequest("Invalid Username");
            }
            try
            {
                _us.LogoutUser(credentials[0], credentials[1]);
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
            return Ok("User logged out");
        }
        [HttpPost("expenses")]
        public IActionResult GetExpenses()
        {
            var header = AuthenticationHeaderValue.Parse(Request.Headers["Authorization"]); //This corresponds to using basic authorization in postman. Remember to turn "Enable SSL certificate verification off" under settings and select Type Basic Auth under Authorization  
            var credentials = UserNameAndPassword.GetUserNameAndPassword(header);
            var toReturn = new Service.GetExpenseDTO();
            if (!_us.DoesUserExist(credentials[0]) || (!_us.IsUserLoggedIn(credentials[0], credentials[1])))
            {

                toReturn.ErrorCode = (int)System.Net.HttpStatusCode.Forbidden;
                toReturn.StatusMessage = "Invalid Username";
                toReturn.Expenses = new List<Expense>();
                return StatusCode((int)System.Net.HttpStatusCode.Forbidden, toReturn);
            }
            else
            {
                try
                {
                    var results = _us.GetAllExpensesByUsername(credentials[0], credentials[1]);

                    toReturn.ErrorCode = (int)System.Net.HttpStatusCode.OK;
                    toReturn.StatusMessage = "Ok";
                    toReturn.Expenses = new List<Expense>();
                    if (!(results is null))
                    {
                        foreach (Expense theExpense in results)
                        {
                            toReturn.Expenses.Add(theExpense);
                        }
                    }
                }
                catch (Exception ex)
                {
                    toReturn.ErrorCode = (int)System.Net.HttpStatusCode.Forbidden;
                    toReturn.StatusMessage = ex.Message;
                    toReturn.Expenses = new List<Expense>();
                    return StatusCode((int)System.Net.HttpStatusCode.Forbidden, toReturn);
                }
            }
            return Ok(toReturn);
        }
    }
}

