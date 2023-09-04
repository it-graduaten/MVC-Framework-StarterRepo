using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using _09_00_HelloCore.Data;
using _09_00_HelloCore.Models;

namespace _09_00_HelloCore.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class BestellingController : ControllerBase
    {
        private readonly HelloCoreContext _context;

        public BestellingController(HelloCoreContext context)
        {
            _context = context;
        }

        // GET: api/Bestelling
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Bestelling>>> GetBestellingen()
        {
          if (_context.Bestellingen == null)
          {
              return NotFound();
          }
            return await _context.Bestellingen
                .Include(x=>x.klant)
                .Include(x=>x.orderlijnen)
                .ThenInclude(x=>x.product)
                .ToListAsync();
        }

        // GET: api/Bestelling/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Bestelling>> GetBestelling(int id)
        {
          if (_context.Bestellingen == null)
          {
              return NotFound();
          }
            var bestelling = await _context.Bestellingen.FindAsync(id);

            if (bestelling == null)
            {
                return NotFound();
            }

            return bestelling;
        }

        // PUT: api/Bestelling/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBestelling(int id, Bestelling bestelling)
        {
            if (id != bestelling.BestellingID)
            {
                return BadRequest();
            }

            _context.Entry(bestelling).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BestellingExists(id))
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

        // POST: api/Bestelling
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Bestelling>> PostBestelling(Bestelling bestelling)
        {
          if (_context.Bestellingen == null)
          {
              return Problem("Entity set 'HelloCoreContext.Bestellingen'  is null.");
          }
            _context.Bestellingen.Add(bestelling);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBestelling", new { id = bestelling.BestellingID }, bestelling);
        }

        // DELETE: api/Bestelling/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBestelling(int id)
        {
            if (_context.Bestellingen == null)
            {
                return NotFound();
            }
            var bestelling = await _context.Bestellingen.FindAsync(id);
            if (bestelling == null)
            {
                return NotFound();
            }

            _context.Bestellingen.Remove(bestelling);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet("lijst")]
        public async Task<ActionResult<IEnumerable<Bestelling>>> GetBestellingenLijst()
        {
            return await _context.Bestellingen.ToListAsync();
        }
        private bool BestellingExists(int id)
        {
            return (_context.Bestellingen?.Any(e => e.BestellingID == id)).GetValueOrDefault();
        }
    }
}
