using Microsoft.AspNetCore.Mvc;
using Moq;
using Shop.Controllers;
using Shop.Domain.Exceptions;
using Shop.Domain.Services;
using Shop.Domain.Services.Comunications;
using Shop.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ShopTesting
{
    public class UserControllerTest
    {
        private readonly Mock<IUserService> _mockUserService;

        private readonly UserController _userController;


        public UserControllerTest()
        {
            _mockUserService = new Mock<IUserService>();
            _userController = new UserController(_mockUserService.Object);
        }



        [Fact]
        public async Task RegisterUser_WithNullObject_ReturnBadRequest()
        {

            var valueResult = await Assert.ThrowsAsync<BadRequestException>(() => _userController.Register(null));
            string expected = "Object is null";
            string actual = valueResult.Message;
            Assert.Equal(expected, actual);
        }

        [Fact]
        public async Task RegisterUser_WithInvalidObject_ReturnBadRequest()
        {
            var user = new RegisterResource { UserName = "admin", Password = "123"};
            _userController.ModelState.AddModelError("error", "some error");
            var valueResult = await Assert.ThrowsAsync<BadRequestException>(() => _userController.Register(user));
            string expected = "Invalid model Oject";
            string actual = valueResult.Message;
            Assert.Equal(expected, actual);
        }
        [Fact]
        public async Task RegisterUser_Successfully()
        {
            var user = new RegisterResource { UserName = "admin", Password = "123", ConfirmPassword = "123", Role = "Admin" };

            var response = new RegisterResponse();

            _mockUserService.Setup(repo => repo.RegisterAccount(user))
                .ReturnsAsync(response);


            var actionResult = await _userController.Register(user);

            var okResult = actionResult as OkObjectResult;

            var valueResult = okResult.Value as RegisterResponse;

            Assert.Equal(200, okResult.StatusCode);

            Assert.Equal(response.Success, valueResult.Success);
        }

        [Fact]
        public async Task Login_WithNullObject_ReturnBadRequest()
        {

            var valueResult = await Assert.ThrowsAsync<BadRequestException>(() => _userController.Login(null));
            string expected = "Object is null";
            string actual = valueResult.Message;
            Assert.Equal(expected, actual);
        }


        [Fact]
        public async Task Login_WithInvalidObject_ReturnBadRequest()
        {
            var user = new LoginResource { UserName = "admin" };
            _userController.ModelState.AddModelError("error", "some error");
            var valueResult = await Assert.ThrowsAsync<BadRequestException>(() => _userController.Login(user));
            string expected = "Invalid model Oject";
            string actual = valueResult.Message;
            Assert.Equal(expected, actual);
        }

        [Fact]
        public async Task Login_WithNotExistUser_ReturnNotFound()
        {
            var user = new LoginResource { UserName = "admin", Password = "123" };

            var response = new LoginResponse(false, "Either user name or password is wrong.", "",null);

            _mockUserService.Setup(repo => repo.LoginAccount(user))
                .ReturnsAsync(response);

            var result = await Assert.ThrowsAsync<BadRequestException>(() => _userController.Login(user));

            var actual = result.Message;
            Assert.Equal(response.Message, actual);

        }


        [Fact]
        public async Task Login_Successfully()
        {
            var user = new LoginResource { UserName = "admin", Password = "123"};

            var response = new LoginResponse(true, "", "hfadjkasjdkajsdkasjdlakdjskad",new UserResource { UserId=Guid.NewGuid().ToString(),UserName=user.UserName});

            _mockUserService.Setup(repo => repo.LoginAccount(user))
                .ReturnsAsync(response);


            var actionResult = await _userController.Login(user);

            var okResult = actionResult as OkObjectResult;

            var valueResult = okResult.Value as LoginResponse;

            Assert.Equal(200, okResult.StatusCode);

            Assert.Equal(response.Success, valueResult.Success);
        }
    }
}
