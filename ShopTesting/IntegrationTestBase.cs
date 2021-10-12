using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Shop;
using Shop.Domain.Services.Comunications;
using Shop.Persistence.Contexts;
using Shop.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Xunit;

namespace ShopTesting
{
    public class IntegrationTestBase : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
       
        protected readonly HttpClient _client;
        protected readonly CustomWebApplicationFactory<Startup> _factory;

        public IntegrationTestBase(CustomWebApplicationFactory<Startup> factory)
        {

            _factory = factory;

            _client = _factory.CreateClient(new WebApplicationFactoryClientOptions
            {
                AllowAutoRedirect = false
            });
        }

        protected async Task AuthenticationAsync()
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await getJwt());
        }

        private async Task<RegisterResponse> register()
        {
            RegisterResource payLoad = new RegisterResource { UserName="admin",Password="1234",ConfirmPassword="1234",Role="User" };

            var response = await _client.PostAsJsonAsync("/api/user/register", payLoad);

            var registerResponse = await response.Content.ReadFromJsonAsync<RegisterResponse>();

            return registerResponse;
        }

        private async Task<string> getJwt()
        {
            var result = await register();

            if (!result.Success)
            {
                return "";
            }

            LoginResource payLoad = new LoginResource() { UserName = "admin", Password = "1234" };

            var response = await _client.PostAsJsonAsync("/api/User/login", payLoad);

            var loginResponse = await response.Content.ReadFromJsonAsync<LoginResponse>();

            return loginResponse.Token;
        }
    }
}
