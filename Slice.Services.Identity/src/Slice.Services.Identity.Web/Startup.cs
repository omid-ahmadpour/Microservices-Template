using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using NeoBus;
using NeoBus.MessageBus.Models;
using Slice.Services.Identity.Application.Commands.SignUp;
using Slice.Services.Identity.Application.Services;
using Slice.Services.Identity.Application.Services.Contracts;
using Slice.Services.Identity.Core.Repositories;
using Slice.Services.Identity.Infrastructure.Authentications;
using Slice.Services.Identity.Infrastructure.Repositories;

namespace Slice.Services.Identity.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddNeoBus();

            services.AddScoped<IRequestHandler<SignUpCommand, CommandResult>, SignUpCommandHandler>();

            services.AddScoped<IPasswordService, PasswordService>();
            services.AddScoped<IPasswordHasher<IPasswordService>, PasswordHasher<IPasswordService>>();

            services.AddScoped<IIdentityService, IdentityService>();
            services.AddScoped<IUserRepository, UserRepository>();

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Slice.Services.Identity.Web", Version = "v1" });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Slice.Services.Identity.Web v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
