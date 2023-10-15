using Kino.Api.Model;
using Microsoft.EntityFrameworkCore;

namespace Kino.Api.DataLayer
{
    public class KinoDbContext:DbContext
    {
        public KinoDbContext(DbContextOptions<KinoDbContext> option)
            : base(option) { }


        DbSet<Movies> Moviess { get; set; }
        DbSet<Author> Authors { get; set; }
    }
}
