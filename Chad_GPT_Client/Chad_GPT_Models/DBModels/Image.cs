using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chad_GPT_Models.DBModels
{
    public class Image
    {
        public int Id { get; set; }
        public string ImagePrompt { get; set; }
        public string ImagePath { get; set; }
        public DateTime Created { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public int CategoryId { get; set; }
        public virtual ImageCategory Category { get; set; }
    }
}
