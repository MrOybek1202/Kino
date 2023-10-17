using Kino.Api.Model;

namespace Kino.Api.Repostiry
{
    public interface IAccount
    {
        Task<bool> SignUpAsync(User user);
        Task<bool> LogInAsync(string email, string password);
    }
}
