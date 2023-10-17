using LinqToDB.Mapping;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Kino.Api.Model
{
    public class User
    {
        [Identity]
        public int Id { get; set; }
       
        public string? FirsName { get; set; }
        
        public string? LastName { get; set; }
        
        [EmailAddress]
        public string? Email { get; set; }
        [PasswordPropertyText]
        [MaxLength(15)]
        public string Password { get; set; }
    }
}
