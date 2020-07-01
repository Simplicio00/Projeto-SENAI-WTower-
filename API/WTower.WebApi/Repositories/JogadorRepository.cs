using Microsoft.AspNetCore.Mvc;
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
	public class JogadorRepository : IJogador
	{
		WebApiBDContext dbcontext = new WebApiBDContext();


		public async Task<List<Jogador>> ListaJogPorNome(string nome)
		{
			if (nome == "all") return await dbcontext.Jogador.OrderBy(a => a.NumeroCamisa).OrderBy(a => a.Posicao).ToListAsync();

			return await dbcontext.Jogador.AsQueryable().
				Where(a => WebApiBDContext.SoundsLike(a.Nome) == WebApiBDContext.SoundsLike(nome))
				.OrderBy(a => a.NumeroCamisa)
				.OrderBy(a => a.Posicao)
				.ToListAsync();
		}

		public async Task<List<Jogador>> ListaJogPorSelecao(string selecao)
		{
			if (selecao == "all") return await dbcontext.Jogador.OrderBy(a => a.Selecao).ToListAsync();

			return await dbcontext.Jogador.AsQueryable()
				.Where(a => WebApiBDContext.SoundsLike(a.Selecao.Nome) == WebApiBDContext.SoundsLike(selecao)).
				OrderBy(a => a.Selecao.Nome)
				.ToListAsync();
		}
	}
}
