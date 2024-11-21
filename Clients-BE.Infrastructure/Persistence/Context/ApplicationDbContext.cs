using Clients_BE.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Clients_BE.Infrastructure.Persistence.Context
{
    public interface IApplicationDbContext : IDbContext { }
    public class ApplicationDbContext : BaseDbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Address> Addresses { get; set; }
    }
}
