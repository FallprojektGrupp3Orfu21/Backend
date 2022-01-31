using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service;
using Service.Models;
using System.Net.Http.Headers;
using System.Text;

namespace API.Controllers
{
    [Route("api/")]
    [ApiController]
    public class ExpenseController : ControllerBase
    {
        private UserService _userService;
        private ExpenseService _expenseService;
        public ExpenseController()
        {
            _expenseService = new ExpenseService();
            _userService = new UserService();
        }

        [HttpPost("createExpense")]
        public IActionResult CreateExpense([FromBody] ExpenseDTO expenseDTO)
        {
            var header = AuthenticationHeaderValue.Parse(Request.Headers["Authorization"]); //This corresponds to using basic authorization in postman. Remember to turn "Enable SSL certificate verification off" under settings and select Type Basic Auth under Authorization  
            var credentialsAsbase64 = header.Parameter;
            byte[] data = Convert.FromBase64String(credentialsAsbase64);
            string decodedString = Encoding.UTF8.GetString(data);
            var splitString = decodedString.Split(":");
            var Username = splitString[0];
            var Password = splitString[1];

            
            if (_userService.IsUserLoggedIn(Username, Password))
            {
                try
                {
                    _expenseService.AddExpense(expenseDTO, Username);
                    return Ok(expenseDTO);
                }

                catch (Exception err)
                {
                    return BadRequest(err.Message);
                }
            }
            else
            {
                return BadRequest("User not logged in");
            }
            
        }
    }
}
