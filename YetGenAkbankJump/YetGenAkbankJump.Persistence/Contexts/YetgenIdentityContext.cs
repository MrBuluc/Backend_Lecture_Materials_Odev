using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using YetGenAkbankJump.Domain.Identity;

namespace YetGenAkbankJump.Persistence.Contexts
{
    public class YetgenIdentityContext : IdentityDbContext<User, Role, Guid>
    {
        public YetgenIdentityContext(DbContextOptions<YetgenIdentityContext> dbContextOptions) : base(dbContextOptions) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            
            base.OnModelCreating(builder);
        }
    }
}
