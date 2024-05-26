using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using silliconValley.Data;
using silliconValley.Integration.jsonplaceholder;
using silliconValley.Integration.jsonplaceholder.dto;
using silliconValley.Models;



namespace silliconValley.Controllers
{
   
    public class UsuarioController : Controller
    {
        private readonly ILogger<UsuarioController> _logger;
        private object apiUsers;
        private readonly ApplicationDbContext _context;

        public UsuarioController(ILogger<UsuarioController> logger,ApplicationDbContext context)
        {
            _logger = logger;
                       _context = context;
        }
         public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult EnviarMensaje(ApiUser objapiuser)
        {
            _logger.LogDebug("Ingreso a Enviar Mensaje");

            //Se registran los datos del objeto a la base datos
            _context.Add(objapiuser);
            _context.SaveChanges();

            ViewData["Message"] = "Se registro el Usuario";
            return View("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}
    