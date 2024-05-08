using ApiHospital.Data;
using ApiHospital.Model;

namespace ApiHospital.Controller
{
    public static class PacienteController
    {
        public static void AddPacienteController(this WebApplication app)
        {
            var pacientesRotas = app.MapGroup("pacientes");
            

            //Criar um novo Cadastro de Paciente
            pacientesRotas.MapPost("", async (PacienteRequest request, AppDbContext context) =>
            {
                var novoPaciente = new Paciente(request.nome, request.dataNascimento, request.genero, request.endereco, request.telefone, request.email);

                await context.Pacientes.AddAsync(novoPaciente);
                await context.SaveChangesAsync();
            });

            //retornar Todos
          

           
            
        }
    }
}
