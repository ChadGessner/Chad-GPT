using Chad_GPT_Models.API.ImageModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Chad_GPT_Client
{
    public class CGPTImagesClient
    {
        private HttpClient _client;
        private string _imagePath;
        private string _key;
        private readonly Secrets _secrets;
        public CGPTImagesClient()
        {
            _secrets = new Secrets();
            _key = _secrets.ChadGPTKey;
            _client = new HttpClient();
            _imagePath = "https://api.openai.com/v1/images/generations";
        }
        public async Task<ImageRoot> ImagePrompt(string imagePrompt)
        {
            _client.BaseAddress = new Uri(_imagePath);
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Add("X-HTTP-Method-Override", "POST");
            _client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            JsonContent c = JsonContent.Create(
                new
                {
                    prompt = imagePrompt,
                    n = 1,
                    size = "256x256",
                    response_format = "url",
                    user = _secrets.ChadGPTKey
                });
            _client.DefaultRequestHeaders.Add("Authorization", _key);
            var response = await _client.PostAsync(_imagePath, c);
            var responseString = await response.Content.ReadAsStringAsync();
            await Console.Out.WriteLineAsync(responseString);
            return JsonConvert.DeserializeObject<ImageRoot>(responseString);
        }
    }
}
