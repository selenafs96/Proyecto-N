using Microsoft.EntityFrameworkCore;

namespace ProyectoNApi.Context
{
    public class ProyectoNContext : DbContext
    {
        public ProyectoNContext(DbContextOptions<ProyectoNContext> options) : base(options)
        {
        }

        public DbSet<User> User { get; set; }
    }  
} 