using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Lab1.DAL.Entities;
using Microsoft.EntityFrameworkCore;
 namespace Lab1.DAL.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
       public DbSet<Dish> Dishes { get; set; }
       public DbSet<DishGroup> DishGroups { get; set; } 
       
       public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {

        }       

    }
}
