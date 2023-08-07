using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace BilBasarEgitim.Methods
{
    public class CustomMethod
    {
        public static string ConnectionString()
        {
            var cs = "server=localhost;port=3306;database=bilbasaregitim;user id=root";
            return cs;
        }

        public static DateTime TurkeyTime()
        {
            DateTime now = DateTime.Now;
            TimeZoneInfo turkeyTime = TimeZoneInfo.FindSystemTimeZoneById("Turkey Standard Time");
            DateTime turkeyTimeNow = TimeZoneInfo.ConvertTime(now, turkeyTime);
            return turkeyTimeNow;
        }

        public static string DocumentUpload(HttpPostedFileBase file)
        {
            string fileName = Guid.NewGuid().ToString() + "-" + Path.GetFileName(file.FileName);
            string virtualPath = "~/Upload/Documents/" + fileName;
            string physicalPath = HttpContext.Current.Server.MapPath(virtualPath);

            file.SaveAs(physicalPath);
            return fileName;
        }
    }
}