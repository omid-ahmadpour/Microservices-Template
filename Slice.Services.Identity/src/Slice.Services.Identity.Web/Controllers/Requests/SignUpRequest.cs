using System.Collections.Generic;

namespace Slice.Services.Identity.Web.Controllers.Requests
{
    public class SignUpRequest
    {
        public string UserName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string Role { get; set; }

        public IEnumerable<string> Permissions { get; set; }
    }
}
