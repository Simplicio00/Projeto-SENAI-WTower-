using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WTower.WebApi.Repositories;

namespace WTower.WebApi.Controllers
{
	[Produces("application/json")]
	[Route("[controller]")]
	[ApiController]
	public class SelecoesController : ControllerBase
	{
		SelecaoRepository _dbselecao = new SelecaoRepository();


		/// <summary>
		/// Faz a listagem de todas as seleções 
		/// </summary>
		/// <returns>Retorna uma lista com as seleções participantes</returns>
		[HttpGet]
		public async Task<IActionResult> Get() => Ok( await _dbselecao.Get());
	}
}
