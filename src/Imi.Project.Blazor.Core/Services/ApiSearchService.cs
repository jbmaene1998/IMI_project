using Imi.Project.Api.Core.Dtos;
using Imi.Project.Blazor.Core.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Blazor.Core.Services
{
    public class ApiSearchService : IApiSearchService
    {
        private readonly string _baseUri;
        private readonly HttpClient _httpClient;

        public ApiSearchService()
        {
            _baseUri = NetworkSate.GetIP();
            _httpClient = new HttpClient();
        }

        public async Task<IEnumerable<CompanyResponseDto>> SearchCompany(string query)
        {
            var uri = $"{_baseUri}Search/{query}/companies";
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", LoginState.Token);
            var result = await _httpClient.GetAsync(uri).ConfigureAwait(false);
            if (result.IsSuccessStatusCode)
            {
                var resultStream = await result.Content.ReadAsStringAsync();
                var loginResponse = JsonConvert.DeserializeObject<IEnumerable<CompanyResponseDto>>(resultStream);
                return loginResponse;
            }
            else
                return null;
        }

        public async Task<IEnumerable<JobResponseDto>> SearchJob(string query)
        {
            var uri = $"{_baseUri}Search/{query}/jobs";
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", LoginState.Token);
            var result = await _httpClient.GetAsync(uri).ConfigureAwait(false);
            if (result.IsSuccessStatusCode)
            {
                var resultStream = await result.Content.ReadAsStringAsync();
                var loginResponse = JsonConvert.DeserializeObject<IEnumerable<JobResponseDto>>(resultStream);
                return loginResponse;
            }
            else
                return null;
        }

        public async Task<IEnumerable<LocationResponseDto>> SearchLocation(string continent, string country, string query)
        {
            var uri = $"{_baseUri}Search/{query}/{country}/{continent}/cities";
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", LoginState.Token);
            var result = await _httpClient.GetAsync(uri).ConfigureAwait(false);
            if (result.IsSuccessStatusCode)
            {
                var resultStream = await result.Content.ReadAsStringAsync();
                var loginResponse = JsonConvert.DeserializeObject<IEnumerable<LocationResponseDto>>(resultStream);
                return loginResponse;
            }
            else
                return null;
        }

        public async Task<IEnumerable<SchoolResponseDto>> SearchSchool(string query)
        {
            var uri = $"{_baseUri}Search/{query}/schools";
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", LoginState.Token);
            var result = await _httpClient.GetAsync(uri).ConfigureAwait(false);
            if (result.IsSuccessStatusCode)
            {
                var resultStream = await result.Content.ReadAsStringAsync();
                var loginResponse = JsonConvert.DeserializeObject<IEnumerable<SchoolResponseDto>>(resultStream);
                return loginResponse;
            }
            else
                return null;
        }
    }
}
