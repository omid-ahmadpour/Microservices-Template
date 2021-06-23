using NeoBus.MessageBus.Abstractions;
using NeoBus.MessageBus.Models;
using Slice.Services.Identity.Application.Services.Contracts;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Slice.Services.Identity.Application.Commands.SignUp
{
    public class SignUpCommandHandler : ICanHandleCommand<SignUpCommand>
    {
        private readonly IIdentityService _identityService;

        public SignUpCommandHandler(IIdentityService identityService)
        {
            _identityService = identityService ?? throw new ArgumentNullException(nameof(identityService));
        }

        public async Task<CommandResult> Handle(SignUpCommand request, CancellationToken cancellationToken)
        {
            var result = new CommandResult();

            await _identityService.SignUpAsync(request);
            return result;
        }
    }
}
