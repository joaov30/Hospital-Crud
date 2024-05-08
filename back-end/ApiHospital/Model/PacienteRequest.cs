namespace ApiHospital.Model
{
    public record PacienteRequest(string nome, string dataNascimento, string genero, string endereco, string telefone, string email);
}
