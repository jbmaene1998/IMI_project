using Imi.Project.Api.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Mobile.Core.Domain.Interfaces.Api
{
    public interface IApiCompanyService
    {
        Task<CompanyResponseDto> GetCompanyById(string companyId);
    }
}
