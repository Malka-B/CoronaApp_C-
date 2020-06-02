using CoronaApp.Services.Models;
using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoronaApp.Services
{
    public interface ILocationService
    {
        List<Location> Get();
        List<Location> Get(LocationSearch locationSearch);
    }
}
