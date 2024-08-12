using Microsoft.EntityFrameworkCore;

namespace TareasRestFull.Models
{
    public class TareasDbContext : DbContext
    {
        public TareasDbContext(DbContextOptions<TareasDbContext> options)
            : base(options)
        {
        }

        // Define aquí tus DbSets, que representan las tablas de la base de datos
        public DbSet<Tarea> TareaItems { get; set; }
    }
}