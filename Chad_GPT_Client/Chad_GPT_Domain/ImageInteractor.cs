using Chad_GPT_Models.DBModels;
using Chad_GPT_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chad_GPT_Domain
{
    public class ImageInteractor
    {
        private ImageRepository _db;
        public ImageInteractor()
        {
            _db = new ImageRepository();
        }
        public List<Image> InsertImage(User user, Image image)
        {
            return new List<Image>(); //_db.InsertImage(user, image);
        }
    }
}
