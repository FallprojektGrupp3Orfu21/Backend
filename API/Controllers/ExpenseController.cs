using DAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service;
using Service.DTO;
using Service.Models;
using System.Net.Http.Headers;

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
        [HttpGet("listExpense")]
        public IActionResult GetExpenses()
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
                    var listToReturn = _expenseService.GetAllExpensesByUsername(credentials[0]);
                   
                    return Ok(listToReturn); // Lägg till objektet i return
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
