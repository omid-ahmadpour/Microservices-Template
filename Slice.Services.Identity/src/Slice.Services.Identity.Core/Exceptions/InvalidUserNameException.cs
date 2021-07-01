using Slice.Framework.Core.Exceptions;

namespace Slice.Services.Identity.Core.Exceptions
{
    public class InvalidUserNameException : DomainException
    {
        public override string Code { get; } = "invalid_username";

        public InvalidUserNameException(string username) : base($"Invalid invalid_username: {username}.")
        {
        }
    }
}
