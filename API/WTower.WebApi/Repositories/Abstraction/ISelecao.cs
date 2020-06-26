using System.Collections.Generic;
using System.Threading.Tasks;
using WTower.WebApi.Domains;

namespace WTower.WebApi.Repositories.Abstraction
{
	interface ISelecao
	{
		Task<List<Selecao>> Get();
	}
}
