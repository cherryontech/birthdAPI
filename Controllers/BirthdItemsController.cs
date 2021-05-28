using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BirthdAPI.Models;

namespace BirthdAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BirthdItemsController : ControllerBase
    {
        private readonly BirthdContext _context;

        public BirthdItemsController(BirthdContext context)
        {
            _context = context;
        }

        // GET: api/BirthdItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BirthdItem>>> GetBirthdItems()
        {
            return await _context.BirthdItems.ToListAsync();
        }

        // GET: api/BirthdItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BirthdItem>> GetBirthdItem(long id)
        {
            var birthdItem = await _context.BirthdItems.FindAsync(id);

            if (birthdItem == null)
            {
                return NotFound();
            }

            return birthdItem;
        }

        // PUT: api/BirthdItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBirthdItem(long id, BirthdItem birthdItem)
        {
            if (id != birthdItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(birthdItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BirthdItemExists(id))
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

        // POST: api/BirthdItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BirthdItem>> PostBirthdItem(BirthdItem birthdItem)
        {
            _context.BirthdItems.Add(birthdItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBirthdItem", new { id = birthdItem.Id }, birthdItem);
        }

        // DELETE: api/BirthdItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBirthdItem(long id)
        {
            var birthdItem = await _context.BirthdItems.FindAsync(id);
            if (birthdItem == null)
            {
                return NotFound();
            }

            _context.BirthdItems.Remove(birthdItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BirthdItemExists(long id)
        {
            return _context.BirthdItems.Any(e => e.Id == id);
        }
    }
}
