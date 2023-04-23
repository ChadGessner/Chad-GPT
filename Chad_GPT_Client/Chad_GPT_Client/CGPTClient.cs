using System.Net;
using System.Net.Http.Json;
using Chad_GPT_Models;
using Newtonsoft.Json;

namespace Chad_GPT_Client
{
    public class CGPTClient
    {
        private  HttpClient _client;
        private  string _path;
        private  string _key;
        public CGPTClient()
        {
            _client = new HttpClient();
            _path = "https://api.openai.com/v1/completions";
            _key = "Bearer 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";
        }
        public async Task<Root> PostRequest(string question)
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
                    max_tokens = 7
                }
            };

            _client.BaseAddress = new Uri(_path);
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Add("X-HTTP-Method-Override", "POST");
            _client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            JsonContent c = JsonContent.Create(
                new
                {
                    
                    model = "text-davinci-003", temperature = .7, prompt = question, max_tokens = 20 
                }) ;
            _client.DefaultRequestHeaders.Add("Authorization", _key);
            var response = await _client.PostAsync(_path, c);
            var responseString = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<Root>(responseString);
        }
    }
}