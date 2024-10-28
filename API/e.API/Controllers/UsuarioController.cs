using e.Domain.Entities;
using e.Domain.IRepositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace e.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository _repository;

        public UsuarioController(IUsuarioRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usuario>>> Get()
        {
            var usuarios = await _repository.Get();
            return usuarios == null ? NotFound("Lista de Usuários não encontrados no momento.") : Ok(usuarios);
        }

        
        [HttpGet("GetOneToOne/{id:int}")]
        public async Task<ActionResult<Usuario>> GetOneToOne(int id)
        {
            var usuarioById = await _repository.GetByIdOneToOne(id);
            return usuarioById == null ? NotFound("Usuário não encontrados no momento.") : Ok(usuarioById);
        }
        
        [HttpGet("GetOneToMany/{id:int}")]
        public async Task<ActionResult<Usuario>> GetOneToMany(int id)
        {
            var usuarioById = await _repository.GetByIdOneToMany(id);
            return usuarioById == null ? NotFound("Usuário não encontrados no momento.") : Ok(usuarioById);
        }
    }
}
