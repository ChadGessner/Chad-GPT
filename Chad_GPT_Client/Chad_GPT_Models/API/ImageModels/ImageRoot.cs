using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chad_GPT_Models.DBModels;

namespace Chad_GPT_Models.API.ImageModels
{

    public class ImageRoot
    {
        public int created { get; set; }
        public List<ImageUrl> data { get; set; }
        //public List<Image> GetImagesFromImageRoot(User user, ImageRoot root, ImageCategory? category)
        //{
        //    List<Image> images = new List<Image>();
        //    root.data.Select(x =>
        //    {
        //        if(x != null)
        //        {
        //            images.Add(new Image()
        //            {
        //                User = user,

        //            });
        //        }
        //    });
        //}
    }
}
