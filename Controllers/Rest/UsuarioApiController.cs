using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using silliconValley.Data;
using silliconValley.Integration;
using silliconValley.Models;
using silliconValley.Service;

namespace silliconValley.Controllers.Rest
{
    [ApiController]
    [Route("api/Usuario")]
    public class UsuarioApiController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly USuarioService _usuarioService;
        private readonly listarUsuario _listarUsuario;
        public UsuarioApiController(ApplicationDbContext context,USuarioService usuarioService,listarUsuario listarUsuarios)
        {
            _context = context;
            _usuarioService = usuarioService;
            _listarUsuario = listarUsuarios;
        }

 [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
         public async Task<ActionResult<List<ApiUser>>> List()
        {
            var apiUsers = await _usuarioService.GetAll();
            if(apiUsers == null)
                return NotFound();
            return Ok(apiUsers);
        }
        public async Task<ActionResult<IEnumerable<ApiUser>>> GetUsuarios()
        {
            return await _context.DataUsuario.ToListAsync();
            
        }
          [HttpGet("{id}")]
        public async Task<ActionResult<ApiUser>> GetUsuario(int id)
        {
            var apiUser = await _context.DataUsuario.FindAsync(id);
           

            if (apiUser == null)
            {
                return NotFound();
            }

            return apiUser;
        }
[HttpPut("{id}")]
        public async Task<IActionResult> PutUsuario(int id, ApiUser apiUser)
        {
            if (id != apiUser.id)
            {
                return BadRequest();
            }

            _context.Entry(apiUser).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsuarioExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }
         public async Task<IActionResult> DeleteUsuario(int id)
        {
            var ApiUser = await _context.DataUsuario.FindAsync(id);
            if (ApiUser == null)
            {
                return NotFound();
            }

            _context.DataUsuario.Remove(ApiUser);
            await _context.SaveChangesAsync();

            return NoContent();
        }
         private bool UsuarioExists(int id)
        {
            return _context.DataUsuario.Any(e => e.id == id);
        }

    }
}