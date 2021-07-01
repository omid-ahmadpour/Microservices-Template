using Slice.Framework.Core.Exceptions;

namespace Slice.Services.Identity.Core.Exceptions
{
    public class InvalidPasswordException : DomainException
    {
        public override string Code { get; } = "invalid_password";

        public InvalidPasswordException(string invalid_password) : base($"Invalid invalid_password: {invalid_password}.")
        {
        }
    }
}
