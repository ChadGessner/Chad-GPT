using Chad_GPT_Models.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chad_GPT_Models.HttpRequestModels
{
    public class QuestionCategoryResponseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public static QuestionCategoryResponseModel GetResponseModelFromDb(QuestionCategory cat)
        {
            return new QuestionCategoryResponseModel()
            {
                Id = cat.Id,
                Name = cat.Name,
                Description = cat.Description,
            };
        }
        public static List<QuestionCategoryResponseModel> GetResponseModelList(List<QuestionCategory> cats)
        {
            return cats
                .Select(x=> QuestionCategoryResponseModel.GetResponseModelFromDb(x))
                .ToList();
        }
    }
}
