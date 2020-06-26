using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WTower.WebApi.Domains;

namespace WTower.WebApi.Repositories.Abstraction
{
	 public interface IPartida
	{
		//Ordenando partidas pela data mais recente
		Task<List<Jogo>> OrdDataPartidas();

		//Filtrando pela data
		Task<List<Jogo>> OrdDataPartidasExato(DateTime data);


		//Filtrando pelo estádio ou seleção
		//Task<List<Jogo>> OrdEstadioOrdSelecao(string? param);

		Task<List<Jogo>> OrdEstadioOrdSelecao(string? param);

	}
}
