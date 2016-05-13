using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GPLib.DAL;

namespace GPPlatform.DB
{
    public class DBContext
    {
        public static GPEntities GetContext()
        {
            return new GPEntities();
        }
    }
}