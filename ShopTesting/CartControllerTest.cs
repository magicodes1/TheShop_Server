using Castle.Core.Logging;
using Microsoft.AspNetCore.Mvc.Testing;
using Shop;
using Shop.Domain.Exceptions;
using Shop.Domain.Services.Comunications;
using Shop.Resources;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Xunit;

namespace ShopTesting
{
    public class CartControllerTest : IntegrationTestBase
    {

        public CartControllerTest(CustomWebApplicationFactory<Startup> factory) : base(factory)
        {

        }

        [Fact]
        public async Task Get_SecurePageRequireAuthentication()
        {

            var payLoad = new AddToCartResource();

            var response = await _client.PostAsJsonAsync("/api/cart", payLoad);

            Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
        }


        [Fact]
        public async Task Get_SecurePageIsAvailableForAuthenticatedUser_WithNullObject_ReturnBadRequest()
        {

            await AuthenticationAsync();
            AddToCartResource payload = data()[0];
            var response = await _client.PostAsJsonAsync("/api/cart", payload);

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact]
        public async Task Get_SecurePageIsAvailableForAuthenticatedUser_WithPropertiesObject_ReturnBadRequest()
        {

            await AuthenticationAsync();
            AddToCartResource payload = data()[1];
            var response = await _client.PostAsJsonAsync("/api/cart", payload);

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact]
        public async Task Get_SecurePageIsAvailableForAuthenticatedUser_WithInValidObject_ReturnBadRequest()
        {

            await AuthenticationAsync();
            AddToCartResource payload = data()[2];
            var response = await _client.PostAsJsonAsync("/api/cart", payload);

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact]
        public async Task Get_SecurePageIsAvailableForAuthenticatedUser_ReturnOk()
        {

            await AuthenticationAsync();
            AddToCartResource payload = data()[3];
            var response = await _client.PostAsJsonAsync("/api/cart", payload);

            var valueResponse = await response.Content.ReadFromJsonAsync<CartResponse>();
            // Console.WriteLine(response.Content.ReadAsStringAsync().ToString());


            Assert.Equal(HttpStatusCode.OK, response.StatusCode);


            bool expected = true;
            Assert.Equal(expected, valueResponse.Success);
        }




        private List<AddToCartResource> data()
        => new List<AddToCartResource>
        {
            null,
            new AddToCartResource {
                //Bill= new BillResource {
                //    Address="New York",
                //    DayOfBillExport=DateTime.Parse("2020-07-01"),
                //    PhoneNumber=1234567899
                //},
                 Bill=null,
                 BillDetail=null
                 //BillDetail=new List<BillDetailResource>
                 //{
                 //    new BillDetailResource
                 //    {
                 //        ProductId=1,
                 //        Quantity=1,
                 //        Price=123
                 //    }
                 //}
            },
            new AddToCartResource
                {
                    Bill = new BillResource {
                        Address="New York",
                        DayOfBillExport=DateTime.Parse("2020-07-01"),
                        PhoneNumber=1234567899
                    },
                    BillDetail = new List<BillDetailResource>
                    {
                        new BillDetailResource
                        {
                            ProductId=1,
                            Price=12301
                        }
                    }
                },
            new AddToCartResource
                {
                    Bill = new BillResource {
                        Address="New York",
                        DayOfBillExport=DateTime.Parse("2020-07-01"),
                        PhoneNumber=1234567899,
                        TotalPrice=200,
                        UserId=Guid.NewGuid().ToString(),

                    },
                    BillDetail= new List<BillDetailResource>
                    {
                        new BillDetailResource
                        {
                            ProductId=1,
                            Price=12301,
                            Quantity=2,
                        }
                    }
                }

        };



    }
}
