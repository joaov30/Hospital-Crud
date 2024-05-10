using ApiHospital.Data;
using ApiHospital.Model;
using Microsoft.EntityFrameworkCore;

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
            pacientesRotas.MapGet("", async (AppDbContext context) =>
            {
                var pacientes = await context.Pacientes.ToListAsync();
                return Results.Ok(pacientes);
            });


            //retornar um paciente em especifico
            pacientesRotas.MapGet("/{id}", async (Guid id, AppDbContext context) =>
            {
                var pacienteExistente = await context.Pacientes.FindAsync(id);

                if(pacienteExistente == null)
                {
                    return Results.NotFound();
                }
                return Results.Ok(pacienteExistente);
            });



            //Deletar Paciente
            pacientesRotas.MapDelete("/{id}", async (Guid id, AppDbContext context) =>
            {
                var pacienteExiste = await context.Pacientes.FindAsync(id);

                if(pacienteExiste == null)
                {
                    return Results.NotFound();
                }
                 context.Pacientes.Remove(pacienteExiste);
                await context.SaveChangesAsync();
                return Results.Ok();
            });
           
            
        }
    }
}
