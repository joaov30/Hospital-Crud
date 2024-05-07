using ApiHospital.Model;
using Microsoft.EntityFrameworkCore;

namespace ApiHospital.Data
{
    public class AppDbContext : DbContext
    {
       private DbSet<Paciente> pacientes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=BancoPacientes.sqlite");
            base.OnConfiguring(optionsBuilder);
        }

    }
}
