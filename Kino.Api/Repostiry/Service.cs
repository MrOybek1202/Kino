using Kino.Api.DataLayer;
using Kino.Api.Model;
using LinqToDB;
using Microsoft.Win32;
using System.IO;

namespace Kino.Api.Repostiry
{
    public class Service : IService
    {
        private readonly KinoDbContext _kinoDb;
        private readonly IWebHostEnvironment _web;

        public Service(IWebHostEnvironment web, KinoDbContext kinoDb)
        {
            _kinoDb = kinoDb;
            _web = web;
        }

        public async Task<Movies> AddMoviesAsync(Movies movies)
        {
            if(movies == null)
            {
                return new Movies();
            }
            await _kinoDb.AddAsync(movies);
            await _kinoDb.SaveChangesAsync();
            return movies;
            
        }

        public async Task<IEnumerable<Movies>> GetAllMoviesAsync()
        {
            var res = await _kinoDb.Moviess.ToListAsync();
            if(res == null)
            {
                return null;
            }
            return res;
        }

        public async Task<Movies> SetImageAsync(int movieId, IFormFile file)
        {
            var movie = await _kinoDb.Moviess.FirstOrDefaultAsync(p => p.Id == movieId);

            string fileName = Guid.NewGuid() + Path.GetExtension(file.FileName);
            string path = Path.Combine(_web.WebRootPath, $"Image/{fileName}");

            FileStream fileStream = File.Open(path, FileMode.Create);
            await file.OpenReadStream().CopyToAsync(fileStream);

            fileStream.Flush();
            fileStream.Close();

            movie.Image = fileName;
            
            return movie;


            
        }
        public async Task<bool> DelateMovieAsync(int movieId)
        {
            var res = await _kinoDb.Moviess.FirstOrDefaultAsync(p => p.Id == movieId);
            if (res == null)
            {
                return false;

            }
            _kinoDb.Moviess.Remove(res);
            _kinoDb.SaveChanges();
            return true;
        }

        

        //public async Task<File> GetImageAsync(int movieId)
        //{
        //    var movie = await _kinoDb.Moviess.FirstOrDefaultAsync(p => p.Id == movieId);

        //    string path = Path.Combine(_web.WebRootPath, movie.Image);

        //    byte[] file = await File.ReadAllBytesAsync(path);

        //    return await File(file, "octet/stream", Path.GetFileName(path));

        //}
    }
}
