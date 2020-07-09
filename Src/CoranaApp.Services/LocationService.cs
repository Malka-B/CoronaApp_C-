using CoronaApp.Services.Models;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public Return GetAll(QueryParameters queryParameters)
        {
            List<Location> allLocations = _locationRepository
                .GetAll(queryParameters)
                .ToList();

            int allItemCount = _locationRepository.Count();

            
            
            return new Return
            {
                locations = allLocations,
                count = allItemCount
            };

        }

        
    }

}
