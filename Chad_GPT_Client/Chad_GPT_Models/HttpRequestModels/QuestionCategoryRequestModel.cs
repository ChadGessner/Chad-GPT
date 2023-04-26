using Chad_GPT_Models.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chad_GPT_Models.HttpRequestModels
{
    public class QuestionCategoryRequestModel
    {
        public string name { get; set; }
        public string description { get; set; }

        public static QuestionCategory GetQuestionCategoryFromQuestionCategoryRequestModel(QuestionCategoryRequestModel model)
        {
            if(model == null)
            {
                return new QuestionCategory();
            }
            
            return new QuestionCategory()
            {
                Name = model.name,
                Description = model.description
                
            };
        }
    }
}
