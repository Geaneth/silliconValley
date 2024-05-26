using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using silliconValley.Data;
using silliconValley.Models;


namespace silliconValley.Service
{
    public class USuarioService
    {
         private readonly ILogger<USuarioService> _logger;
        private readonly ApplicationDbContext _context;

        public USuarioService(ILogger<USuarioService> logger,ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<List<ApiUser>?> GetAll(){
            if(_context.DataUsuario == null )
                return null;
            return await _context.DataUsuario.ToListAsync();
        }
    }
    }
