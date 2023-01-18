using EFconASPyMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace EFconASPyMVC.Context
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<AlumnoTareas>().HasKey(x => new { x.TareaId, x.AlumnoId });
            modelBuilder.Entity<Clase>().HasMany(c => c.Alumnos).WithOne(a => a.Clase).HasForeignKey(a => a.ClaseId).OnDelete(DeleteBehavior.Cascade);
        }

        public DbSet<Alumno> Alumnos { get; set; }

        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<Clase> Clases { get; set; }

        public DbSet<Tarea> Tareas { get; set; }

        public DbSet<AlumnoTareas> AlumnoTareas { get; set; }
    }
}
