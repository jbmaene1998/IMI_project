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
    public class ApiVacancyService : IApiVacancyService 
    {
        private readonly string _baseUri;
        private readonly HttpClient _httpClient;

        public ApiVacancyService()
        {
            _baseUri = NetworkSate.GetIP();
            _httpClient = new HttpClient();
        }

        public async Task<VacancyResponseDto> Add(VacancyRequestDto request)
        {
            var result = await _httpClient.PostAsJsonAsync($"{_baseUri}Vacancy", request).ConfigureAwait(false);
            if (result.IsSuccessStatusCode)
            {
                var resultStream = await result.Content.ReadAsStringAsync();
                var loginResponse = JsonConvert.DeserializeObject<VacancyResponseDto>(resultStream);
                return loginResponse;
            }
            else
                return null;
        }

        public async Task Delete(string id)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", LoginState.Token);
            var test = $"{_baseUri}Vacancy/{id}";
            var result = await _httpClient.DeleteAsync(test);
            bool resultSucceeded = result.IsSuccessStatusCode;
        }

        public Task<VacancyResponseDto> Get(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<VacancyResponseDto>> GetAllVacancies(string id)
        {
            var uri = $"{_baseUri}Vacancy/{id}/recruiters";
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", LoginState.Token);
            var result = await _httpClient.GetAsync(uri).ConfigureAwait(false);
            if (result.IsSuccessStatusCode)
            {
                var resultStream = await result.Content.ReadAsStringAsync();
                var loginResponse = JsonConvert.DeserializeObject<IEnumerable<VacancyResponseDto>>(resultStream);
                return loginResponse.Where(x => x.RecruiterId == id);
            }
            else
                return null;
        }
        public async Task<bool> HasRecruiterThis(string input)
        {
            var results = (GetAllVacancies(LoginState.Id).Result.Where(v => v.RecruiterId == LoginState.Id && v.Name == input));
            if (results.Count() == 0)
            {
                return true;
            }
            return false;
        }
    }
}
