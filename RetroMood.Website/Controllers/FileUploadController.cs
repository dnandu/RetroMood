using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CsvHelper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RetroMood.Website.Utils;

namespace RetroMood.Website.Controllers
{
    [Produces("application/json")]
    [Route("api/FileUpload")]
    public class FileUploadController : Controller
    {
        private readonly IHostingEnvironment hostingEnvironment;

        public FileUploadController(IHostingEnvironment hostingEnvironment)
        {
            this.hostingEnvironment = hostingEnvironment;
        }


        //https://docs.microsoft.com/en-us/aspnet/core/mvc/models/file-uploads?view=aspnetcore-2.1
        [HttpPost("UploadFiles")]
        public async Task<IActionResult> Post(List<IFormFile> files)
        {
            long size = files.Sum(f => f.Length);

            if (!files.Any())
                return NotFound();

            //get the first file only
            var file = files.First();

            // full path to file in upload folder 
            var fullUploadPath = Path.Combine(this.hostingEnvironment.WebRootPath, "uploads", file.FileName);

            if (file.Length > 0)
            {
                using (var stream = new FileStream(fullUploadPath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
            }

            // read csv 
            var csvProvider = new CsvProvider();
            csvProvider.ReadFile(fullUploadPath);


            // process uploaded files
            // Don't rely on or trust the FileName property without validation.

            return Ok(new { count = files.Count, size, fullUploadPath });
        }
    }
}
