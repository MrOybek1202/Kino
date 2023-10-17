using Kino.Api.Model;
using Kino.Api.Repostiry;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Kino.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class MovieController : ControllerBase
    {
        private readonly IService _service;

        public MovieController (IService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllMovies() 
        {
            var res = await _service.GetAllMoviesAsync();
            
            return Ok(res);
        
        }
        [HttpPost]
        public async Task<IActionResult> AddMovies([FromForm]Movies movies)
        {
            await _service.AddMoviesAsync(movies);
            return Ok(movies);

        }
        [HttpPost]
        public async Task<IActionResult> SetImage(int id, IFormFile file)
        {
            var res = await _service.SetImageAsync(id, file);
            return Ok(res);

        }
        [HttpDelete]
        public async Task<IActionResult> MoviyDalate(int id)
        {
            bool res = await _service.DelateMovieAsync(id);
            if (res == false)
            {
                return NotFound();

            }
            return Ok(res);
        }



            //[HttpGet]
            //public async Task<IActionResult> GetImage(int id)
            //{
            //    var res = await _service.GetImageAsync(id);
            //    return Ok(res);
            //}


        }
}
