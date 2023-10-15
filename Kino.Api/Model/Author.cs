using LinqToDB.Mapping;

namespace Kino.Api.Model
{
    public class Author
    {
        [Identity]
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
    }
}
