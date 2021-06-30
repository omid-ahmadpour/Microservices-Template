using Microsoft.AspNetCore.Mvc;
using NeoBus.MessageBus.Abstractions;
using Slice.Services.Identity.Application.Commands.SignUp;
using Slice.Services.Identity.Web.Controllers.Requests;
using System;
using System.Threading.Tasks;

namespace Slice.Services.Identity.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IdentityController : ControllerBase
    {
        private readonly IBus _bus;

        public IdentityController(IBus bus)
        {
            _bus = bus ?? throw new ArgumentNullException(nameof(bus));
        }

        [HttpPost]
        public async Task<ActionResult> SignUpAsync([FromBody] SignUpRequest request)
        {
            var command = new SignUpCommand(Guid.Empty, request.UserName, request.Email, request.Password, request.Role, request.Permissions);

            var result = await _bus.SendCommandAsync(command);
            return Ok(result);
        }
    }
}
