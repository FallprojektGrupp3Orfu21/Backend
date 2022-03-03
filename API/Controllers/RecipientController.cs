using Microsoft.AspNetCore.Mvc;
using Service;
using Service.DTO;
using Service.Models;
using System.Net.Http.Headers;

namespace API.Controllers
{

    [Route("api/")]
    [ApiController]
    public class RecipientController : ControllerBase
    {
        private UserService _userService;
        private RecipientService _recipientService;
        public RecipientController()
        {
            _userService = new UserService();
            _recipientService = new RecipientService();
        }
        [HttpPost("createRecipient")]
        public IActionResult CreateRecipient([FromBody] RecipientDTO recipientDTO)
        {
            var header = AuthenticationHeaderValue.Parse(Request.Headers["Authorization"]);
            var credentials = UserNameAndPassword.GetUserNameAndPassword(header);
            if (!_userService.DoesUserExist(credentials[0]))
            {
                return BadRequest("Invalid Username");
            }
            else if (_userService.IsUserLoggedIn(credentials[0], credentials[1]))
            {
                try
                {
                    _recipientService.CreateRecipient(credentials[0], recipientDTO.Name, recipientDTO.City);
                    return Ok(recipientDTO);
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
        [HttpGet("listRecipients")]
        public IActionResult GetRecipients([FromQuery] string? searchString=null)
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
                    var listToReturn = _recipientService.GetRecipients(credentials[0],searchString);

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
