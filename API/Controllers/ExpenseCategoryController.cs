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
            var request = Request;
            try
                {
                    AuthenticationHandler.CheckUser(Request, _userService);
                    _categoryService.CreateExpenseCategory(UserNameAndPassword.GetUserNameAndPassword(request)[0], expenseCategoryDTO.CategoryName);
                    return Ok(expenseCategoryDTO);
                }
                catch (Exception err)
                {
                    return BadRequest(err.Message);
                }
        }

    }
}
