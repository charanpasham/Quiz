using Quiz.Models;
using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Quiz.Data
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public ApplicationDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
        }
        public DbSet<Quizes> Quizes { get; set; }
        public DbSet<Answers> Answers { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Questions> Question { get; set; }
        public DbSet<Response> Response { get; set; }
        public DbSet<Taken> Taken { get; set; }
    }
}
