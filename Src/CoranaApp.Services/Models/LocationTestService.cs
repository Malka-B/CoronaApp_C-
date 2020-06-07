using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoronaApp.Services.Models
{
    public class LocationTestService : ILocationService
    {
        public List<Location> Get()
        {
            return new List<Location> {
                new Location() { Adress="aaa",City="bbb",EndDate=DateTime.Now,StartDate=DateTime.Now} };
        }

        public List<Location> Get(LocationSearch locationSearch)
        {
            throw new NotImplementedException();
        }
    }
}
