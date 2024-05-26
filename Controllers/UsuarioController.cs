using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Framework;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using silliconValley.Data;
using silliconValley.Models;
using silliconValley.Service;



namespace silliconValley.Controllers
{
   
    public class UsuarioController : Controller
    {
        private readonly ILogger<UsuarioController> _logger;       private readonly ApplicationDbContext _context;
        private readonly USuarioService _usuarioService;

        public UsuarioController(ILogger<UsuarioController> logger,ApplicationDbContext context, USuarioService usuarioService)
        {
              _logger = logger;
            _context = context;
            _usuarioService = usuarioService;
          
        }
       public async Task<IActionResult> Index()
        {
            var apiUsers = await _usuarioService.GetAll();
            return apiUsers != null ?
                        View(apiUsers) :
                        Problem("Entity set 'ApplicationDbContext.DataUsuario'  is null.");
        }
 public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var apiUser = await _context.DataUsuario
                .FirstOrDefaultAsync(m => m.id == id);
            if (apiUser == null)
            {
                return NotFound();
            }

            return View(apiUser);
        }
public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
          [ValidateAntiForgeryToken]
           public async Task<IActionResult> Create([Bind("id,first_name,last_name,job")] ApiUser apiUser)
        {
            if (ModelState.IsValid)
            {
                _context.Add(apiUser);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(apiUser);
        }
       public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var apiUser = await _context.DataUsuario.FindAsync(id);
            if (apiUser == null)
            {
                return NotFound();
            }
            return View(apiUser);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,first_name,last_name,job")] ApiUser apiUser)
        {
            if (id != apiUser.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(apiUser);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UsuarioExists(apiUser.id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(apiUser);
        }
         public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var apiUser = await _context.DataUsuario
                .FirstOrDefaultAsync(m => m.id == id);
            if (apiUser == null)
            {
                return NotFound();
            }

            return View(apiUser);
        }

       [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var apiUser = await _context.DataUsuario.FindAsync(id);
            if (apiUser != null)
            {
                _context.DataUsuario.Remove(apiUser);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UsuarioExists(int id)
        {
            return _context.DataUsuario.Any(e => e.id == id);
        }
    }
}

    