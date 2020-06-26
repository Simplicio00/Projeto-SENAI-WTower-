using System.ComponentModel.DataAnnotations;

namespace WTower.WebApi.Domains.ViewModel
{
	public class UpdateUserViewModel
	{
        [StringLength(30, MinimumLength = 3, ErrorMessage = "O campo precisa ter no mínimo 3 caracteres e máximo 30")]
        public string? Nome { get; set; }

        [DataType(DataType.EmailAddress)]
        [StringLength(30, MinimumLength = 5, ErrorMessage = "O campo precisa ter no mínimo 5 caracteres e máximo 30")]
        public string? Email { get; set; }

        [StringLength(10, MinimumLength = 3, ErrorMessage = "O campo precisa ter no mínimo 3 caracteres e máximo 10")]
        public string? Apelido { get; set; }

        [DataType(DataType.Password)]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "O campo precisa ter no mínimo 3 caracteres e máximo 10")]
        public string? Senha { get; set; }
    }
}
