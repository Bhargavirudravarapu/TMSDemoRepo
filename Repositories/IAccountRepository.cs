using Microsoft.AspNetCore.Identity;
using TestApp1.Models;

namespace TestApp1.Repositories
{
    public interface IAccountRepository
    {
        Task<IdentityResult> SignUpAsync(SignUpModel signUpModel);
        Task<string> LoginAsync(Login login);
    }
}
