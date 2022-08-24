using Microsoft.EntityFrameworkCore;

namespace politecnico.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Profesores> Teachers { get; set; }

        public DbSet<Estudiantes> Students { get; set; }

        public DbSet<Classrooms> Classroomss { get; set; }

        public DbSet<Turns> turn { get; set; }

       
    }
}
