using Chad_GPT_Models.DBModels;
using Chad_GPT_Repository;
using Chad_GPT_Repository.IRepository;
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
        private readonly IUnitOfWork _unitOfWork;
        public ImageInteractor(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public List<Image> InsertImage(User user, Image image)
        {
            return new List<Image>(); //_db.InsertImage(user, image);
        }
    }
}
