using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace WKTDotNetCore.RestApiWithNLayer.Features.DreamDictionary
{
    [Route("api/[controller]")]
    [ApiController]
    public class DreamDictionaryController : ControllerBase
    {
        private async Task<DreamDictionary> GetDataAsync()
        {
            string jsonstr = await System.IO.File.ReadAllTextAsync("DreamDictionary.json");

            var model = JsonConvert.DeserializeObject<DreamDictionary>(jsonstr);
            return model;
        }


        //api/DreamDictionary/BlogHeader
        [HttpGet("BlogHeader")]
        public async Task<IActionResult> BlogHeader()
        {
            var model = await GetDataAsync();
            return Ok(model.BlogHeader);
        }

        //[HttpGet]
        //public async Task<IActionResult> NumberList()
        //{
        //    var model = await GetDataAsync();
        //    return Ok(model.numberList);
        //}
        [HttpGet("{BlogId}/{no}")]
        public async Task<IActionResult> Blogdetail(int BlogId, int no)
        {
            var model = await GetDataAsync();
            return Ok(model.BlogDetail.FirstOrDefault(x => x.BlogId == BlogId && x.BlogDetailId == no));
        }
    }



    public class DreamDictionary
    {
        public Blogheader[] BlogHeader { get; set; }
        public Blogdetail[] BlogDetail { get; set; }
    }

    public class Blogheader
    {
        public int BlogId { get; set; }
        public string BlogTitle { get; set; }
    }

    public class Blogdetail
    {
        public int BlogDetailId { get; set; }
        public int BlogId { get; set; }
        public string BlogContent { get; set; }
    }


}

