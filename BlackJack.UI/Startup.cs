using BlackJack.BL.Configuration;
using BlackJack.UI.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BlackJack.UI
{
    public class Startup
    {

        private IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            
            _configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
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
                .AddEntityFrameworkStores<UsersContext>();
            services.AddMvc();
            services.AddRepositories(_configuration.GetConnectionString("DefaultConnection"));
            services.AddServicesBL();
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
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
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseMvcWithDefaultRoute();
            
        }
    }
}
