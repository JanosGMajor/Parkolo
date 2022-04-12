using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Parkolo.Data;
using Parkolo.Models;

namespace Parkolo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KeszletesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public KeszletesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Keszletes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Keszlet>>> GetKeszlet()
        {
            return await _context.Keszlet.ToListAsync();
        }

        // GET: api/Keszletes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Keszlet>> GetKeszlet(int id)
        {
            var keszlet = await _context.Keszlet.FindAsync(id);

            if (keszlet == null)
            {
                return NotFound();
            }

            return keszlet;
        }

        // PUT: api/Keszletes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutKeszlet(int id, Keszlet keszlet)
        {
            if (id != keszlet.Id)
            {
                return BadRequest();
            }

            _context.Entry(keszlet).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KeszletExists(id))
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

        // POST: api/Keszletes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Keszlet>> PostKeszlet(Keszlet keszlet)
        {
            _context.Keszlet.Add(keszlet);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetKeszlet", new { id = keszlet.Id }, keszlet);
        }

        // DELETE: api/Keszletes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteKeszlet(int id)
        {
            var keszlet = await _context.Keszlet.FindAsync(id);
            if (keszlet == null)
            {
                return NotFound();
            }

            _context.Keszlet.Remove(keszlet);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool KeszletExists(int id)
        {
            return _context.Keszlet.Any(e => e.Id == id);
        }
    }
}
