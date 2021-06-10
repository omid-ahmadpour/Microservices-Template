using System;
using System.Collections.Generic;
using System.Linq;

namespace Slice.Services.Identity.Core.Entities
{
    public class User
    {
        public string UserName { get; set; }

        public string Email { get; private set; }

        public string Role { get; private set; }

        public string Password { get; private set; }

        public DateTime CreatedAt { get; private set; }

        public IEnumerable<string> Permissions { get; private set; }

        public User(Guid id,
            string userName,
            string email,
            string password,
            string role,
            DateTime createAt,
            IEnumerable<string> permissions = null)
        {
            if (string.IsNullOrWhiteSpace(userName))
                throw new ArgumentNullException(nameof(userName));

            if (string.IsNullOrWhiteSpace(email))
                throw new ArgumentNullException(nameof(email));

            if (string.IsNullOrWhiteSpace(password))
                throw new ArgumentNullException(nameof(password));

            if (string.IsNullOrWhiteSpace(role))
                throw new ArgumentNullException(nameof(role));

            Id = id;
            UserName = userName;
            Email = email;
            Password = password;
            Role = role;
            Permissions = permissions ?? Enumerable.Empty<string>();
        }
    }
}
