using Microsoft.EntityFrameworkCore;
using WebApplication4.Models;

namespace WebApplication4.DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        } 
    public DbSet<Slider> Sliders { get; set; }
    }
}
