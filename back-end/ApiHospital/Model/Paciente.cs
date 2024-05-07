namespace ApiHospital.Model
{
    public class Paciente
    {
        public Guid Id { get; init; }

        public string Nome { get; init; }

        public string DataNascimento { get; set; }

        public string Genero { get; set; }

        public string Endereco { get; set; }

        public string Telefone { get; set; }

        public string Email { get; set; }
    }
}
