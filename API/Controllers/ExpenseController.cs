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
            var request = Request;
                try
                {
                    AuthenticationHandler.CheckUser(request, _userService);
                    _expenseService.AddExpense(expenseDTO, UserNameAndPassword.GetUserNameAndPassword(request)[0]);
                    return Ok(expenseDTO);
                }

                catch (Exception err)
                {
                    return BadRequest(err.Message);
                }
        }
        [HttpGet("listExpense")]
        public IActionResult GetExpenses()
        {
                var request = Request; 

                try
                {
                    AuthenticationHandler.CheckUser(request,_userService);
                    var credentials = UserNameAndPassword.GetUserNameAndPassword(request);
                    var listToReturn = _expenseService.GetAllExpensesByUsername(credentials[0]);                   
                    return Ok(listToReturn); // Lägg till objektet i return
                }

                catch (Exception err)
                {
                    return BadRequest(err.Message);
                }
           
           
        }
        [HttpGet("listFilteredExpenses")]
        public IActionResult GetFilteredExpenses([FromBody] FilterExpenseDTO filterExpenseDTO)
        {
            var request = Request;

            try
            {
                AuthenticationHandler.CheckUser(request, _userService);
                var listToReturn = _expenseService.GetFilteredList(filterExpenseDTO, UserNameAndPassword.GetUserNameAndPassword(request)[0]);
                return Ok(listToReturn);
            }

            catch (Exception err)
            {
                return BadRequest(err.Message);
            }


        }
    }
   }