﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travel.Entities;
using Travel.Entities.Entity;
using Travel.IRepository;

namespace Travel.Repository
{
    public class CounterRepository : ICounterRepository
    {
        #region variables
        private readonly TravelContext _travelContext;

        public CounterRepository(TravelContext travelEntities)
        {
            _travelContext = travelEntities;
        }
        #endregion


        public async Task<bool> AddCounter(Counter counterDetails)
        {
            _travelContext.Add(counterDetails);
            var result = await _travelContext.SaveChangesAsync();
            
            return result > 0;
        }

        public async Task<bool> DeleteCounter(int id)
        {
            var data = await GetCounterById(id);
            if(data != null)
            {
                _travelContext.Counters.Remove(data);
                var result = await _travelContext.SaveChangesAsync();
                return result > 0;
            }

            return false;
        }

        public async Task<Counter> GetCounterById(int id)
        {
            var counter = await _travelContext.Counters
                .FirstOrDefaultAsync(x => x.Id == id);
            return counter;
        }

        public async Task<List<Counter>> GetCounters()
        {
            var counters = await _travelContext.Counters.ToListAsync();
            return counters;
        }

        public async Task<bool> UpdateCounter(int id, Counter counterDetails)
        {
            var counter = await GetCounterById(id);
            _travelContext.Entry(counter).State = EntityState.Modified;
            var result = await _travelContext.SaveChangesAsync();
                
            return result > 0;
        }
    }
}
