using Chad_GPT_Models.DBModels;
using Chad_GPT_Models.HttpRequestModels;
using Chad_GPT_Repository;
using Chad_GPT_Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chad_GPT_Domain
{
    
    public class QuestionInteractor
    {
        private readonly IUnitOfWork _unitOfWork;
        private QuestionRepository _db;
        public QuestionInteractor(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        /// this is all fucked up for now...
        public QuestionAnswerRequestRoot InsertQuestionCategory(QuestionAnswerRequestRoot model)
        {
            QuestionCategoryResponseModel cat;
            User user;



            return model;//_unitOfWork.Question.Add(model);
            
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
