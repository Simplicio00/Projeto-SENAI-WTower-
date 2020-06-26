using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WTower.WebApi.Repositories;

namespace WTower.WebApi.Controllers
{
	[Produces("application/json")]
	[Route("[controller]")]
	[ApiController]
	public class PartidasController : ControllerBase
	{
		private readonly PartidaRepository _dbpartida = new PartidaRepository();


		/// <summary>
		/// Ordenando todas as partidas existentes por data 
		/// </summary>
		/// <returns>Lista com todas as partidas com suas datas</returns>
		[HttpGet]
		public async Task<IActionResult> OrdPartidaPorData() => Ok( await _dbpartida.OrdDataPartidas());


		/// <summary>
		/// Ordenando partidas por uma data específica 
		/// </summary>
		/// <param name="parametro">Data específica para ser filtrada</param>
		/// <example> Dia, mês e ano --- dd-mm-aaaa </example>
		/// <returns>Retorna todas as partidas da data selecionada</returns>
		[HttpGet("{parametro}")]
		public async Task<IActionResult> OrdenarPorDataExata(string parametro)
		{
			DateTime date = DateTime.Parse(parametro);
			return Ok(await _dbpartida.OrdDataPartidasExato(date));
		}

		/// <summary>
		/// Faz a pesquisa das partidas pelo nome do estádio ou seleção
		/// </summary>
		/// <param name="parametro">Nome do estadio ou seleção para a busca</param>
		/// <returns>Retorna uma lista com as partidas do qual o parâmetro está presente</returns>
		[HttpGet("pesquisa/{parametro}")]
		public async Task<IActionResult> BuscarPorEstadioOrSelecao(string parametro) => Ok( await _dbpartida.OrdEstadioOrdSelecao(parametro));
	}
}
