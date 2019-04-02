using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using DevFramework.Core.CrossCuttingConcerns.Validation.FluentValidation;
using DevFramework.Northwind.Business.Abstract;
using DevFramework.Northwind.Business.ValidationRules.FluentValidation;
using DevFramework.Northwind.DataAccess.Abstract;
using DevFramework.Northwind.Entities.Concrete;
using DevFramework.Core.Aspects.Postsharp;
using DevFramework.Core.Aspects.Postsharp.CacheAspects;
using DevFramework.Core.Aspects.Postsharp.TransactionAspects;
using DevFramework.Core.Aspects.Postsharp.ValidationAspects;
using DevFramework.Core.CrossCuttingConcerns.Caching.Microsoft;
using DevFramework.Core.DataAccess;
using DevFramework.Core.CrossCuttingConcerns.Logging.Log4Net.Logger;
using DevFramework.Core.Aspects.Postsharp.LogAspects;
using DevFramework.Core.Aspects.Postsharp.PerformanceAspects;
using System.Threading;
using DevFramework.Core.Aspects.Postsharp.AuthorizationAspects;

namespace DevFramework.Northwind.Business.Concrete.Managers
{
    //manager ustunde bunların calısmasını saglayabılırız
    //yada tım managerların loglanmasını ıstıyorsak busıness altındakı propertıesın ıcındekı assmblyınfo ıcıne eklıyoruz
    //[LogAspect(typeof(FileLogger))]
    //[LogAspect(typeof(DatabaseLogger))]
    public class ProductManager : IProductService
    {
        private IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        [CacheAspect(typeof(MemoryCacheManager))]
        //[LogAspect(typeof(DatabaseLogger))]
        //[LogAspect(typeof(FileLogger))]
        //asebly sevıyesınde yazabılecegımız gıbı bu metot ıcın ozellestırebılırız
        [PerformanceCounterAspect(1)]
        [SecuredOperation(Roles="Admin,Editor,Student")]
        public List<Product> GetAll()
        {
            Thread.Sleep(3000);
            return _productDal.GetList();

        }

        public Product GetById(int id)
        {
            return _productDal.Get(p => p.ProductId == id);
        }

        [FluentValidationAspect(typeof(ProductValidatior))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        //[LogAspect(typeof(FileLogger))]
        public Product Add(Product product)
        {
            //https://www.postsharp.net/downloads/postsharp-4.2/v4.2.17/PostSharp-4.2.17.exe
            //post shap kuruyourz ve manage nuget paketden core,business ve test katmanına ındırıyoruz katmanına indiriyoruz 4.2.17 de aynı versıyonu ındırıyoruz
            // ValidatorTool.FluentValidate(new ProductValidatior(), product);
            return _productDal.Add(product);
        }

        [FluentValidationAspect(typeof(ProductValidatior))]
        public Product Update(Product product)
        {
            return _productDal.Update(product);
        }

        [TransactionScopeAspect]
        [FluentValidationAspect(typeof(ProductValidatior))]
        public void TransactionalOperation(Product product1, Product product2)
        {
            //using using System.Transactions;
            _productDal.Add(product1);
            // Business Codes
            _productDal.Update(product2);
        }
    }
}
