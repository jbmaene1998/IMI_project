using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Interfaces.Images
{
    public interface IImageService
    {
        Task<string> AddOrUpdateImageAsync<T>(string entityId, IFormFile image);
    }
}
