using adm_impuestos.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace adm_impuestos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComprobantesListController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public ComprobantesListController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/ComprobantesList
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EventoContribuyente>>> GetComprobantes()
        {
            return await _context.EventosContribuyente.ToListAsync();
        }
        /*
        // GET: api/ComprobantesList/1
        [HttpGet("{id}")]
        public async Task<ActionResult<EventoContribuyente>> GetComprobantes(int id)
        {
            var comprobantes = await _context.EventosContribuyente.FindAsync(id);

            if (comprobantes == null)
            {
                return NotFound();
            }

            return comprobantes;
        }*/

        // GET: api/ComprobantesList/CodContrib/1
        [HttpGet("CodContrib/{codContrib}")]
        public async Task<ActionResult<IEnumerable<EventoContribuyente>>> GetComprobantesByCodContrib(int codContrib)
        {
            var comprobantes = await _context.EventosContribuyente
                .Where(e => e.CodContrib == codContrib)
                .ToListAsync();

            if (!comprobantes.Any())
            {
                return NotFound();
            }

            return comprobantes;
        }

        private bool ComprobantesExists(int id)
        {
            return _context.EventosContribuyente.Any(e => e.CodContrib == id);
        }

    }
}
