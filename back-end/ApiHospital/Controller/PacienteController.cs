using ApiHospital.Data;
using ApiHospital.Model;
using Microsoft.EntityFrameworkCore;

namespace ApiHospital.Controller
{
    public static class PacienteController
    {
        public static void PacienteRotas(this WebApplication app)
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
                    return Results.NotFound("Paciente Não Encontrado");
                }
                return Results.Ok(pacienteExistente);
            });


            //Alterar Dados de Um Paciente
            pacientesRotas.MapPut("/{id}", async (Guid id, PacienteRequest request ,AppDbContext context) =>
            {
                var pacienteEncontrado = await context.Pacientes.FindAsync(id);

                if (pacienteEncontrado == null)
                {
                    return Results.NotFound("Id Não Encontrado");
                }
                pacienteEncontrado.Nome = request.nome;
                pacienteEncontrado.DataNascimento = request.dataNascimento;
                pacienteEncontrado.Genero = request.genero;
                pacienteEncontrado.Endereco = request.endereco;
                pacienteEncontrado.Telefone = request.telefone;
                pacienteEncontrado.Email = request.email;

                await context.SaveChangesAsync();
                return Results.Ok();
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
