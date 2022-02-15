using FluentAssertions;
using GetItDone_Backend.Controllers;
using GetItDone_Models.Interfaces.Services;
using GetItDone_Models.Models;
using GetItDone_Models.Models.Auth;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace GetItDone_Testing.Backend_Controllers
{
    [TestClass]
    public class AuthControllerTest
    {
        private readonly Mock<IAuthenticationService> _mockService;
        private readonly AuthenticationController _authController;
        public AuthControllerTest()
        {
            _mockService = new Mock<IAuthenticationService>();
            _authController = new AuthenticationController(_mockService.Object);
        }

        [TestMethod]
        public async Task Login_ShouldReturnBadRequest_WhenParameterIsNull()
        {
            //Arrange
            //Act
            var response = await _authController.Login(null);
            //Assert
            var result = response.Should().BeOfType<BadRequestObjectResult>().Subject;
            result.Value.Should().Be("Invalid request");
        }

        [TestMethod]
        public async Task Login_ShouldReturnOkAndWithBearerToken_WhenEverythingIsOk()
        {
            //Arrange
            var token = CreateMockToken();
            var roles = new List<string> { "ProjectManager" };

            _mockService.Setup(x => x.EmailExists(It.IsAny<string>())).ReturnsAsync(true);
            _mockService.Setup(x => x.IsValidUserCredentials(It.IsAny<string>(), It.IsAny<string>())).ReturnsAsync(true);
            _mockService.Setup(x => x.GetUserRole(It.IsAny<string>())).ReturnsAsync(roles);
            _mockService.Setup(x => x.GenerateAccessToken(It.IsAny<IEnumerable<Claim>>())).Returns(token);

            //Act
            var response = await _authController.Login(new LoginRequest
            {
                Email = "mock92@hotmail.com",
                Password = "mock123"
            });

            //Assert
            var result = response.Should().BeOfType<OkObjectResult>().Subject;
            var authResult = result.Value.Should().BeOfType<LoginResponse>().Subject;
            authResult.Token.Should().NotBeNullOrWhiteSpace();
        
        }



        private static string CreateMockToken()
        {
            string Issuer = Guid.NewGuid().ToString();
            SecurityKey SecurityKey;
            SigningCredentials SigningCredentials;

            JwtSecurityTokenHandler s_tokenHandler = new JwtSecurityTokenHandler();
            var s_rng = RandomNumberGenerator.Create();
            byte[] s_key = new Byte[32];

            var claims = new List<Claim>();

            s_rng.GetBytes(s_key);
            SecurityKey = new SymmetricSecurityKey(s_key) { KeyId = Guid.NewGuid().ToString() };
            SigningCredentials = new SigningCredentials(SecurityKey, SecurityAlgorithms.HmacSha256);

            var token = s_tokenHandler.WriteToken(new JwtSecurityToken(Issuer, null, claims, null, DateTime.UtcNow.AddMinutes(20), SigningCredentials));
            return token;
        }

    }
}
