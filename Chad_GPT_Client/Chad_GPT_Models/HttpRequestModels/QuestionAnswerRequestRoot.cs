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
            return new User()
            {
                Id = root.user.id,
                UserName = root.user.userName,
                Password = root.user.password,
                Email = root.user.email,

            };
        } 
        public static QuestionCategory GetQuestionCategoryFromQuestionAnswerRoot(QuestionAnswerRequestRoot root)
        {
            return new QuestionCategory() 
            {
                Id = root.category.Id,
                Name = root.category.Name,
                Description = root.category.Description,
            };
        }
        public static QuestionAnswer GetQuestionAnswerFromQuestionAnswerRequestRoot(QuestionAnswerRequestRoot root)
        {
            Console.WriteLine();
            return new QuestionAnswer()
            {
                Question = root.questionAnswer.question,
                Answer = root.questionAnswer.answer,
                PostedDate = DateTime.Now
            };
        }
    }
}