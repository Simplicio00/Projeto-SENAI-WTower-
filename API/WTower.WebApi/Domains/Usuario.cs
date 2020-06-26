using System.ComponentModel.DataAnnotations;

namespace WTower.WebApi.Domains
{
    public partial class Usuario
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Informe o seu nome")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "O campo precisa ter no mínimo 3 caracteres e máximo 30")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Informe o seu email")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "O campo precisa ter no mínimo 3 caracteres e máximo 30")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Informe o seu apelido")]
        [StringLength(10, MinimumLength = 3, ErrorMessage = "O campo precisa ter no mínimo 3 caracteres e máximo 10")]
        public string Apelido { get; set; }


        public byte[] Foto { get; set; }

        
        [Required(ErrorMessage = "Informe a senha")]
        [StringLength(10, MinimumLength = 3, ErrorMessage = "O campo precisa ter no mínimo 3 caracteres e no máximo 10")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }
    }
}
