using Chad_GPT_Client;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Chad_GPT_Web_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChadGPTController : ControllerBase
    {
        private readonly CGPTClient _client;
        public ChadGPTController()
        {
            _client = new CGPTClient();
        }
        [HttpGet("AskChadGPT/{question}")]
        public KeyValuePair<string, string> AskChadGPT(string question)
        {
            var request = _client.PostRequest(question);
            return new KeyValuePair<string, string>("data", request.Result.choices[0].text);
        }
    }
}
