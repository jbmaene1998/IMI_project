using Imi.Project.Api.Core.Dtos;
using Imi.Project.Wpf.Core.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Wpf.Core.Services.Api
{
    public class ApiJobsService : IJobService
    {
        private readonly string _baseUri;
        private readonly HttpClient _httpClient;

        public ApiJobsService()
        {
            _baseUri = "https://localhost:5001/";
            _httpClient = new HttpClient();
        }

        public async Task<JobResponseDto> AddJob(JobRequestDto request)
        {
            var result = await _httpClient.PostAsJsonAsync($"{_baseUri}Job", request).ConfigureAwait(false);
            if (result.IsSuccessStatusCode)
            {
                var resultStream = await result.Content.ReadAsStringAsync();
                var loginResponse = JsonConvert.DeserializeObject<JobResponseDto>(resultStream);
                return loginResponse;
            }
            else
                return null;
        }

        public async Task DeleteJob(Guid id)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", LoginState.Token);
            var test = $"{_baseUri}Job/{id}";
            var result = await _httpClient.DeleteAsync(test);
            bool resultSucceeded = result.IsSuccessStatusCode;
        }

        public async Task<JobResponseDto> GetJob(Guid id)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", LoginState.Token);
            var result = await _httpClient.GetAsync($"{_baseUri}Job{id}");
            if (result.IsSuccessStatusCode)
            {
                var resultStream = await result.Content.ReadAsStringAsync();
                var response = JsonConvert.DeserializeObject<JobResponseDto>(resultStream);
                return response;
            }
            else
                return null;
        }
        public async Task<IEnumerable<JobResponseDto>> GetAllJobs()
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", LoginState.Token);
            var result = await _httpClient.GetAsync($"{_baseUri}Job");
            if (result.IsSuccessStatusCode)
            {
                var resultStream = await result.Content.ReadAsStringAsync();
                var response = JsonConvert.DeserializeObject<IEnumerable<JobResponseDto>>(resultStream);
                return response;
            }   
            else
                return null;
        }
    }
}
