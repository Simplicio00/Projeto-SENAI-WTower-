using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.JsonWebTokens;
using WTower.WebApi.Domains;
using WTower.WebApi.Domains.ViewModel;
using WTower.WebApi.Repositories;

namespace WTower.WebApi.Controllers
{
	[Produces("application/json")]
	[Route("[controller]")]
	[ApiController]
	[Authorize]
	public class UsuarioController : ControllerBase
	{
		UsuarioRepository _dbuser = new UsuarioRepository();


		/// <summary>
		/// Consulta as informações do usuário logado
		/// </summary>
		/// <returns>Retorna as informações do usuário logado</returns>
		[HttpGet]
		public async Task<IActionResult> Get() => Ok(
			await _dbuser.GetConfig(Convert.ToInt32(
				HttpContext.User.Claims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.Jti).Value)));



		/// <summary>
		/// Cadastro de usuário por formulário.
		/// O Cadastro será feito pelo Form-data, requerindo a inserção de um arquivo de imagem para o campo "foto"
		/// </summary>
		/// <param name="usuario">Objeto usuário a ser cadastrado</param>
		/// <returns>Retorna a confirmação do cadastro</returns>
		[AllowAnonymous]
		[HttpPost("Cadastrar")]
		public async Task<IActionResult> Cadastro(/*[FromForm]*/ Usuario usuario)
		{
			var lista = await _dbuser.Get();

			//usuario.Email = Request.Form["email"].ToString();
			//usuario.Nome = Request.Form["nome"].ToString();
			//usuario.Apelido = Request.Form["apelido"].ToString();
			//usuario.Senha = Request.Form["senha"].ToString();

			//if (Request.Form.Files["foto"] == null) 
			//	return BadRequest(new { msgerr = "Insira uma imagem" });
			
			//using (var stream = new MemoryStream())
			//{
			//	var foto = Request.Form.Files["foto"].CopyToAsync(stream);
			//	usuario.Foto = stream.ToArray();
			//}

			//if (usuario.Foto.Length > 1000000) 
			//	return BadRequest(new { msgerr = "Imagem demasiadamente grande" });


			if (!lista.Exists(a => a.Email == usuario.Email) && !lista.Exists(a => a.Apelido == usuario.Apelido))
			{
				await _dbuser.CadastroUsuario(usuario);
				return StatusCode(201, new { msgsucesso = "usuário cadastrado com sucesso!" });
			}

			return BadRequest(new { msgerr = "Email ou apelido já estão cadastrados" });
		}


		/// <summary>
		///		Atualização das informações do usuário (é necessário estar logado para realizar alterações).
		///		É possível alterar Nome, E-Mail, Senha e Apelido, sendo um atributo por vez ou vários duma vez.
		/// </summary>
		/// <param name="usuario">Representa o objeto dos campos sujeitos á alteração</param>
		/// <returns>Retorna uma confirmação de que a alteração foi bem sucedida para o usuário</returns>
		[HttpPut]
		public async Task<IActionResult> AtualizarUsr(UpdateUserViewModel usuario)
		{
			var usr = Convert.ToInt32(HttpContext.User.Claims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.Jti).Value);
			await _dbuser.Update(usuario, usr);

			return StatusCode(200, new { msgsucess = "Atualização completada com sucesso" });
		}

	}
}
