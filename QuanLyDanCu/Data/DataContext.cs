using Microsoft.EntityFrameworkCore;
using QuanLyDanCu.Models;

namespace QuanLyDanCu.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) 
        {

        }

        public DbSet<CuDan> CuDans { get; set; }
        public DbSet<CanHo> CanHos { get; set; }
        public DbSet<CuDanCanHo> CuDanCanHos { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CuDanCanHo>()
                .HasKey(cc => new {cc.CuDanId, cc.CanHoId});
            modelBuilder.Entity<CuDanCanHo>()
                .HasOne(c => c.CanHo)
                .WithMany(cc => cc.CuDanCanHos)
                .HasForeignKey(c => c.CanHoId);
            modelBuilder.Entity<CuDanCanHo>()
                .HasOne(c => c.CuDan)
                .WithMany(cc => cc.CuDanCanHos)
                .HasForeignKey(c => c.CuDanId);
        }
    }
}
