using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chad_GPT_Models.DBModels
{
    public class ImageCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int ImageId { get; set; }
        public virtual List<Image> Images { get; set; }
    }
}
