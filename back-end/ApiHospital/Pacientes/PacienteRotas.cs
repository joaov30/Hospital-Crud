using ApiHospital.Model;

namespace ApiHospital.Pacientes
{
    public static class PacienteRotas
    {
        public static void AddPacientesRotas(this WebApplication app)
        {
            //app.MapGet("pacientes", () => "Lista de Pacientes: ");

            app.MapGet("pacientes", () => new Paciente("Frederico", "20-04-1978", "M", "Rua do Coqueiro","2140028922", "fred@gmail.com"));
        }
    }
}
