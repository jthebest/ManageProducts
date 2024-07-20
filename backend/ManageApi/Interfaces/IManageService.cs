// Interfaces/ImanageService.cs
using ManageApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ManageApi.Interfaces
{
    public interface IManageService
    {
        Task<IEnumerable<Manage>> GetManages();
        Task<Manage> GetManage(long id);
        Task<Manage> CreateManage(Manage manage);
        Task UpdateManage(long id, Manage manage);
        Task DeleteManage(long id);
    }
}
