using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MajorProject.shared
{
    public class CookieHelper
    {
        public static  HttpCookie createcookie(string name, string val, int time = 1)
        {
            HttpCookie c = new HttpCookie(name);
            c.Value = val;
            c.Expires = DateTime.Now.AddDays(time);
            return c;
        }
    }
}