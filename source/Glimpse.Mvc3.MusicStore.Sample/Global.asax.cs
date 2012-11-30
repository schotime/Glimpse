﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MvcMusicStore
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {

            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "BlogArchive",
                "Archive/{entryDate}",
                new { controller = "Blog", action = "Archive" },
                new { entryDate = @"d{2}-d{2}-d{4}" }
            );

            routes.MapRoute(
                "Product",
                "Product/Insert",
                new { controller = "Product", action = "Insert" },
                new { Grendal = new HttpMethodConstraint("POST") }
            );

            routes.MapRoute(
                "DefaultBrowse", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Browse", id = UrlParameter.Optional }, // Parameter defaults
                new { action = @"Index" }
            );


            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );

            routes.MapRoute(
                "DefaultTest", // Route name
                "{controller}/{action}/{id}/{test}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional, test = 1 } // Parameter defaults
            ); 
        }

        protected void Application_Start()
        {
            System.Data.Entity.Database.SetInitializer(new MvcMusicStore.Models.SampleData());

            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);
        }
    }
}