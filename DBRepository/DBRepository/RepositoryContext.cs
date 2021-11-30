using DBRepository.Models;
using Microsoft.EntityFrameworkCore;

namespace DBRepository
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions<RepositoryContext> options) : base(options)
        {

        }

        public DbSet<OrderSaga> OrderSaga { get; set; }
        public DbSet<OrderSagaItem> OrderSagaItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}