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
    public class ApiStudentService : IApiStudentService
    {
        private readonly string _baseUri;
        private readonly HttpClient _httpClient;

        public ApiStudentService()
        {
            _baseUri = NetworkSate.GetIP();
            _httpClient = new HttpClient();
        }
        public async Task<IEnumerable<StudentResponseDto>> GetPotentialStudents(string recruiterId)
        {
            var uri = $"{_baseUri}Student/{recruiterId}/students";
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", LoginState.Token);
            var result = await _httpClient.GetAsync(uri).ConfigureAwait(false);
            if (result.IsSuccessStatusCode)
            {
                var resultStream = await result.Content.ReadAsStringAsync();
                var loginResponse = JsonConvert.DeserializeObject<IEnumerable<StudentResponseDto>>(resultStream);
                return loginResponse;
            }
            else
                return null;
        }
        public async Task<StudentResponseDto> GetById(string id)
        {            
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", LoginState.Token);
            var result = await _httpClient.GetAsync($"{_baseUri}Student/{id}").ConfigureAwait(false);
            if (result.IsSuccessStatusCode)
            {
                var resultStream = await result.Content.ReadAsStringAsync();
                var response = JsonConvert.DeserializeObject<StudentResponseDto>(resultStream);
                return response;
            }
            else
                return null;
        }

        public async Task<StudentResponseDto> Add(RegisterStudentRequestDto dto)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", LoginState.Token);
            var result = await _httpClient.PostAsJsonAsync($"{_baseUri}Student/register", dto).ConfigureAwait(false);
            if (result.IsSuccessStatusCode)
            {
                var resultStream = await result.Content.ReadAsStringAsync();
                var response = JsonConvert.DeserializeObject<StudentResponseDto>(resultStream);
                return response;
            }
            else
                return null;
        }

        public async Task<StudentResponseDto> Update(StudentRequestDto dto)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", LoginState.Token);
            var result = await _httpClient.PutAsJsonAsync($"{_baseUri}Student", dto).ConfigureAwait(false);
            if (result.IsSuccessStatusCode)
            {
                var resultStream = await result.Content.ReadAsStringAsync();
                var response = JsonConvert.DeserializeObject<StudentResponseDto>(resultStream);
                return response;
            }
            else
                return null;
        }
    }
}
