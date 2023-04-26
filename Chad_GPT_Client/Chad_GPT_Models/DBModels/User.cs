using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chad_GPT_Models.DBModels
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }   
        public DateTime Created { get; set; }
        public virtual List<QuestionAnswer> Answers { get; set; } = new List<QuestionAnswer>();
        public virtual List<Image> Images { get; set; } = new List<Image>();
    }
}
