using Chad_GPT_Models.DBModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Chad_GPT_Domain;
using Chad_GPT_Models.HttpRequestModels;
using System.Text.Json.Nodes;
using Chad_GPT_Repository.IRepository;

namespace Chad_GPT_Web_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private UserInteractor _db;
        private readonly IUnitOfWork _unitOfWork;
        public UserController(IUnitOfWork unitOfWork)
        {
            
            _unitOfWork = unitOfWork;
           // _db = new UserInteractor(unitOfWork);
        }
        [HttpPost(nameof(Login))]
        public User Login([FromBody] JsonObject user)
        {
            
            LoginRequestModel loggedIn = JsonConvert.DeserializeObject<LoginRequestModel>(user.ToString());
            //return _db.Login(loggedIn.userName, loggedIn.password);
            return _unitOfWork.User.GetFirstOrDefault(x => x.UserName == loggedIn.userName && x.Password == loggedIn.password);
        }
        //[HttpPost(nameof(Register))]
        //public User Register([FromBody] JsonObject user)
        //{
        //    Console.WriteLine(user);
        //    RegisterRequestModel registeredUser = JsonConvert.DeserializeObject<RegisterRequestModel>(user.ToString());
            
        //    return _db.Register(registeredUser);
        //}
    }
}
