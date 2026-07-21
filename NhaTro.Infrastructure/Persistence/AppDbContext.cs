using Microsoft.EntityFrameworkCore;
using NhaTro.Domain.Entities;

namespace NhaTro.Infrastructure.Persistence
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<VaiTro> VaiTros => Set<VaiTro>();
        public DbSet<NguoiDung> NguoiDungs => Set<NguoiDung>();
        public DbSet<NguoiDungRefreshToken> NguoiDungRefreshTokens => Set<NguoiDungRefreshToken>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}