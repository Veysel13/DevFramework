using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevFramework.Core.Entities;

namespace DevFramework.Northwind.Entities.Concrete
{
   public class Galery:IEntity
    {
        public int Id { get; set; }
        public string ThumpImage { get; set; }
        public string Image { get; set; }
    }
}
