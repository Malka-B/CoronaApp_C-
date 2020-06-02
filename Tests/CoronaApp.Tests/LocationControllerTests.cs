using CoronaApp.Api;
using CoronaApp.Services;
using CoronaApp.Services.Models;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CoronaApp.Tests
{
    public class LocationControllerTests:IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Api.Startup> _factory;
        public LocationControllerTests(WebApplicationFactory<Api.Startup> factory)
        {
            _factory = factory;
        }


        [Fact]
        public async void GetLocationList()
        {
            // Arrange
            var client = _factory.WithWebHostBuilder(builder =>
            {
                builder.ConfigureTestServices(services =>
                {
                    services.AddScoped<ILocationService, LocationTestService>();
                });
            })
                .CreateClient();

            // Act
            var response = await client.GetAsync("/api/Location/sort");

            // Assert
            response.EnsureSuccessStatusCode();
           
            }
        }
    }

