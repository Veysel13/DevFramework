using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using DevFramework.Core.Functions;
using DevFramework.Core.Functions.ComplexType;
using DevFramework.Core.Functions.Concrete;
using DevFramework.Core.Functions.ImageService.Abstract;
using DevFramework.Northwind.Business.Abstract;
using DevFramework.Northwind.DataAccess.Abstract;
using DevFramework.Northwind.DataAccess.Concrete.EntityFramework;
using DevFramework.Northwind.Entities.Concrete;

namespace DevFramework.Northwind.Business.Concrete.Managers
{
   public class GaleryManager: IGaleryService
   {
       private IGaleryDal _galeryDal;
       private IImageService _imageService;
       public GaleryManager(IGaleryDal galeryDal,IImageService imageService)
       {
           _galeryDal = galeryDal;
           _imageService = imageService;

       }
        public void Add(HttpPostedFileBase image)
        {
            ImageDetail imagaDetail = _imageService.ImageSave(image,"Galery",300,300);

            _galeryDal.Add(new Galery
            {
                ThumpImage = imagaDetail.ThumpImage,
                Image = imagaDetail.Image
            });
        }

        public List<Galery> GetAll()
        {
           return _galeryDal.GetList();
        }
    }
}
