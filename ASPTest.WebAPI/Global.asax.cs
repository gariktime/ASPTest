﻿using ASPTest.BLL.Infrastructure;
using ASPTest.WebAPI.Util;
using Ninject;
using Ninject.Modules;
using Ninject.Web.WebApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace ASPTest.WebAPI
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //Automapper Initialization
            App_Start.AutomapperConfig.Initialize();

            ////внедрение зависимостей
            //NinjectModule module = new NinjectModules();
            //NinjectModule serviceModule = new ServiceModule("UsersDbConnection", "DepartmentsDbConnection");
            //var kernel = new StandardKernel(module, serviceModule);
            //var ninjectResolver = new Ninject.Web.WebApi.NinjectDependencyResolver(kernel);
            ////DependencyResolver.SetResolver(ninjectResolver); // MVC
            //GlobalConfiguration.Configuration.DependencyResolver = ninjectResolver; // Web API
        }
    }
}
