using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WTower.WebApi.Repositories;

namespace WTower.WebApi.Controllers
{
	[Produces("application/json")]
	[Route("[controller]")]
	[ApiController]
	public class JogadoresController : ControllerBase
	{
		JogadorRepository dbjogador = new JogadorRepository();



		/// <summary>
		/// Listagem por nome. O parâmetro padrão é "all" para listar todos os jogadores por ordem de número da camisa e posição. 
		/// Caso queira procurar pelo nome, coloque o parâmetro como o nome do jogador buscado
		/// </summary>
		/// <param name="nome">Parâmetro que pode ser o nome do jogador buscado, ou listagem geral se colocada como "all"</param>
		/// <returns>Retorna uma lista com os jogadores requisitados</returns>
		[HttpGet("{nome}")]
		public async Task<IActionResult> ListarPorNome(string nome) => Ok( await dbjogador.ListaJogPorNome(nome));


		/// <summary>
		/// Listagem de jogadores que pertencem somente á uma seleção específica. 
		///  Ou se preferível generalizada por ordem alfabética de seleções o parâmetro padrão é "all" .
		/// </summary>
		/// <param name="selecao">Parâmetro que pode ser o nome da seleção, ou listagem geral de jogadores das seleções por ordem alfabética se colocada como "all"</param>
		/// <returns>Retorna uma lista com os jogadores requisitados</returns>
		[HttpGet("selecao/{selecao}")]
		public async Task<IActionResult> ListaPorSelecao(string selecao) => Ok(await dbjogador.ListaJogPorSelecao(selecao));
	}
}
