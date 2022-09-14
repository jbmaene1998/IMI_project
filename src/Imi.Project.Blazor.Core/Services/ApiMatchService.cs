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
    public class ApiMatchService : IApiMatchService
    {
        private readonly string _baseUri;
        private readonly HttpClient _httpClient;

        public ApiMatchService()
        {
            _baseUri = NetworkSate.GetIP();
            _httpClient = new HttpClient();
        }
        public async Task<IEnumerable<MatchResponseDto>> GetAllByRecruiter(string id)
        {
            var uri = $"{_baseUri}Match/recruiter/{id}";
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", LoginState.Token);
            var result = await _httpClient.GetAsync(uri).ConfigureAwait(false);
            if (result.IsSuccessStatusCode)
            {
                var resultStream = await result.Content.ReadAsStringAsync();
                var loginResponse = JsonConvert.DeserializeObject<IEnumerable<MatchResponseDto>>(resultStream);
                return loginResponse;
            }
            else
                return null;
        }

        public async Task<IEnumerable<MatchResponseDto>> GetAllByStudent(string id)
        {
            var uri = $"{_baseUri}Match/students/{id}";
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", LoginState.Token);
            var result = await _httpClient.GetAsync(uri).ConfigureAwait(false);
            if (result.IsSuccessStatusCode)
            {
                var resultStream = await result.Content.ReadAsStringAsync();
                var loginResponse = JsonConvert.DeserializeObject<IEnumerable<MatchResponseDto>>(resultStream);
                return loginResponse;
            }
            else
                return null;
        }
    }
}

