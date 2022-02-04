using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service;
using Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

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
            var credentialsAsbase64 = header.Parameter;
            byte[] data = Convert.FromBase64String(credentialsAsbase64);
            string decodedString = Encoding.UTF8.GetString(data);
            var splitString = decodedString.Split(":");
            var Username = splitString[0];
            var Password = splitString[1];
            if (!_userService.DoesUserExist(Username)){
                return BadRequest("Invalid Username");
            }
            else if (_userService.IsUserLoggedIn(Username, Password))
            {
                try
                {
                    _categoryService.CreateExpenseCategory(Username, expenseCategoryDTO.CategoryName);
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
