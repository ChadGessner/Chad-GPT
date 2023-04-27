using Chad_GPT_Client;
using Chad_GPT_Domain;
using Chad_GPT_Models.DBModels;
using Chad_GPT_Models.HttpRequestModels;
using Chad_GPT_Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text.Json.Nodes;

namespace Chad_GPT_Web_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QandAController : ControllerBase
    {
        
        private readonly CGPTAnswersClient _client;
        private readonly QuestionInteractor _db;
    //    public QandAController()
    //    {
            
    //        _db = new QuestionInteractor();
    //        _client = new CGPTAnswersClient();
    //    }
    //    [HttpGet(nameof(GetQuestionCategories))]
    //    public List<QuestionCategoryResponseModel>? GetQuestionCategories()
    //    {
    //        List<QuestionCategory>? list = _db.GetAllCategories();
    //        if(list == null || list.Count == 0)
    //        {
    //            return null;
    //        }
    //        return QuestionCategoryResponseModel.GetResponseModelList(list);
    //    }
    //    [HttpPost(nameof(PostCategory))]
    //    public QuestionCategory PostCategory([FromBody] JsonObject categoryData)
    //    {
    //        QuestionCategoryRequestModel model;
            
            
                
    //            model = JsonConvert
    //            .DeserializeObject<QuestionCategoryRequestModel>(categoryData.ToString());
               
    //            QuestionCategory fuck =  QuestionCategoryRequestModel.GetQuestionCategoryFromQuestionCategoryRequestModel(model);

    //        return _db.InsertQuestionCategory(fuck);
    //    }
    //    [HttpPost(nameof(PostAnswer))]
    //    public QuestionAnswerRequestRoot PostAnswer([FromBody] JsonObject answerData)
    //    {
    //        Console.WriteLine(answerData + "ok");
    //        QuestionAnswerRequestRoot root = JsonConvert.DeserializeObject<QuestionAnswerRequestRoot>(answerData.ToString());
    //        User user = _db.
    //        return root;
    //    }
    //    [HttpGet("AskChadGPT/{question}")]
    //    public KeyValuePair<string, string> AskChadGPT(string question)
    //    {
    //        var request = _client.AnswerPrompt(question);
    //        return new KeyValuePair<string, string>("data", request.Result.choices[0].text);
    //    }
    }
}
