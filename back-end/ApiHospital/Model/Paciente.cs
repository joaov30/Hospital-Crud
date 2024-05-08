using System;
using System.ComponentModel.DataAnnotations;

namespace ApiHospital.Model
{
    public class Paciente
    {
        public Guid Id { get; init; }

        [Required(ErrorMessage = "O nome do paciente é obrigatório.")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "O nome do paciente deve ter entre 2 e 100 caracteres.")]
        public string Nome { get; init; }

        [Required(ErrorMessage = "A data de nascimento do paciente é obrigatória.")]
        [DataType(DataType.Date)]
        public string DataNascimento { get; set; }

        [Required(ErrorMessage = "O gênero do paciente é obrigatório.")]
        public string Genero { get; set; }

        [StringLength(200, ErrorMessage = "O endereço do paciente não pode ter mais de 200 caracteres.")]
        public string Endereco { get; set; }

        [StringLength(20, ErrorMessage = "O número de telefone do paciente não pode ter mais de 20 caracteres.")]
        public string Telefone { get; set; }

        [EmailAddress(ErrorMessage = "O email do paciente não é válido.")]
        public string Email { get; set; }

        public Paciente(string nome, string dataNascimento, string genero, string endereco, string telefone, string email)
        {
            Id = Guid.NewGuid();
            Nome = nome;
            DataNascimento = dataNascimento;
            Genero = genero;
            Endereco = endereco;
            Telefone = telefone;
            Email = email;
        }
    }
}
