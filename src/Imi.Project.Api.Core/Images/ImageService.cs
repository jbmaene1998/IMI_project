using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Core.Interfaces.Helper;
using Imi.Project.Api.Core.Interfaces.Images;
using Imi.Project.Api.Core.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;

namespace Imi.Project.Api.Core.Images
{
    public class ImageService : IImageService
    {
        private readonly IHostEnvironment _webHostEnvironment;
        private readonly IRecruiterService _recruiterService;
        private readonly IMapper _mapper;

        public ImageService(IHostEnvironment webHostEnvironment, IRecruiterService recruiterService, IMapper mapper)
        {
            _webHostEnvironment = webHostEnvironment;
            _recruiterService = recruiterService;
            _mapper = mapper;
        }

        public async Task<string> AddOrUpdateImageAsync<T>(string entityId, IFormFile image)
        {
            var pathForDatabase = Path.Combine("images",
                typeof(T).Name.ToLower());

            var folderPathForImages = Path.Combine(
                _webHostEnvironment.ContentRootPath, "wwwroot/Images", pathForDatabase);

            if (!Directory.Exists(folderPathForImages))
            {
                Directory.CreateDirectory(folderPathForImages);
            }

            var fileExtension = Path.GetExtension(image.FileName);

            var newFileNameWithExtension = $"{entityId}{fileExtension}";

            var filePath = Path.Combine(folderPathForImages, newFileNameWithExtension);

            if (image.Length > 0)
            {
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await image.CopyToAsync(stream);
                }
            }

            var filePathForDatabase = Path.Combine(pathForDatabase, newFileNameWithExtension);

            return filePathForDatabase;
        }
    }
}

