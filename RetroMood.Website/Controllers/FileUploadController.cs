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
    public class FileUploadController : Controller
    {
        private const string _uploadFolder = "uploads";
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly ISentimentService _sentimentService;

        public FileUploadController(IHostingEnvironment hostingEnvironment, ISentimentService sentimentService)
        {
            _hostingEnvironment = hostingEnvironment;
            _sentimentService = sentimentService;
        }

        // POST: FileUpload/Create
        [HttpPost]
        public async Task<IActionResult> UploadFiles(List<IFormFile> files)
        {
            try
            {
                // TODO: Add insert logic here
                long size = files.Sum(f => f.Length);

                if (!files.Any())
                    return NotFound();

                //get the first file only
                var file = files.First();

                // full path to file in upload folder 
                var fullUploadPath = Path.Combine(_hostingEnvironment.WebRootPath, _uploadFolder, file.FileName);
              
                if (file.Length > 0)
                {
                    using (var stream = new FileStream(fullUploadPath, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }
                }
                
                
                return RedirectToAction(nameof(Results), new { filename = HttpUtility.UrlEncode(file.FileName)});
            }
            catch
            {
                // TODO: add error page
                return View();
            }
        }

        [HttpGet]
        public IActionResult Results(string filename)
        {
            var fileNameDecoded = HttpUtility.UrlDecode(filename);
            var fullUploadPath = Path.Combine(_hostingEnvironment.WebRootPath, _uploadFolder, fileNameDecoded);
            var model = new FunRetroSentimentService(_sentimentService).GetAuthorMessagesWithSentimentFromCsv(fullUploadPath);
            return View(model);
        }
    }
}