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
        public IActionResult CreateExpense([FromBody] GetExpenseDTO expenseDTO)
        {
            var header = AuthenticationHeaderValue.Parse(Request.Headers["Authorization"]); //This corresponds to using basic authorization in postman. Remember to turn "Enable SSL certificate verification off" under settings and select Type Basic Auth under Authorization  
            var credentials = UserNameAndPassword.GetUserNameAndPassword(header);
            if (!_userService.DoesUserExist(credentials[0]))
            {
                return BadRequest("Invalid Username");
            }

            else if (_userService.IsUserLoggedIn(credentials[0], credentials[1]))
            {
                try
                {
                    _expenseService.AddExpense(expenseDTO, credentials[0]);
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
