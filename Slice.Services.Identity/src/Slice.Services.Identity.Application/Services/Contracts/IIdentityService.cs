using Slice.Services.Identity.Application.Commands.SignIn;
using Slice.Services.Identity.Application.Commands.SignUp;
using Slice.Services.Identity.Application.Services.Models;
using System;
using System.Threading.Tasks;

namespace Slice.Services.Identity.Application.Services.Contracts
{
    public interface IIdentityService
    {
        Task<UserDto> GetAsync(Guid id);

        Task<AuthDto> SignInAsync(SignInCommand command);

        Task SignUpAsync(SignUpCommand command);
    }
}
