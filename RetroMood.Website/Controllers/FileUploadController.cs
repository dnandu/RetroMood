using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RetroMood.Website.Controllers
{
    [Produces("application/json")]
    [Route("api/FileUpload")]
    public class FileUploadController : Controller
    {
        // GET: api/FileUpload
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/FileUpload/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }
        
        // POST: api/FileUpload
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }
        
        // PUT: api/FileUpload/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
