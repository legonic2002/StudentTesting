using Microsoft.EntityFrameworkCore;

namespace ShoppingWebAPI.EFcore
{
    public class EF_DataContext : DbContext
    {
        public EF_DataContext(DbContextOptions<EF_DataContext> option) :
          base(option)
        {}
        //protected override void OnModelCreating(ModelBuilder builer)
        //{

        //    builer.UseSerialColumns();
        //}
        public DbSet<Student> Students { get; set; }
        public DbSet<Class> Classes{ get; set; }

    }
}
