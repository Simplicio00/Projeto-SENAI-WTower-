using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WTower.WebApi.Contexts;
using WTower.WebApi.Domains;
using WTower.WebApi.Repositories.Abstraction;

namespace WTower.WebApi.Repositories
{
	public class PartidaRepository : IPartida
	{
		WebApiBDContext dbcontext = new WebApiBDContext();

		public async Task<List<Jogo>> OrdDataPartidas() => await dbcontext.Jogo.OrderBy(a => a.Data)
				.Include(a => a.SelecaoCasaNavigation)
				.Include(a => a.SelecaoVisitanteNavigation).ToListAsync();

		public async Task<List<Jogo>> OrdDataPartidasExato(DateTime data) => 
			await dbcontext.Jogo.Where(a => a.Data.Value.Date == data.Date).ToListAsync();
		

		public async Task<List<Jogo>> OrdEstadioOrdSelecao(string param) =>
			await dbcontext.Jogo.AsQueryable().
			Where(a => WebApiBDContext.SoundsLike(a.Estadio) == WebApiBDContext.SoundsLike(param) ||
				WebApiBDContext.SoundsLike(a.SelecaoCasaNavigation.Nome) == WebApiBDContext.SoundsLike(param)
				).Include(a => a.SelecaoCasaNavigation).Include(a => a.SelecaoVisitanteNavigation).ToListAsync();
		
	}
}
