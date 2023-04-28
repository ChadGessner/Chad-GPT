using Chad_GPT_Models.DBModels;
using Chad_GPT_Models.HttpRequestModels;
using Chad_GPT_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chad_GPT_Domain
{
    
    public class QuestionInteractor
    {
        private QuestionRepository _db;
        public QuestionInteractor()
        {
            _db = new QuestionRepository();
        }
        public QuestionCategory InsertQuestionCategory(QuestionCategory questionCategory)
        {
            
            return _db.InsertCategory(questionCategory);
        }
        public QuestionAnswer InsertQuestionAnswer(QuestionAnswerRequestRoot model)
        {


            QuestionCategory cat = QuestionAnswerRequestRoot.GetQuestionCategoryFromQuestionAnswerRoot(model);
            User user = QuestionAnswerRequestRoot.GetUserFromQuestionAnswerRequestRoot(model);
            QuestionAnswer questionAnswer = QuestionAnswerRequestRoot.GetQuestionAnswerFromQuestionAnswerRequestRoot(model);

            return _db.InsertQuestionAnswer(questionAnswer, user, cat);
            
        }
        public List<QuestionCategory>? GetAllCategories()
        {
            List<QuestionCategory>? list = _db.GetAllCategories();
            if(list == null)
            {
                return null;
            }
            return list;
        }
    }
}
