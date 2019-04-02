using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Hosting;
using DevFramework.Core.Functions.ComplexType;
using DevFramework.Core.Functions.ImageService.Abstract;

namespace DevFramework.Core.Functions.Concrete
{
   public class ImageManager:IImageService
    {
        public ImageDetail ImageSave(HttpPostedFileBase file, string isim, int height = 100, int witdh = 100)
        {
            string extension = file.ContentType.Split('/')[1];
            string filename = $"{isim}_{Guid.NewGuid()}";
            string path = $"/Medya/";
            file.SaveAs(HostingEnvironment.MapPath($"{path}{filename}.{extension}"));

            string thumpImage = Thumnail(file,$"{filename}.{extension}",height,witdh);
            var imageDetail = new ImageDetail
            {
                ThumpImage = thumpImage,
                Image = $"{path}{filename}.{extension}"
            };
            return imageDetail;
        }

        public string Thumnail(HttpPostedFileBase file, string name,int height,int witdh)
        {
            int Genislik = witdh; //Thumbnail'in genişliği
            int Yukseklik = height; //Thumbnail'in yüksekliği
            Bitmap Thumbnail = new Bitmap(Genislik, Yukseklik);
            // Genişlik ve yüksekliği belirterek yeni bir Bitmap oluşturuyorum.
            Bitmap OrjinalResim = new Bitmap(file.InputStream);
            // Gelen resim dosyasını stream ederek başka bir Bitmap oluşturuyorum.
            Graphics Kanvas = Graphics.FromImage(Thumbnail);
            // Yeni bir kanvas oluşturuyorum. Resmi bunun üzerine çizeceğim.
            Kanvas.DrawImage(OrjinalResim, new Rectangle(0, 0, Genislik, Yukseklik), 0, 0, OrjinalResim.Width, OrjinalResim.Height, GraphicsUnit.Pixel);
            // Resmi çiziyorum.
            string path = $"/Medya/Thump/";
            // Orjinal resmi kaydediyorum.
            Thumbnail.Save(HostingEnvironment.MapPath($"{path}{name}"), System.Drawing.Imaging.ImageFormat.Jpeg);
            // Thumbnail resmi kaydediyorum.

            return $"{path}{name}";
        }
    }
}
