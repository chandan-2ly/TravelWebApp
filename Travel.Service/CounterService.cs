using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Travel.Core.BusinessModels;
using Travel.Entities.Entity;
using Travel.IRepository;
using Travel.IService;

namespace Travel.Service
{
    public class CounterService : ICounterService
    {
        private readonly ICounterRepository _counterRepository;
        private readonly IMapper _mapper;

        public CounterService(ICounterRepository counterRepository, IMapper mapper)
        {
            _counterRepository = counterRepository ?? throw new ArgumentNullException(nameof(counterRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<bool> AddCounter(CounterDetails counterDetails)
        {
            var counterEntity = _mapper.Map<Counter>(counterDetails);
            return await _counterRepository.AddCounter(counterEntity);
        }

        public async Task<bool> DeleteCounter(int id)
        {
            return await _counterRepository.DeleteCounter(id);
        }

        public async Task<CounterDetails> GetCounterById(int id)
        {
            var counterData =  await _counterRepository.GetCounterById(id);
            return _mapper.Map<CounterDetails>(counterData);
        }

        public async Task<List<CounterDetails>> GetCounters()
        {
            var counterData = await _counterRepository.GetCounters();
            var counterList = new List<CounterDetails>();

            foreach(var counter in counterData)
            {
                counterList.Add(_mapper.Map<CounterDetails>(counter));
            }

            return counterList;
        }

        public async Task<bool> UpdateCounter(int id, CounterDetails counterDetails)
        {
            return await _counterRepository.UpdateCounter(id, _mapper.Map<Counter>(counterDetails));
        }
    }
}
