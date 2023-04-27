using Chad_GPT_Models.DBModels;
using Chad_GPT_Models.HttpRequestModels;
using Chad_GPT_Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using Chad_GPT_Repository.IRepository;

namespace Chad_GPT_Repository
{
    public class QuestionRepository : Repository<QuestionAnswer>, IQuestionRepository
    {
        private ApplicationDbContext _db = new ApplicationDbContext();
        private IConfigurationRoot _configuration;
        private DbContextOptionsBuilder<ApplicationDbContext> _optionsBuilder;
        public QuestionRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
            BuildOptions();
        }
        private void BuildOptions()
        {
            _configuration = ConfigurationBuilderSingleton.ConfigurationRoot;
            _optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            _optionsBuilder.UseSqlServer(_configuration.GetConnectionString("StringyConnections"));
        }
        public QuestionCategory GetCategoryByNameAndDescription(string name, string description)
        {
            QuestionCategory fromDb = _db.Categories
                .FirstOrDefault(x=> x.Name == name && x.Description == description);
            if(fromDb == null)
            {
                return null;
            }
            return fromDb;
        }
        public QuestionCategory GetCategoryById(int id)
        {
            QuestionCategory fromDb = _db.Categories
                .FirstOrDefault(x => x.Id == id);
            if (fromDb == null)
            {
                return null;
            }
            return fromDb;
        }
        public QuestionCategory InsertCategory(QuestionCategory category)
        {
            _db.Categories.Add(category);
            _db.SaveChanges();
            return GetCategoryByNameAndDescription(category.Name, category.Description);
        }
        public List<QuestionCategory>? GetAllCategories()
        {
            List <QuestionCategory>? list = _db.Categories.ToList();
            if(list == null)
            {
                return null;
            }
            return list;
        }
    }
}
