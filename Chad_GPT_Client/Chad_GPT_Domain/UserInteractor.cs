using Chad_GPT_Models.DBModels;
using Chad_GPT_Models.HttpRequestModels;
using Chad_GPT_Repository;
using System.Reflection.Metadata;

namespace Chad_GPT_Domain
{
    public class UserInteractor
    {
        private AnswerRepository _db;
        
        public UserInteractor()
        {
            _db = new AnswerRepository();
        }

        public User Login(string userName, string password)
        {
            User user = _db.GetUserByUsernameAndPassword(userName, password);
            if (user == null)
            {
                return null;
            }
            
            return user;
        }
        public User GetUserById(int id)
        {
            return _db.GetUserById(id);
        }
        public User GetUserByUsernameAndPassword(string username, string password)
        {
            return _db.GetUserByUsernameAndPassword(username, password);
        }
        public User Register(RegisterRequestModel user)
        {
            if (_db.GetUserByUsernameAndPassword(user.userName, user.password) == null)
            {
                User createdUser = RegisterRequestModel.GetUserFromRegisterRequestModel(user);
                Console.WriteLine(createdUser);
                return _db.Register(createdUser);
                
            }
            return null;
        }
        
    }
}