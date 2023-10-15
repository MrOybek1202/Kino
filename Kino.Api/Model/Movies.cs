using LinqToDB.Mapping;

namespace Kino.Api.Model
{
    public class Movies
    {
        [Identity]
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Discreption { get; set; }
        public string? Image { get; set; }
        public virtual Author? Authors { get; set; }

    }
}
