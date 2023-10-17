using Kino.Api.Model;
using Kino.Api.Repostiry;
using Microsoft.AspNetCore.Mvc;

namespace Kino.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class AccountController : Controller
    {
        private readonly IAccount _account;

        public AccountController(IAccount account)
        {
            _account = account;
        }
        [HttpPost]
        public async Task<IActionResult> SignUpAsync([FromForm] User user)
        {
            bool res = await _account.SignUpAsync(user);
            if (res == false)
            {
                return BadRequest();
            }
            return Ok();
        }
        [HttpGet]
        public async Task<IActionResult> LogInAsync(string email, string password)
        {
            var res = await _account.LogInAsync(email, password);
            if (res == false)
            {
                return NotFound();
            }
            return Ok(res);
        }
    }
}
