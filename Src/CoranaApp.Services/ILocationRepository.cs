using CoronaApp.Services.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Entities;
using System.Linq;

namespace CoronaApp.Services
{
    public interface ILocationRepository
    {
        List<Location> Get();
        List<Location> Get(LocationSearch locationSearch);
        int Count();
        IQueryable<Location> GetAll(QueryParameters queryParameters);
    }
}
