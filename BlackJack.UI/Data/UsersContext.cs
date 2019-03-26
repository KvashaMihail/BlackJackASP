using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BlackJack.UI.Data
{
    public class UsersContext : IdentityDbContext
    {
        public UsersContext(DbContextOptions<UsersContext> options)
            : base (options)
        {
            Database.EnsureCreated();
        }
    }
}
