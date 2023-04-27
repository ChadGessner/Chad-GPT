using Chad_GPT_Models.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chad_GPT_Models.HttpRequestModels
{
    public class QuestionAnswerRequestRoot
    {
        public UserRequestResponseModel user { get; set; }
        public QuestionAnswerRequestModel questionAnswer { get; set; }
        public QuestionCategoryResponseModel category { get; set; }
        public static User GetUserFromQuestionAnswerRequestRoot(QuestionAnswerRequestRoot root)
        {
            return new User();
        }
    }
}
