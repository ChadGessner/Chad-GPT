using Chad_GPT_Models.DBModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Chad_GPT_Domain;
using Chad_GPT_Models.HttpRequestModels;
using System.Text.Json.Nodes;

namespace Chad_GPT_Web_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private UserInteractor _db;

        public UserController()
        {
            _db = new UserInteractor();
        }
        [HttpPost(nameof(Login))]
        public User Login([FromBody] JsonObject user)
        {
            
            LoginRequestModel loggedIn = JsonConvert.DeserializeObject<LoginRequestModel>(user.ToString());
            return _db.Login(loggedIn.userName, loggedIn.password);
        }
        [HttpPost(nameof(Register))]
        public User Register([FromBody] JsonObject user)
        {
            Console.WriteLine(user);
            RegisterRequestModel registeredUser = JsonConvert.DeserializeObject<RegisterRequestModel>(user.ToString());
            
            return _db.Register(registeredUser);
        }
    }
}
