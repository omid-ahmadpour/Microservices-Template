using Slice.Framework.Core.Entities;
using Slice.Services.Identity.Core.Exceptions;
using System;

namespace Slice.Services.Identity.Core.Entities
{
    public class User : AggregateRoot , IEntity
    {
        public Guid Id { get; private set; }

        public string UserName { get; private set; }

        public string Email { get; private set; }

        public string Role { get; private set; }

        public string Password { get; private set; }

        public DateTime CreatedAt { get; private set; }

        protected User()
        {

        }

        public User(Guid id,
            string userName,
            string email,
            string password,
            string role,
            DateTime createAt)
        {
            if (string.IsNullOrWhiteSpace(userName))
                throw new InvalidUserNameException(nameof(userName));

            if (string.IsNullOrWhiteSpace(email))
                throw new InvalidEmailException(nameof(email));

            if (string.IsNullOrWhiteSpace(password))
                throw new InvalidPasswordException(nameof(password));

            if (string.IsNullOrWhiteSpace(role))
                throw new InvalidRoleException(nameof(role));

            Id = id;
            UserName = userName;
            Email = email;
            Password = password;
            Role = role;
            CreatedAt = createAt;
        }
    }
}
