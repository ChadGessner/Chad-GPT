using Chad_GPT_Models.DBModels;
using Chad_GPT_Models.HttpRequestModels;
using Chad_GPT_Repository;
using Chad_GPT_Repository.IRepository;
using System.Reflection.Metadata;

namespace Chad_GPT_Domain
{
    public class UserInteractor
    {
        //private UserRepository _db;
        private readonly IUnitOfWork _unitOfWork;
        public UserInteractor(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public User Login(string userName, string password)
        {
            User user = _unitOfWork.User.GetFirstOrDefault(x=> x.UserName == userName && x.Password == password);
            if (user == null)
            {
                return null;
            }
            return user;
        }
        public User GetUserById(int id)
        {
            return _unitOfWork.User.GetFirstOrDefault(x=> x.Id == id);
        }
        //public User GetUserByUsernameAndPassword(string username, string password)
        //{
        //    return _unitOfWork.User.GetFirstOrDefault()
        //}
        //public User Register(RegisterRequestModel user)
        //{
        //    if (_db.GetUserByUsernameAndPassword(user.userName, user.password) == null)
        //    {
        //        User createdUser = RegisterRequestModel.GetUserFromRegisterRequestModel(user);
        //        Console.WriteLine(createdUser);
        //        return _db.Register(createdUser);
                
        //    }
        //    return null;
        //}
        
    }
}