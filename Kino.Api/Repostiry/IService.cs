using Kino.Api.Model;
using System.Collections.Generic;

namespace Kino.Api.Repostiry
{
    public interface IService
    {
        Task<Movies> GetImageAsync(int movieId);
        Task<Movies> SetImageAsync(int movieId, IFormFile file);
        Task<Movies> AddMoviesAsync(Movies movies);
        Task<IEnumerable<Movies>> GetAllMoviesAsync();

    }
}
