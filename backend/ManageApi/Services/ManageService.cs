using ManageApi.Data;
using ManageApi.Interfaces;
using ManageApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ManageApi.Services
{
    public class ManageService : IManageService
    {
        private readonly ApplicationDbContext _context;

        public ManageService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Manage>> GetManagesAsync()
        {
            return await _context.Manages.ToListAsync();
        }

        public async Task<Manage> GetManageByIdAsync(int id)
        {
            return await _context.Manages.FindAsync(id);
        }

        public async Task<Manage> CreateManageAsync(Manage manage)
        {
            _context.Manages.Add(manage);
            await _context.SaveChangesAsync();
            return manage;
        }

        public async Task<bool> UpdateManageAsync(int id, Manage manage)
        {
            if (id != manage.Id)
                return false;

            _context.Entry(manage).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                return false;
            }
        }

        public async Task<bool> DeleteManageAsync(int id)
        {
            var manage = await _context.Manages.FindAsync(id);
            if (manage == null)
                return false;

            _context.Manages.Remove(manage);
            await _context.SaveChangesAsync();
            return true;
        }

        // Add additional methods as needed for managing manages
    }
}
