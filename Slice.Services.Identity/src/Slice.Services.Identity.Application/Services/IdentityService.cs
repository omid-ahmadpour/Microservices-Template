using Microsoft.Extensions.Logging;
using Slice.Services.Identity.Application.Commands.SignIn;
using Slice.Services.Identity.Application.Commands.SignUp;
using Slice.Services.Identity.Application.Services.Contracts;
using Slice.Services.Identity.Application.Services.Models;
using Slice.Services.Identity.Core.Entities;
using Slice.Services.Identity.Core.Exceptions;
using Slice.Services.Identity.Core.Repositories;
using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Slice.Services.Identity.Application.Services
{
    public class IdentityService : IIdentityService
    {
        private static readonly Regex EmailRegex = new Regex(
            @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
            @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$",
            RegexOptions.IgnoreCase | RegexOptions.Compiled | RegexOptions.CultureInvariant);
        private readonly ILogger<IdentityService> _logger;
        private readonly IUserRepository _userRepository;
        private readonly IPasswordService _passwordService;

        public IdentityService(ILogger<IdentityService> logger,
                               IUserRepository userRepository,
                               IPasswordService passwordService)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            _passwordService = passwordService ?? throw new ArgumentNullException(nameof(passwordService));
        }

        public Task<UserDto> GetAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<AuthDto> SignInAsync(SignInCommand command)
        {
            throw new NotImplementedException();
        }

        public async Task SignUpAsync(SignUpCommand command)
        {
            if (!EmailRegex.IsMatch(command.Email))
            {
                _logger.LogError($"Invalid email: {command.Email}");
                throw new InvalidEmailException(command.Email);
            }

            var user = await _userRepository.GetAsync(command.UserId);
            if (user is null)
            {
                _logger.LogError($"Email already in use: {command.Email}");
                throw new EmailInUseException(command.Email);
            }

            var role = string.IsNullOrWhiteSpace(command.Role) ? "user" : command.Role.ToLowerInvariant();
            var password = _passwordService.Hash(command.Password);
            user = new User(command.UserId, command.UserName, command.Email, password, role, DateTime.UtcNow);
            await _userRepository.AddAsync(user);

            _logger.LogInformation($"Created an account for the user with id: {user.Id}.");
            //await _messageBroker.PublishAsync(new SignedUp(user.Id, user.Email, user.Role));
        }
    }
}
