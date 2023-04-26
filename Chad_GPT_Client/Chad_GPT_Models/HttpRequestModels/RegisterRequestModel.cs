using Chad_GPT_Models.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chad_GPT_Models.HttpRequestModels
{
    public class RegisterRequestModel
    {
        public string userName { get; set; }
        public string password { get; set; }
        public string email { get; set; }

        public static User GetUserFromRegisterRequestModel(RegisterRequestModel user)
        {
            return new User()
            {
                UserName = user.userName,
                Password = user.password,
                Email = user.email,
                Created = DateTime.Now
            };
        }
    }
}
