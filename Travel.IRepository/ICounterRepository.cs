using System.Collections.Generic;
using System.Threading.Tasks;
using Travel.Entities.Entity;

namespace Travel.IRepository
{
    public interface ICounterRepository
    {
        Task<List<Counter>> GetCounters();
        Task<Counter> GetCounterById(int id);
        Task<bool> AddCounter(Counter counterDetails);
        Task<bool> UpdateCounter(int id, Counter counterDetails);
        Task<bool> DeleteCounter(int id);
    }
}
