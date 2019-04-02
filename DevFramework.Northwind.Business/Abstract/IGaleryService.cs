using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using DevFramework.Northwind.Entities.Concrete;

namespace DevFramework.Northwind.Business.Abstract
{
   public interface IGaleryService
   {
       void Add(HttpPostedFileBase image);
       List<Galery> GetAll();
   }
}
