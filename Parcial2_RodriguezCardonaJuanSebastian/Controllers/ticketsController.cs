using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Parcial2_RodriguezCardonaJuanSebastian.DAL;
using Parcial2_RodriguezCardonaJuanSebastian.DAL.Entities;

namespace Parcial2_RodriguezCardonaJuanSebastian.Controllers
{
    public class ticketsController : Controller
    {
        private readonly DatabaseContext _context;

        public ticketsController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: tickets
        public async Task<IActionResult> Index()
        {
              return _context.tickets != null ? 
                          View(await _context.tickets.ToListAsync()) :
                          Problem("Entity set 'DatabaseContext.tickets'  is null.");
        }

        // GET: tickets/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.tickets == null)
            {
                return NotFound();
            }

            var ticket = await _context.tickets
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ticket == null)
            {
                return NotFound();
            }

            return View(ticket);
        }

        // GET: tickets/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: tickets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UseData,IsUsed,EntranceGate")] ticket ticket)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ticket);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ticket);
        }

        // GET: tickets/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.tickets == null)
            {
                return NotFound();
            }

            var ticket = await _context.tickets.FindAsync(id);
            if (ticket == null)
            {
                return NotFound();
            }
            return View(ticket);
        }

        // POST: tickets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UseData,IsUsed,EntranceGate")] ticket ticket)
        {
            if (id != ticket.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ticket);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ticketExists(ticket.Id))
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
            return View(ticket);
        }

        // GET: tickets/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.tickets == null)
            {
                return NotFound();
            }

            var ticket = await _context.tickets
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ticket == null)
            {
                return NotFound();
            }

            return View(ticket);
        }

        // POST: tickets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.tickets == null)
            {
                return Problem("Entity set 'DatabaseContext.tickets'  is null.");
            }
            var ticket = await _context.tickets.FindAsync(id);
            if (ticket != null)
            {
                _context.tickets.Remove(ticket);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ticketExists(int id)
        {
          return (_context.tickets?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
