using NeoBus.MessageBus.Models;
using System;
using System.Collections.Generic;

namespace Slice.Services.Identity.Application.Commands.SignUp
{
    public class SignUpCommand : Command<CommandResult>
    {
        public Guid UserId { get; }

        public string UserName { get; }

        public string Email { get; }

        public string Password { get; }

        public string Role { get; }

        public IEnumerable<string> Permissions { get; }

        public SignUpCommand(Guid userId, string userName,string email, string password, string role, IEnumerable<string> permissions)
        {
            UserId = userId == Guid.Empty ? Guid.NewGuid() : userId;
            UserName = userName;
            Email = email;
            Password = password;
            Role = role;
            Permissions = permissions;
        }
    }
}
