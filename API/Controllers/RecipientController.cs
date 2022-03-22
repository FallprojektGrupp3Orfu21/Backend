using Microsoft.AspNetCore.Cors;
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
           try
                {
                    var request = Request; 
                    AuthenticationHandler.CheckUser(request,_userService);
                    var credentials = UserNameAndPassword.GetUserNameAndPassword(request);
                    _recipientService.CreateRecipient(credentials[0], recipientDTO.Name, recipientDTO.City);
                    return Ok(recipientDTO);
                }

                catch (Exception err)
                {
                    return BadRequest(err.Message);
                }
        }
        [EnableCors("corsapp")]
        [HttpGet("listRecipients")]
        public IActionResult GetRecipients([FromQuery] string? searchString = null)
        {   
            var request = Request; 
             
                try
                {
                    AuthenticationHandler.CheckUser(request,_userService);
                    var credentials = UserNameAndPassword.GetUserNameAndPassword(request);
                    var listToReturn = _recipientService.GetRecipients(credentials[0], credentials[1], searchString);
                    return Ok(listToReturn); // Lägg till objektet i return
                }

                catch (Exception err)
                {
                    return BadRequest(err.Message);
                }
        }
    }
}
