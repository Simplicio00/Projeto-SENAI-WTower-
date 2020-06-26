using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WTower.WebApi.Contexts;
using WTower.WebApi.Domains;
using WTower.WebApi.Domains.ViewModel;
using WTower.WebApi.Repositories.Abstraction;

namespace WTower.WebApi.Repositories
{
	public class UsuarioRepository : IUsuario
	{
		WebApiBDContext bdContext = new WebApiBDContext();


		public async Task<Usuario> CadastroUsuario(Usuario usuario)
		{
			await bdContext.Usuario.AddAsync(usuario);
			await bdContext.SaveChangesAsync();
			return usuario;
		}

		public async Task<List<Usuario>> Get() => await bdContext.Usuario.ToListAsync();


		public async Task<Usuario> GetConfig(int id) => await bdContext.Usuario.FirstOrDefaultAsync(a => a.Id == id);



		public async Task<Usuario> Login(string info, string senha)
		{
			var usr = await bdContext.Usuario.FirstOrDefaultAsync(a => a.Email == info && a.Senha == senha);

			if (usr != null) return usr;

			usr = await bdContext.Usuario.FirstOrDefaultAsync(a => a.Apelido == info && a.Senha == senha);

			if (usr != null) return usr;

			return null;

		}



		public async Task<Usuario> Update(UpdateUserViewModel usuario, int id)
		{
			var usr = await bdContext.Usuario.FirstOrDefaultAsync(a => a.Id == id);

			if (usuario.Nome != null)
			{
				usr.Nome = usuario.Nome;
			}
			if (usuario.Email != null)
			{
				usr.Email = usuario.Email;
			}
			if (usuario.Apelido != null)
			{
				usr.Apelido = usuario.Apelido;
			}
			if (usuario.Senha != null)
			{
				usr.Senha = usuario.Senha;
			}

			bdContext.Update(usr);
			await bdContext.SaveChangesAsync();

			return usr;
		}
	}
}
