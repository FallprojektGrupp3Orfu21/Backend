using Microsoft.AspNetCore.Mvc;
using Service;
using Service.DTO;
using Service.Models;
using System.Net.Http.Headers;

namespace API.Controllers
{
    [Route("api/")]
    [ApiController]
    public class ExpenseCategoryController : ControllerBase
    {
        private UserService _userService;
        private ExpenseCategoryService _categoryService;
        public ExpenseCategoryController()
        {
            _userService = new UserService();
            _categoryService = new ExpenseCategoryService();
        }


        [HttpPost("createExpenseCategory")]
        public IActionResult CreateExpenseCategory([FromBody] ExpenseCategoryDTO expenseCategoryDTO)
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
                    _categoryService.CreateExpenseCategory(credentials[0], expenseCategoryDTO.CategoryName);
                    return Ok(expenseCategoryDTO);
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
