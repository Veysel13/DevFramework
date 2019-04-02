using Ninject;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Routing;

namespace DevFramework.Core.Utilities.Mvc.Infrastructure
{
   public class NinjectControllerFactory:DefaultControllerFactory
    {
        //Install-Package Microsoft.AspNet.Mvc -Version 5.2.7
        //nuget den ninject indiriyoruz

        //gloabal.assax aekleme yapıyoruz
        private IKernel _kernel;

        public NinjectControllerFactory(INinjectModule module)
        {
            _kernel = new StandardKernel(module);
        }
        protected override IController GetControllerInstance(RequestContext requestContext,Type controllerType)
        {
           return controllerType==null ? null:(IController)_kernel.Get(controllerType);
        }

    }
}
