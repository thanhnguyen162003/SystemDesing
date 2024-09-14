using Microsoft.AspNetCore.Mvc;

namespace UberSystem.Api.Authentication.Controllers
{
    public class AuthController : BaseApiController
    {
        /// <summary>
        /// Endpoint to login into Uber System
        /// </summary>
        /// <param name="value"></param>
        [HttpPost("login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public string Login([FromBody] string value)
        {
            return "Login";
        }

        
    }
}
