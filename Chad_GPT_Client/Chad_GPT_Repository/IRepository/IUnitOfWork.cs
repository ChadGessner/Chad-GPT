using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chad_GPT_Models;
namespace Chad_GPT_Repository.IRepository
{
    public interface IUnitOfWork
    {
        IImageRepository Image { get; }
        IUserRepository User { get; }
        IQuestionRepository Question { get; }
        IQuestionCategoryRepository QuestionCategory { get; }
        void Save();
    }
}
