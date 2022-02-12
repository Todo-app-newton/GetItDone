﻿using GetItDone_Frontend.Models;
using GetItDone_Models.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace GetItDone_Frontend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly ILogger<LoginController> _logger;
        private readonly WebApiEndpoints endpoints;

        public LoginController(ILogger<LoginController> logger)
        {
            _logger = logger;
            endpoints = new WebApiEndpoints();
        }

        [HttpPost]
        public LoginUserModel Post([FromBody]LoginUserModel login)
        {
            return login;
            /*if (login.Email == null || login.Password == null)
            {
                return BadRequest("Error");
            }
            else
            {
                var newLoginRequest = new LoginRequest()
                {
                    Email = login.Email,
                    Password = login.Password

                };
                string jsonLogin = JsonConvert.SerializeObject(newLoginRequest);
                var httpContent = new StringContent(jsonLogin, Encoding.UTF8, "application/json");

                using (HttpClient client = new HttpClient())
                {
                    var response = client.PostAsync(new Uri(endpoints.LoginUser), httpContent).Result;

                   if (response.StatusCode != System.Net.HttpStatusCode.OK)
                        return Ok(login);
                   else
                    { return BadRequest(); }
                }

            }*/

        }


        /*public string GetToken(string username, string password)
        {
            using (var httpClient = new HttpClient())
            {
                var userForm = new Dictionary<string, string>
                        {
                            {"UserName", username },
                            {"Password", password },
                            {"grant_type", "password" }
                        };
                var content = new FormUrlEncodedContent(userForm);
                var response = httpClient.PostAsync(endpoints.GetToken, content).Result;
                var token = response.Content.ReadAsAsync<TokenDto>(new[] { new JsonMediaTypeFormatter() }).Result;

                return token.AccessToken;
            }
        }*/
    }
}
