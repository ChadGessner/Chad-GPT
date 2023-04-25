using System.Net;
using System.Net.Http.Json;
using Chad_GPT_Models.API.AnswerModels;
using Chad_GPT_Models.API.ImageModels;
using Newtonsoft.Json;

namespace Chad_GPT_Client
{
    public class CGPTClient
    {
        private  HttpClient _client;
        private  string _answerPath;
        private string _imagePath;
        private  string _key;
        private readonly Secrets _secrets;
        public CGPTClient()
        {
            _client = new HttpClient();
            _answerPath = "https://api.openai.com/v1/completions";
            _imagePath = "https://api.openai.com/v1/images/generations";
            _secrets = new Secrets();
            _key = _secrets.ChadGPTKey;
        }
        public async Task<AnswerRoot> AnswerPrompt(string question)
        {
            
            var x = new
            {
                Bearer = _key,
                ContentType = "application/json",
                Body = new
                {
                    model = "text-davinci-003",
                    temperature = .7,
                    prompt = "Howdy!",
                    max_tokens = 100
                }
            };

            _client.BaseAddress = new Uri(_answerPath);
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Add("X-HTTP-Method-Override", "POST");
            _client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            JsonContent c = JsonContent.Create(
                new
                {
                    
                    model = "text-davinci-003",
                    temperature = .7,
                    prompt = question,
                    max_tokens = 200 
                }) ;
            _client.DefaultRequestHeaders.Add("Authorization", _key);
            var response = await _client.PostAsync(_answerPath, c);
            var responseString = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<AnswerRoot>(responseString);
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
                    user = _secrets.ChadGPTOrg
                });
            _client.DefaultRequestHeaders.Add("Authorization", _key);
            var response = await _client.PostAsync(_imagePath, c);
            var responseString = await response.Content.ReadAsStringAsync();
            await Console.Out.WriteLineAsync(responseString);
            return JsonConvert.DeserializeObject<ImageRoot>(responseString);
        }
    }
}