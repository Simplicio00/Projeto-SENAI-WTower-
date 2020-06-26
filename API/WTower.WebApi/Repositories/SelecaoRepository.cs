using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using WTower.WebApi.Contexts;
using WTower.WebApi.Domains;
using WTower.WebApi.Repositories.Abstraction;

namespace WTower.WebApi.Repositories
{
	public class SelecaoRepository : ISelecao
	{
		WebApiBDContext _dbcontext = new WebApiBDContext();

		public async Task<List<Selecao>> Get() => await _dbcontext.Selecao.ToListAsync();
		
	}
}
