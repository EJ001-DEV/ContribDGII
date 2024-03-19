using adm_impuestos.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace adm_impuestos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContribuyentesListController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ContribuyentesListController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/ContribuyentesList
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Contribuyente>>> GetContribuyentes()
        {
            return await _context.Contribuyentes.ToListAsync();
        }

        // GET: api/ContribuyentesList/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Contribuyente>> GetContribuyente(int id)
        {
            var contribuyente = await _context.Contribuyentes.FindAsync(id);

            if (contribuyente == null)
            {
                return NotFound();
            }

            return contribuyente;
        }

        // POST: api/ContribuyentesList
        [HttpPost]
        public async Task<ActionResult<Contribuyente>> PostContribuyente(Contribuyente contribuyente)
        {
            _context.Contribuyentes.Add(contribuyente);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetContribuyente), new { id = contribuyente.CodContrib }, contribuyente);
        }

        // PUT: api/ContribuyentesList/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutContribuyente(int id, Contribuyente contribuyente)
        {
            if (id != contribuyente.CodContrib)
            {
                return BadRequest();
            }

            _context.Entry(contribuyente).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContribuyenteExists(id))
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

        private bool ContribuyenteExists(int id)
        {
            return _context.Contribuyentes.Any(e => e.CodContrib == id);
        }

    }
}
