using CoronaApp.Services.Models;
using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoronaApp.Services
{
    public class LocationService : ILocationService
    {
        private readonly ILocationRepository _locationRepository;
        public LocationService(ILocationRepository locationRepository)
        {
            _locationRepository = locationRepository;
        }
        public List<Location> Get()
        {
            return _locationRepository.Get();
        }

        public List<Location> Get(LocationSearch locationSearch)
        {
            return _locationRepository.Get(locationSearch);
        }
    }
}
