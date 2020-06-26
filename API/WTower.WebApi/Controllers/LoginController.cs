using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using WTower.WebApi.Domains.ViewModel;
using WTower.WebApi.Repositories;

namespace WTower.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        UsuarioRepository _dbuser = new UsuarioRepository();

        /// <summary>
        /// Faz a autenticação do usuário no sistema, exigindo o campo senha (Senha) e info (E-Mail ou Apelido) para serem preenchidos.
        /// </summary>
        /// <param name="login">Armazena as credenciais para a autenticação do usuário</param>
        /// <returns>Retorna um token de autenticação</returns>
        /// 
		[HttpPost]
		public async Task<IActionResult> Login(LogonViewModel login)
		{
			var usuario = await _dbuser.Login(login.Info, login.Senha);

			if (usuario != null)
			{

                var claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Email, usuario.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, usuario.Id.ToString()),
                };

                var chave = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("keyteste019104934"));
                var credencial = new SigningCredentials(chave, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    issuer: "WTower.WebApi",
                    audience: "WTower.WebApi",
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(30),
                    signingCredentials: credencial
                    );

                return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token) });
            }

            return NotFound(new { msgerr = "Não foi possível fazer login, verifique as suas credenciais e tente novamente" });
        }

	}
}
