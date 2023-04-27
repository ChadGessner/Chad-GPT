using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chad_GPT_Models.HttpRequestModels
{
    public class UserRequestResponseModel
    {
        public int id {  get; set; }
        public string userName { get; set; }
        public string password { get; set; }
        public string email { get; set; }
    }
}
