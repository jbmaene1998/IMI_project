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
    public class ApiSchoolService : IApiSchoolService
    {
        private readonly string _baseUri;
        private readonly HttpClient _httpClient;

        public ApiSchoolService()
        {
            _baseUri = NetworkSate.GetIP();
            _httpClient = new HttpClient();
        }

        public async Task<SchoolResponseDto> GetSchoolById(string schoolId)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", LoginState.Token);
            var result = await _httpClient.GetAsync($"{_baseUri}School/{schoolId}").ConfigureAwait(true);
            if (result.IsSuccessStatusCode)
            {
                var resultStream = await result.Content.ReadAsStringAsync();
                var response = JsonConvert.DeserializeObject<SchoolResponseDto>(resultStream);
                return response;
            }
            else
                return null;
        }
    }
}
