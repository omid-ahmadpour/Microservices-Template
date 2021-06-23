using System.Collections.Generic;

namespace Slice.Services.Identity.Web.Controllers.Requests
{
    public class SignUpRequest
    {
        public string UserName { get; }

        public string Email { get; }

        public string Password { get; }

        public string Role { get; }

        public IEnumerable<string> Permissions { get; }
    }
}
