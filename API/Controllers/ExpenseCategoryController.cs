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
        public IActionResult CreateExpenseCategory([FromBody] ExpenseCategoryDTO expenseCategoryDTO) //NOT FINISHED WAY OF TAKING IN INFO JUST USING TEMP DTO FOR TESTING SINCE MY POSTMAN WONT GET LOGIN TO WORK //Alex
        {
            //if (_userService.IsUserLoggedIn(expenseCategoryDTO.UserName, expenseCategoryDTO.Password))
            //{

            //}
            try
            {
                _categoryService.CreateExpenseCategory(expenseCategoryDTO.UserName, expenseCategoryDTO.CategoryName);
                return Ok(expenseCategoryDTO);
            }

            catch (Exception err)
            {
                return BadRequest(err.Message);
            }

        }

    }
}
