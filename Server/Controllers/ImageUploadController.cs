﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shared.Models;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageUploadController : ControllerBase
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ImageUploadController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UploadedImage uploadedImage)
        {
            try
            {
                if (ModelState.IsValid == false)
                {
                    return BadRequest(ModelState);
                }

                if (uploadedImage.OldImagePath != string.Empty)
                {
                    if (uploadedImage.OldImagePath != "uploads/placeholder.jpg")
                    {
                        string oldUploadedImageFileName = uploadedImage.OldImagePath.Split('/').Last();

                        System.IO.File.Delete($"{_webHostEnvironment.ContentRootPath}\\wwwroot\\uploads\\{oldUploadedImageFileName}");
                    }
                }

                string guid = Guid.NewGuid().ToString();
                string imageFileName = guid + uploadedImage.NewImageFileExtension;

                string fullImageFileSystemPath = $"{_webHostEnvironment.ContentRootPath}\\wwwroot\\uploads\\{imageFileName}";

                FileStream fileStream = System.IO.File.Create(fullImageFileSystemPath);
                byte[] imageContentAsByteArray = Convert.FromBase64String(uploadedImage.NewImageBase64Content);
                await fileStream.WriteAsync(imageContentAsByteArray, 0, imageContentAsByteArray.Length);
                fileStream.Close();

                string relativrFilePathWithoutTrailingSlashes = $"uploads/{imageFileName}";

                return Created("Create", relativrFilePathWithoutTrailingSlashes);
            }
            catch (Exception e)
            {
                return StatusCode(500, $"Something went wrong on our side. Please contact the admin... Error message: {e.Message}");
            }
        }
    }
}
