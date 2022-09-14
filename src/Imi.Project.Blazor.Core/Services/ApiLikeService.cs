using Imi.Project.Api.Core.Dtos;
using Imi.Project.Blazor.Core.Interfaces;
using Imi.Project.Mobile.Core.Modals;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Blazor.Core.Services
{
    public class ApiLikeService : IApiLikeService
    {
        private readonly string _baseUri;
        private readonly HttpClient _httpClient;

        public ApiLikeService()
        {
            _baseUri = NetworkSate.GetIP();
            _httpClient = new HttpClient();
        }
        public async Task<LikeResponseDto> Add(LikeRequestDto requestDto)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", LoginState.Token);
            var result = await _httpClient.PostAsJsonAsync($"{_baseUri}Like" , requestDto);
            if (result.IsSuccessStatusCode)
            {
                var resultStream = await result.Content.ReadAsStringAsync();
                var response = JsonConvert.DeserializeObject<LikeResponseDto>(resultStream);
                return response;
            }
            else
                return null;
        }

        public async Task<IEnumerable<LikeResponseDto>> GetAllFromRecruiter(string recruiterId)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", LoginState.Token);
            var result = await _httpClient.GetAsync($"{_baseUri}Like/{recruiterId}/recruiters");
            if (result.IsSuccessStatusCode)
            {
                var resultStream = await result.Content.ReadAsStringAsync();
                var response = JsonConvert.DeserializeObject<IEnumerable<LikeResponseDto>>(resultStream);
                return response;
            }
            else
                return null;
        }

        public async Task<IEnumerable<LikeResponseDto>> GetAllFromStudent(string studentId)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", LoginState.Token);
            var result = await _httpClient.GetAsync($"{_baseUri}Like/{studentId}/students");
            if (result.IsSuccessStatusCode)
            {
                var resultStream = await result.Content.ReadAsStringAsync();
                var response = JsonConvert.DeserializeObject<IEnumerable<LikeResponseDto>>(resultStream);
                return response;
            }
            else
                return null;
        }
    }
}
