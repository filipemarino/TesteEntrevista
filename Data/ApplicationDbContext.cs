using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TesteEntrevista.Models;

namespace TesteEntrevista.Data
{
   public class ApplicationDbContext : IdentityDbContext
   {
      public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
          : base(options)
      {
      }
      public DbSet<Caminhao> Caminhao { get; set; }
   }
}
