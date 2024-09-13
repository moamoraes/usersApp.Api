using Microsoft.AspNetCore.Mvc;
using UsersApp.Application.Services;
using UsersApp.Application.ViewModels;

namespace UsersApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        // POST: api/user
        [HttpPost]
        public async Task<IActionResult> InserirUsuario([FromBody] UserViewModel userViewModel)
        {
            var sucesso = await _userService.AddUserAsync(userViewModel);
            if (sucesso)
            {
                return Ok(new { message = "Usuário inserido com sucesso." });
            }
            return BadRequest(new { message = "Falha ao inserir o usuário." });
        }

        // PUT: api/user/{cpf}
        [HttpPut("{cpf}")]
        public async Task<IActionResult> AtualizarUsuario(string cpf, [FromBody] UserViewModel userViewModel)
        {
            var sucesso = await _userService.UpdateUserAsync(cpf, userViewModel);
            if (sucesso)
            {
                return Ok(new { message = "Usuário atualizado com sucesso." });
            }
            return NotFound(new { message = "Usuário não encontrado." });
        }

        // DELETE: api/user/{cpf}
        [HttpDelete("{cpf}")]
        public async Task<IActionResult> ExcluirUsuario(string cpf)
        {
            var sucesso = await _userService.DeleteUserAsync(cpf);
            if (sucesso)
            {
                return Ok(new { message = "Usuário excluído com sucesso." });
            }
            return NotFound(new { message = "Usuário não encontrado." });
        }

        // GET: api/user/{cpf}
        [HttpGet("{cpf}")]
        public async Task<IActionResult> ObterUsuarioPorCpf(string cpf)
        {
            var usuario = await _userService.GetUserByCpfAsync(cpf);
            if (usuario != null)
            {
                return Ok(usuario);
            }
            return NotFound(new { message = "Usuário não encontrado." });
        }

        // GET: api/user
        [HttpGet]
        public async Task<IActionResult> ObterTodosUsuarios()
        {
            var usuarios = await _userService.GetAllUsersAsync();
            return Ok(usuarios);
        }
    }
}
