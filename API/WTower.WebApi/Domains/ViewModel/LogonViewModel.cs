using System.ComponentModel.DataAnnotations;


namespace WTower.WebApi.Domains.ViewModel
{
	public class LogonViewModel
	{
		[Required(ErrorMessage = "Informe o seu email ou apelido para fazer logon")]
		public string Info { get; set; }

		[Required(ErrorMessage = "Informe a sua senha para fazer logon")]
		public string Senha { get; set; }

	}
}
