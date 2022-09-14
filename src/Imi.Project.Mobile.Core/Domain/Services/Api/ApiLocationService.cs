using Imi.Project.Api.Core.Dtos;
using Imi.Project.Mobile.Core.Domain.Interfaces.Api;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Mobile.Core.Domain.Services.Api
{
    public class ApiLocationService : IApiLocationService
    {
        private readonly string _baseUri;
        private readonly HttpClient _httpClient;

        public ApiLocationService()
        {
            _baseUri = NetworkSate.GetIP();
            _httpClient = new HttpClient();
        }

        public async Task<IEnumerable<LocationResponseDto>> GetContinents()
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", LoginState.Token);
            var result = await _httpClient.GetAsync($"{_baseUri}Location");
            if (result.IsSuccessStatusCode)
            {
                var resultStream = await result.Content.ReadAsStringAsync();
                var response = JsonConvert.DeserializeObject<IEnumerable<LocationResponseDto>>(resultStream);
                return response;
            }
            else
                return null;
        }

        public async Task<IEnumerable<LocationResponseDto>> GetCountriesByContinent(string query)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", LoginState.Token);
            var result = await _httpClient.GetAsync($"{_baseUri}Location/{query}/countries");
            if (result.IsSuccessStatusCode)
            {
                var resultStream = await result.Content.ReadAsStringAsync();
                var response = JsonConvert.DeserializeObject<IEnumerable<LocationResponseDto>>(resultStream);
                return response;
            }
            else
                return null;
        }

        public async Task<LocationResponseDto> GetLocationById(string locationId)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", LoginState.Token);
            var result = await _httpClient.GetAsync($"{_baseUri}Location/{locationId}");
            if (result.IsSuccessStatusCode)
            {
                var resultStream = await result.Content.ReadAsStringAsync();
                var response = JsonConvert.DeserializeObject<LocationResponseDto>(resultStream);
                return response;
            }
            else
                return null;
        }
    }
}
