using Imi.Project.Api.Core.Dtos;
using Imi.Project.Mobile.Core.Domain.Interfaces.Api;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace Imi.Project.Mobile.Core.Domain.Services.Api
{
    public class ApiUserService : IApiUserService
    { 
        private readonly string _baseUri;
        private readonly HttpClient _httpClient;

        public ApiUserService()
        {
            _baseUri = NetworkSate.GetIP();
            _httpClient = new HttpClient();
        }
        public async Task<string> Login(string email, string password)
        {
            LoginRequestDto loginRequestDto = new LoginRequestDto()
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
                LoginState.SetId(loginResponse.Id);
                LoginState.SetIsRecruiter(loginResponse.IsRecruiter);
                return LoginState.Token;
            }
            else
                return null;
        }
    }
}
