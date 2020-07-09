using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoronaApp.Services;
using CoronaApp.Services.Models;
using Microsoft.AspNetCore.Mvc;
using Entities;
using Newtonsoft.Json;

namespace CoronaApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly ILocationService _locationService;
        private readonly IUrlHelper _urlHelper;

        public LocationController(ILocationService locationService, IUrlHelper urlHelper)
        {
            _locationService = locationService;
            _urlHelper = urlHelper;
        }
        // GET: api/<LocationController>
        [HttpGet]
        public List<Location> Get([FromQuery] LocationSearch locationSearch = null)
        {
            return _locationService.Get(locationSearch);
        }
        [HttpGet]
        [Route("{sort}")]
        public List<Location> Get()
        {
            return _locationService.Get();
        }

        [HttpGet("getPage")]
        //[Route("{getPage}")]
        public IActionResult GetAll([FromQuery] QueryParameters queryParameters)
        {

            Return r = _locationService.GetAll(queryParameters);

            var paginationMetadata = new
            {
                totalCount = r.count,
                pageSize = queryParameters.PageCount,
                currentPage = queryParameters.Page,
                totalPages = queryParameters.GetTotalPages(r.count)
            };

            var links = CreateLinksForCollection(queryParameters, r.count);

            Response.Headers
                .Add("X-Pagination",
                    JsonConvert.SerializeObject(paginationMetadata));
            
            return Ok(new
            {
                value = r.locations,
                links = links
            });
        }

        private List<LinkDto> CreateLinksForCollection(QueryParameters queryParameters, int totalCount)
        {
            var links = new List<LinkDto>();

            // self 
            links.Add(
             new LinkDto(_urlHelper.Link(nameof(GetAll), new
             {
                 pagecount = queryParameters.PageCount,
                 page = queryParameters.Page,
                 orderby = queryParameters.OrderBy
             }), "self", "GET"));

            links.Add(new LinkDto(_urlHelper.Link(nameof(GetAll), new
            {
                pagecount = queryParameters.PageCount,
                page = 1,
                orderby = queryParameters.OrderBy
            }), "first", "GET"));

            links.Add(new LinkDto(_urlHelper.Link(nameof(GetAll), new
            {
                pagecount = queryParameters.PageCount,
                page = queryParameters.GetTotalPages(totalCount),
                orderby = queryParameters.OrderBy
            }), "last", "GET"));

            if (queryParameters.HasNext(totalCount))
            {
                links.Add(new LinkDto(_urlHelper.Link(nameof(GetAll), new
                {
                    pagecount = queryParameters.PageCount,
                    page = queryParameters.Page + 1,
                    orderby = queryParameters.OrderBy
                }), "next", "GET"));
            }

            if (queryParameters.HasPrevious())
            {
                links.Add(new LinkDto(_urlHelper.Link(nameof(GetAll), new
                {
                    pagecount = queryParameters.PageCount,
                    page = queryParameters.Page - 1,
                    orderby = queryParameters.OrderBy
                }), "previous", "GET"));
            }

            return links;
        }

    }
}
