using Imi.Project.Api.Core.Dtos;
using Imi.Project.Wpf.Core.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Imi.Project.Wpf.Core.Services.Api
{
    public class ApiUserService : IUserService
    {
        private readonly string _baseUri;
        private readonly HttpClient _httpClient;

        public ApiUserService()
        {
            _baseUri = "https://localhost:5001/";
            _httpClient = new HttpClient();
        }
        public async Task<string> Login(string email, string password)
        {
            LoginRequestDto loginRequestDto = new()
            {
                Email = email,
                Password = password
            };
            var uri = $"{_baseUri}Login";
            var result = await _httpClient.PostAsJsonAsync(uri, loginRequestDto).ConfigureAwait(false);
            if (result.IsSuccessStatusCode)
            {
                var resultStream = await result.Content.ReadAsStringAsync();
                var loginResponse = JsonConvert.DeserializeObject<LoginResponseDto>(resultStream);
                LoginState.SetToken(loginResponse.Token);
                return LoginState.Token;
            }
            else
                return null;
        }
    }
}
