using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RetroMood.Sentiment.Provider;
using RetroMood.Sentiment.Provider.FunRetro;

namespace RetroMood.Website.Controllers
{
    [Produces("application/json")]
    [Route("api/FileUpload")]
    public class FileUploadApiController : Controller
    {
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly ISentimentService _sentimentService;

        public FileUploadApiController(IHostingEnvironment hostingEnvironment, ISentimentService sentimentService)
        {
            _hostingEnvironment = hostingEnvironment;
            _sentimentService = sentimentService;
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
            var fullUploadPath = Path.Combine(_hostingEnvironment.WebRootPath, "uploads", file.FileName);
            if (System.IO.File.Exists(fullUploadPath))
            {
                System.IO.File.Delete(fullUploadPath);
            }
            if (file.Length > 0)
            {
                using (var stream = new FileStream(fullUploadPath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
            }
            var model = new FunRetroSentimentService(_sentimentService).GetAuthorMessagesWithSentimentFromCsv(fullUploadPath);  
            //return Ok(new { count = files.Count, size, fullUploadPath });
            return Ok(new { model , size, filename = HttpUtility.UrlEncode(file.FileName)});
        }

        [HttpGet("Get")]
        public IActionResult Get(string filename)
        {
            var filenameDecoded = HttpUtility.UrlDecode(filename);
            var model = new FunRetroSentimentService(_sentimentService).GetAuthorMessagesWithSentimentFromCsv(filenameDecoded);
            return Ok(new { model, filenameDecoded });
        }
    }
}
