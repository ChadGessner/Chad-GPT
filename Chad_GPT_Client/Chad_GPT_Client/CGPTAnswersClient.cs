using System.Net;
using System.Net.Http.Json;
using Chad_GPT_Models.API.AnswerModels;
using Chad_GPT_Models.API.ImageModels;
using Newtonsoft.Json;

namespace Chad_GPT_Client
{
    public class CGPTAnswersClient
    {
        private  HttpClient _client;
        private  string _answerPath;
        
        private  string _key;
        private readonly Secrets _secrets;
        public CGPTAnswersClient()
        {
            _client = new HttpClient();
            _answerPath = "https://api.openai.com/v1/completions";
            _secrets = new Secrets();
            _key = _secrets.ChadGPTKey;
        }
        public async Task<AnswerRoot> AnswerPrompt(string question)
        {
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
        
    }
}