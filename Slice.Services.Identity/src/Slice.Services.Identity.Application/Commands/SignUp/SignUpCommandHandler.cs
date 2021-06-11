using NeoBus.MessageBus.Abstractions;
using NeoBus.MessageBus.Models;
using System.Threading;
using System.Threading.Tasks;

namespace Slice.Services.Identity.Application.Commands.SignUp
{
    public class SignUpCommandHandler : ICanHandleCommand<SignUpCommand>
    {
        public Task<CommandResult> Handle(SignUpCommand request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}
