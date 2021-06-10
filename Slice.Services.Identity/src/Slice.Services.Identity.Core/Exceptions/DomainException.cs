using System;

namespace Slice.Services.Identity.Core.Exceptions
{
    public class DomainException : Exception
    {
        public virtual string Code { get; }

        protected DomainException(string message) : base(message)
        {
        }
    }
}
