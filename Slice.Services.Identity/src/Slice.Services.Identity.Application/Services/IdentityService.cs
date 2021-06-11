using Slice.Services.Identity.Application.Commands.SignIn;
using Slice.Services.Identity.Application.Commands.SignUp;
using Slice.Services.Identity.Application.Services.Contracts;
using Slice.Services.Identity.Application.Services.Models;
using System;
using System.Threading.Tasks;

namespace Slice.Services.Identity.Application.Services
{
    public class IdentityService : IIdentityService
    {
        public IdentityService()
        {

        }

        public Task<UserDto> GetAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<AuthDto> SignInAsync(SignInCommand command)
        {
            throw new NotImplementedException();
        }

        public Task SignUpAsync(SignUpCommand command)
        {
            throw new NotImplementedException();
        }
    }
}
