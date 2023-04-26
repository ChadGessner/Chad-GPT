using Chad_GPT_Models.DBModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Chad_GPT_Repository
{
    public class UserRepository
    {
        private ApplicationDbContext _db = new ApplicationDbContext();
        private IConfigurationRoot _configuration;
        private DbContextOptionsBuilder<ApplicationDbContext> _optionsBuilder;
        public UserRepository()
        {
            BuildOptions();
        }
        private void BuildOptions()
        {
            _configuration = ConfigurationBuilderSingleton.ConfigurationRoot;
            _optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            _optionsBuilder.UseSqlServer(_configuration.GetConnectionString("StringyConnections"));
        }
        public User Login(User user)
        {
            return _db.Users
                .FirstOrDefault(x => x == user);
        }
        public User GetUserById(int id)
        {
            return _db.Users
                .FirstOrDefault(x => x.Id == id);
        }
        public User GetUserByUsernameAndPassword(string username, string password)
        {
            return _db.Users
                .FirstOrDefault(x=> x.UserName == username && x.Password == password);  
        }
        public User GetUser(User user)
        {
            return _db.Users.FirstOrDefault(x => x == user);
        }
        public User Register(User user)
        {
            _db.Users.Add(user);
            _db.SaveChanges();
            return GetUser(user);
        }
    }
}