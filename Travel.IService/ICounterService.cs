using System.Collections.Generic;
using System.Threading.Tasks;
using Travel.Core.BusinessModels;

namespace Travel.IService
{
    public interface ICounterService
    {
        Task<List<CounterDetails>> GetCounters();
        Task<CounterDetails> GetCounterById(int id);
        Task<bool> AddCounter(CounterDetails counterDetails);
        Task<bool> UpdateCounter(int id, CounterDetails counterDetails);
        Task<bool> DeleteCounter(int id);
        Task<bool> HardDeleteCounter(int id);
    }
}
