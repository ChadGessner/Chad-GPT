using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chad_GPT_Models.DBModels
{
    public class QuestionCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual List<QuestionAnswer> Answers { get; set; } = new List<QuestionAnswer>();
    }
}
