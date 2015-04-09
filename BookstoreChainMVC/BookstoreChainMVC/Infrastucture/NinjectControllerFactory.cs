using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Ninject;
using System.Configuration;
using BookstoreChain.Domain.Abstract;
using BookstoreChain.Domain.Concrete;
using BookstoreChain.Domain.Entities;

namespace BookstoreChainMVC.Infrastucture
{
    public class NinjectControllerFactory : DefaultControllerFactory
    {
        private IKernel ninjectKernal;

        public NinjectControllerFactory()
        {
            ninjectKernal = new StandardKernel();
            AddBindings();
        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            return controllerType == null 
                ? null 
                : (IController)ninjectKernal.Get(controllerType);
        }

        private void AddBindings()
        {
            ninjectKernal.Bind<IBookRepository>().To<EFBookRepository>();
            ninjectKernal.Bind<IAuthorRepository>().To<EFAuthorRepository>();
            ninjectKernal.Bind<IGenreRepository>().To<EFGenreRepository>();
            ninjectKernal.Bind<IStoreRepository>().To<EFStoreRepository>();
        }
    }
}