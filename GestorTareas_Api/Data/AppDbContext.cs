using Microsoft.EntityFrameworkCore;
using GestorTareas_Api.Models;


namespace GestorTareas_Api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {  }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Tarea> Tareas { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<TareaCategoria> TareaCategorias { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // 👇 Aquí es donde lo debes pegar

            modelBuilder.Entity<Categoria>()
     .HasKey(c => c.ID_Categoria);

            modelBuilder.Entity<Tarea>()
     .HasKey(c => c.ID_Tarea);

            
            modelBuilder.Entity<TareaCategoria>()
                .HasKey(tc => new { tc.ID_Tarea, tc.ID_Categoria });  // Clave compuesta

            modelBuilder.Entity<TareaCategoria>()
                .HasOne(tc => tc.Tarea)
                .WithMany(t => t.TareasCategorias)
                .HasForeignKey(tc => tc.ID_Tarea);

            modelBuilder.Entity<TareaCategoria>()
                .HasOne(tc => tc.Categoria)
                .WithMany(c => c.TareasCategorias)
                .HasForeignKey(tc => tc.ID_Categoria);
        }
    }
}
