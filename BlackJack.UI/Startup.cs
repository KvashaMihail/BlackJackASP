using BlackJack.BL.Configuration;
using BlackJack.UI.Data;
using BlackJack.UI.Middlewares;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;

namespace BlackJack.UI
{
    public class Startup
    {

        private IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<UsersContext>(options =>
                options.UseSqlServer(
                    _configuration.GetConnectionString("IdentityConnection")));
            services.AddDefaultIdentity<IdentityUser>(
                options =>
                    options.Password = new PasswordOptions
                    {
                        RequireDigit = false,
                        RequiredLength = 6,
                        RequireLowercase = true,
                        RequireUppercase = false,
                        RequireNonAlphanumeric = false
                    })
                .AddEntityFrameworkStores<UsersContext>().
                AddDefaultTokenProviders();
            services.ConfigureApplicationCookie(options =>
            {
                //options.Cookie.HttpOnly = false;
                //options.LoginPath = new PathString("/Home/Login");
                //options.AccessDeniedPath = new PathString("/Home/AccessDenied");
                //options.SlidingExpiration = true;
                options.Events.OnRedirectToLogin = context =>
                {
                    context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                    return Task.CompletedTask;
                };
            });
            services.AddMvc();
            services.AddServicesFromBL(_configuration.GetConnectionString("DefaultConnection"));
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            
            app.UseHttpsRedirection();
            app.UseStatusCodePagesWithReExecute("/Error/{0}");     
            app.UseStaticFiles();          
            app.UseAuthentication();
            //app.UseMiddleware<RequestValidation>();
            app.UseMvcWithDefaultRoute();
            
        }
    }
}
