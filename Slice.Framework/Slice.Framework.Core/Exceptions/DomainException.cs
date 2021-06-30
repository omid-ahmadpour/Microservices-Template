using System;

namespace Slice.Framework.Core.Exceptions
{
    public class DomainException : Exception
    {
        public virtual string Code { get; }

        protected DomainException(string message) : base(message)
        {
        }
    }
}
