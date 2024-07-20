using ManageApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ManageApi.Interfaces
{
    public interface IManageService
    {
        Task<IEnumerable<Manage>> GetManagesAsync();
        Task<Manage> GetManageByIdAsync(int id);
        Task<Manage> CreateManageAsync(Manage manage);
        Task<bool> UpdateManageAsync(int id, Manage manage);
        Task<bool> DeleteManageAsync(int id);
    }
}