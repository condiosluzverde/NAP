﻿using System.Web;
using System.Web.Mvc;

namespace Nap.Demo.Web.ClientMvc
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
