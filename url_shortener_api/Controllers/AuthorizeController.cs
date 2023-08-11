using Microsoft.AspNetCore.Mvc;
using BLL.DTO;
using BLL.Services;

namespace url_shortener_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthorizeController : ControllerBase
    {
        private readonly IAuthorizeService _authorizeService;
        private readonly ILogger<AuthorizeController> _logger;

        public AuthorizeController(ILogger<AuthorizeController> logger, IAuthorizeService authorizeService)
        {
            _logger = logger;
            _authorizeService = authorizeService;
        }

        [HttpPost("SignUp")]
        public async Task<IActionResult> SignUp([FromBody] UserRegister paramUser)
        {
            return Ok(await _authorizeService.SignUp(paramUser));
        }

        [HttpPost("SignIn")]
        public async Task<IActionResult> SignIn([FromBody] UserAutorize paramUser)
        {
            return Ok(await _authorizeService.SignIn(paramUser));
        }
    }
}