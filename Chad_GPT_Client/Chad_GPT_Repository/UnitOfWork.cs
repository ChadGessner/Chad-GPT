using Chad_GPT_Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chad_GPT_Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        public IUserRepository User { get; private set; }
        public IQuestionRepository Question { get; private set; }
        public IImageRepository Image { get; private set; }
        public IQuestionCategoryRepository QuestionCategory { get; private set; }
        private readonly ApplicationDbContext _db;
        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            User = new UserRepository(_db);
            Question = new QuestionRepository(_db);
            Image = new ImageRepository(_db);

        }
        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
