namespace ApiHospital.Pacientes
{
    public static class PacienteRotas
    {
        public static void AddPacientesRotas(this WebApplication app)
        {
            app.MapGet("pacientes", () => "Lista de Pacientes: ");
        }
    }
}
