using System.Collections.Generic;
using System.Threading.Tasks;
using WTower.WebApi.Domains;

namespace WTower.WebApi.Repositories.Abstraction
{
	interface IJogador
	{
		Task<List<Jogador>> ListaJogPorSelecao(string selecao);

		Task<List<Jogador>> ListaJogPorNome(string nome);

	}
}
