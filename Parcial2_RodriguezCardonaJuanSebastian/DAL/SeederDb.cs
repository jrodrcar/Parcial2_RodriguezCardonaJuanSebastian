using Microsoft.EntityFrameworkCore;
using Parcial2_RodriguezCardonaJuanSebastian.DAL.Entities;

namespace Parcial2_RodriguezCardonaJuanSebastian.DAL
{
    public class SeederDb
    {
        private readonly DatabaseContext _context;

        public SeederDb(DatabaseContext context)
        {
            _context = context;
        }
        public async Task SeederAsync()
        {
            await _context.Database.EnsureCreatedAsync(); // me reemplaza el comando update-database
            await CreateTickets();
            await _context.SaveChangesAsync();
        }

        private async Task CreateTickets()
        {
            if (!_context.tickets.Any())
            {
                for (int i = 0; i < 50000; i++)
                {
                    _context.tickets.Add(new ticket { IsUsed = false, EntranceGate = null, UseData = null });                   
                }
            }
        }
    }
}
