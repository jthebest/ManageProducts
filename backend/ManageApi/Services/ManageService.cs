// Services/ManageService.cs
using ManageApi.Data;
using ManageApi.Interfaces;
using ManageApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<IEnumerable<Manage>> GetManages()
        {
            return await _context.Manages.ToListAsync();
        }

        public async Task<Manage> GetManage(long id)
        {
            return await _context.Manages.FindAsync(id);
        }

        public async Task<Manage> CreateManage(Manage manage)
        {
            _context.Manages.Add(manage);
            await _context.SaveChangesAsync();
            return manage;
        }

        public async Task UpdateManage(long id, Manage manage)
        {
            _context.Entry(manage).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteManage(long id)
        {
            var manage = await _context.Manages.FindAsync(id);
            if (manage != null)
            {
                _context.Manages.Remove(manage);
                await _context.SaveChangesAsync();
            }
        }
    }
}
