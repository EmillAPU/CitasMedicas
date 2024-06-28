using Microsoft.EntityFrameworkCore;

namespace DB
{
    public class CitasMedicasContext : DbContext
    {
        public CitasMedicasContext(DbContextOptions<CitasMedicasContext> options)
            : base(options)
        {
            
        }

        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<Medico> Medicos { get; set; }
        public DbSet<Especialidad> Especialidads { get; set; }
        public DbSet<Cita> Citas { get; set; }


    }
}
