using Chad_GPT_Client;
using Chad_GPT_Models.API.ImageModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Nodes;
using Newtonsoft.Json;
using Chad_GPT_Models.DBModels;
using Chad_GPT_Domain;
using Chad_GPT_Repository.IRepository;

namespace Chad_GPT_Web_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private CGPTImagesClient _client;
        private ImageInteractor _db;
        
        //public ImageController()
        //{
            
        //    _db = new ImageInteractor();
        //    _client = new CGPTImagesClient();
        //}
        //[HttpGet("ImagePrompt/{imagePrompt}")]
        //public ImageRoot ImagePrompt([FromBody]JsonObject user, string imagePrompt)
        //{
        //    //User theUser = JsonConvert.DeserializeObject<User>(user["user"].ToString());
        //    //string url = _client.ImagePrompt(imagePrompt).Result.data.
        //    //Image image = new Image() 
        //    //{
        //    //    url = 
        //    //};
        //    return _client.ImagePrompt(imagePrompt).Result;
        //}
    }
}
