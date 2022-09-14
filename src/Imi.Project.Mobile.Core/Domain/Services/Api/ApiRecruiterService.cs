using Imi.Project.Api.Core.Dtos;
using Imi.Project.Blazor.Core.Interfaces;
using Imi.Project.Mobile.Core.Domain.Interfaces.Api;
using Imi.Project.Mobile.Core.Modals;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Mobile.Core.Domain.Services.Api
{
    public class ApiRecruiterService : IApiRecruiterService
    {
        private readonly string _baseUri;
        private readonly HttpClient _httpClient;

        public ApiRecruiterService()
        {
            _baseUri = NetworkSate.GetIP();
            _httpClient = new HttpClient();
        }

        public async Task<RecruiterResponseDto> Add(RegisterRecruiterRequestDto dto)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", LoginState.Token);
            var result = await _httpClient.PostAsJsonAsync($"{_baseUri}Recruiter/register", dto).ConfigureAwait(false);
            if (result.IsSuccessStatusCode)
            {
                var resultStream = await result.Content.ReadAsStringAsync();
                var response = JsonConvert.DeserializeObject<RecruiterResponseDto>(resultStream);
                return response;
            }
            else
                return null;
        }

        public async Task<RecruiterResponseDto> GetById(string id)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", LoginState.Token);
            var result = await _httpClient.GetAsync($"{_baseUri}Recruiter/{id}").ConfigureAwait(false);
            if (result.IsSuccessStatusCode)
            {
                var resultStream = await result.Content.ReadAsStringAsync();
                var response = JsonConvert.DeserializeObject<RecruiterResponseDto>(resultStream);
                return response;
            }
            else
                return null;
        }

        public async Task<IEnumerable<RecruiterResponseDto>> GetPotentialRecruiters(string studentId)
        {
            var uri = $"{_baseUri}Recruiter/{studentId}/students";
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", LoginState.Token);
            var result = await _httpClient.GetAsync(uri).ConfigureAwait(false);
            if (result.IsSuccessStatusCode)
            {
                var resultStream = await result.Content.ReadAsStringAsync();
                var loginResponse = JsonConvert.DeserializeObject<IEnumerable<RecruiterResponseDto>>(resultStream);
                return loginResponse;
            }
            else
                return null;
        }

        public async Task<RecruiterResponseDto> Update(RecruiterRequestDto dto)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", LoginState.Token);
            var result = await _httpClient.PutAsJsonAsync($"{_baseUri}Recruiter", dto).ConfigureAwait(false);
            if (result.IsSuccessStatusCode)
            {
                var resultStream = await result.Content.ReadAsStringAsync();
                var response = JsonConvert.DeserializeObject<RecruiterResponseDto>(resultStream);
                return response;
            }
            else
                return null;
        }
    }
}
