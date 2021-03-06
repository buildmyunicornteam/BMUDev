﻿using ALMS_DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using buildmyunicorn.Models;
using System.Configuration;
using System.Data;
using System.Web.Security;

namespace buildmyunicorn.Business_Layer
{
    public class CountryManager
    {
        public IEnumerable<Country> GetCountryList()
        {
            DataLayer obj = new DataLayer(ConfigurationManager.ConnectionStrings["ConnectionBuildMyUnicorn"].ConnectionString, Convert.ToInt32(ConfigurationManager.AppSettings["CommandTimeOut"]));
            return  obj.GetList<Country>(CommandType.StoredProcedure, "sp_get_country_list", null);
   
        }

    }
}