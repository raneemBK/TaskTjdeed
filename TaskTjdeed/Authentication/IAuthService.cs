using TaskTjdeed.Models;

namespace TaskTjdeed.Authentication
{
    public interface IAuthService
    {
        public Task<bool> Register(User user, string password);
        public Task<string?> Login(string email, string password);

    }
}
