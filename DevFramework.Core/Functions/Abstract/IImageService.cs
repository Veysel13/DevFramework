using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using DevFramework.Core.Functions.ComplexType;

namespace DevFramework.Core.Functions.ImageService.Abstract
{
   public interface IImageService
   {
       ImageDetail ImageSave(HttpPostedFileBase file, string isim, int height = 100, int witdh = 100);
       string Thumnail(HttpPostedFileBase file, string name, int height, int witdh);
   }
}
