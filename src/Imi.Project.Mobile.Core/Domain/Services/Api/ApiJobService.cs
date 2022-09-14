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
    public class ApiJobService : IApiJobService
    {
        private readonly string _baseUri;
        private readonly HttpClient _httpClient;

        public ApiJobService()
        {
            _baseUri = NetworkSate.GetIP();
            _httpClient = new HttpClient();
        }

        public async Task<JobResponseDto> Add(JobRequestDto request)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", LoginState.Token);
            var result = await _httpClient.PostAsJsonAsync($"{_baseUri}Job", request);
            if (result.IsSuccessStatusCode)
            {
                var resultStream = await result.Content.ReadAsStringAsync();
                var response = JsonConvert.DeserializeObject<JobResponseDto>(resultStream);
                return response;
            }
            else
                return null;
        }

        public Task Delete(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<JobResponseDto> Get(string id)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", LoginState.Token);
            var result = await _httpClient.GetAsync($"{_baseUri}Job/{id}");
            if (result.IsSuccessStatusCode)
            {
                var resultStream = await result.Content.ReadAsStringAsync();
                var response = JsonConvert.DeserializeObject<JobResponseDto>(resultStream);
                return response;
            }
            else
                return null;
        }
    }
}
