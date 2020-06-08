using CoronaApp.Dal;
using CoronaApp.Services;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CoronaApp.Tests
{
    public class PatientControllerMockTest : IClassFixture<WebApplicationFactory<Api.Startup>>
    {
        private readonly WebApplicationFactory<Api.Startup> _factory;

        public PatientControllerMockTest(WebApplicationFactory<Api.Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async void GetPatient_ById_ReturnPatient()
        {
            var client = _factory.WithWebHostBuilder(builder =>
            {
                builder.ConfigureTestServices(services =>
                {
                    services.AddScoped<IPatientRepository, AsDB>();
                });
            })
        .CreateClient();

            //Act
            //var defaultPage = await client.GetAsync("/");
            //var content = await HtmlHelpers.GetDocumentAsync(defaultPage);
            //var quoteElement = content.QuerySelector("#quote");
            var response = await client.GetAsync("/api/patient/?patientId=123456789");
            // Assert
            //Assert.Equal("Something's interfering with time, Mr. Scarman, " +
            //"and time is my business.", quoteElement.Attributes["value"].Value);
            response.EnsureSuccessStatusCode();
            var response1 = response.Content.ReadAsStringAsync();
        }
        
    }
}
