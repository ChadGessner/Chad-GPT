using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chad_GPT_Models.DBModels
{
    public class QuestionAnswer
    {
        public int Id { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
        public DateTime PostedDate { get; set; }
        public int CategoryId { get; set; }
        public virtual QuestionCategory Category { get; set; }
        public int UserId { get; set; }
        public virtual User Poster { get; set; }
        
    }
}
