using CoronaApp.Dal;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entities;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using System.Collections.Concurrent;
using System.Linq.Dynamic.Core;

namespace CoronaApp.Services.Models
{
    public class LocationRepository : ILocationRepository
    {
        private readonly CoronaContext _CoronaContext;

        public LocationRepository(CoronaContext coronaContext)
        {
            _CoronaContext = coronaContext;
        }
        public List<Location> Get()
        {
           // List<Location> LocationList = _CoronaContext.Location.ToList();
           var LocationList = _CoronaContext.Location.ToList();
            LocationList.Sort();
            return LocationList;
        }

        public List<Location> Get(LocationSearch locationSearch)
        {
            DateTime EmptyDate = new DateTime();
            //only location
            if ((locationSearch.Location != "" || locationSearch.Location != null)&& locationSearch.StartDate == EmptyDate && locationSearch.EndDate == EmptyDate)
            {
                List<Location> LocationList = _CoronaContext.Location.ToList();
                List<Location> searchList = LocationList.FindAll(x => x.Adress.ToLower().Contains(locationSearch.Location.ToLower()));
                return searchList;
            }
            //only startDate
            else if (locationSearch.StartDate != EmptyDate && locationSearch.EndDate == EmptyDate && locationSearch.Location == null)
            {
                List<Location> LocationList = _CoronaContext.Location.ToList();
                List<Location> searchList = LocationList.FindAll(x => x.StartDate >= locationSearch.StartDate);
                return searchList;
            }
            //only endDate
            else if (locationSearch.StartDate == EmptyDate && locationSearch.EndDate != EmptyDate && locationSearch.Location == null)
            {
                List<Location> LocationList = _CoronaContext.Location.ToList();
                List<Location> searchList = LocationList.FindAll(x => x.EndDate <= locationSearch.EndDate);
                return searchList;
            }
            //start&end date
            else if (locationSearch.StartDate != EmptyDate && locationSearch.EndDate != EmptyDate && locationSearch.Location == null)
            {
                List<Location> LocationList = _CoronaContext.Location.ToList();
                List<Location> searchList = LocationList.FindAll(x => x.StartDate >= locationSearch.StartDate && x.EndDate <= locationSearch.EndDate);
                return searchList;
            }
            //start&end date& location
            else if (locationSearch.StartDate != EmptyDate && locationSearch.EndDate != EmptyDate && locationSearch.Location != null)
            {
                List<Location> LocationList = _CoronaContext.Location.ToList();
                List<Location> searchList = LocationList
                    .FindAll(x => x.StartDate >= locationSearch.StartDate
                && x.EndDate <= locationSearch.EndDate
                && x.Adress.ToLower().Contains(locationSearch.Location.ToLower()));
                return searchList;
            }
            //age only
           /* else if (locationSearch.StartDate != EmptyDate && locationSearch.EndDate != EmptyDate && locationSearch.Location == null&&locationSearch.Age!=null)
            {
                List<Location> LocationList = _CoronaContext.Location
                    .Include(L=>L.)
                List<Location> searchList = LocationList
                    .FindAll(x => x.StartDate >= locationSearch.StartDate
                && x.EndDate <= locationSearch.EndDate
                && x.Adress.ToLower().Contains(locationSearch.Location.ToLower()));
                return searchList;
            }
            */
            else
                throw new Exception();
        }

        public IQueryable<Location> GetAll(QueryParameters queryParameters)
        {
            IQueryable<Location> _allItems = _CoronaContext.Location.OrderBy(queryParameters.OrderBy,
              queryParameters.IsDescending());

            if (queryParameters.HasQuery())
            {
                _allItems = _allItems
                    .Where(x => x.City.ToString().Contains(queryParameters.Query.ToLowerInvariant()));
            }

            return _allItems
                .Skip(queryParameters.PageCount * (queryParameters.Page - 1))
                .Take(queryParameters.PageCount);
        }

        public int Count()
        {
            return _CoronaContext.Location.Count();
        }

    }
}

