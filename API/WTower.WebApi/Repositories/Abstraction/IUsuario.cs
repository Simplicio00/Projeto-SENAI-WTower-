using System.Collections.Generic;
using System.Threading.Tasks;
using WTower.WebApi.Domains;
using WTower.WebApi.Domains.ViewModel;

namespace WTower.WebApi.Repositories.Abstraction
{
	interface IUsuario
	{
		Task<List<Usuario>> Get();

		Task<Usuario> CadastroUsuario(Usuario usuario);

		Task<Usuario> GetConfig(int id);

		Task<Usuario> Login(string info, string senha);

		Task<Usuario> Update(UpdateUserViewModel usuario, int id);
	}
}
