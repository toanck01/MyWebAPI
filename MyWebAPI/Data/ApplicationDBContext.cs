using Microsoft.EntityFrameworkCore;
using MyWebAPI.Models;

namespace MyWebAPI.Data
{
    public class ApplicationDBContext:DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> u):base(u)
        {

        }
        public DbSet<MyWeb> MyWebs { get; set; }
        protected override void OnModelCreating(ModelBuilder a)
        {
            a.Entity<MyWeb>().HasData(
                new MyWeb()
                {
                    Id=1,
                    Name="MyWeb",
                    CreatedDate=DateTime.Now
                },
                new MyWeb()
                {
                    Id = 2,
                    Name = "MyWeb Van Toan",
                    CreatedDate = DateTime.Now
                },
                new MyWeb()
                {
                    Id = 3,
                    Name = "ABCXYZ",
                    CreatedDate = DateTime.Now
                }
            );
        }
    }
}
