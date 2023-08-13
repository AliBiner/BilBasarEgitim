using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using Microsoft.Ajax.Utilities;

namespace BilBasarEgitim.Methods
{
    public class CustomMethod
    {
        //Connection String
        public static string ConnectionString()
        {
            var cs = "server=localhost;port=3306;database=bilbasaregitim;user id=root";
            return cs;
        }
        //DateTime
        public static DateTime TurkeyTime()
        {
            DateTime now = DateTime.Now;
            TimeZoneInfo turkeyTime = TimeZoneInfo.FindSystemTimeZoneById("Turkey Standard Time");
            DateTime turkeyTimeNow = TimeZoneInfo.ConvertTime(now, turkeyTime);
            return turkeyTimeNow;
        }

        //Cv Document Process
        public static string CvUpload(HttpPostedFileBase file)
        {
            if (file == null)
            {
                return null;
            }
            string fileName = Guid.NewGuid().ToString() + "-" + Path.GetFileName(file.FileName);
            string virtualPath = "~/Upload/Cvs/" + fileName;
            string physicalPath = HttpContext.Current.Server.MapPath(virtualPath);

            file.SaveAs(physicalPath);
            return fileName;
        }
        public static void CvDelete(string cvUrl)
        {
            string filePath = HttpContext.Current.Server.MapPath("~/Upload/Cvs/" + cvUrl);
            System.IO.File.Delete(filePath);
        }

        //Document Process
        public static string DocumentUpload(HttpPostedFileBase file)
        {
            if (file==null)
            {
                return null;
            }
            string fileName = Guid.NewGuid().ToString() + "-" + Path.GetFileName(file.FileName);
            string virtualPath = "~/Upload/Documents/" + fileName;
            string physicalPath = HttpContext.Current.Server.MapPath(virtualPath);

            file.SaveAs(physicalPath);
            return fileName;
        }
        public static void DocumentDelete(string documentUrl)
        {
            string filePath = HttpContext.Current.Server.MapPath("~/Upload/Documents/" + documentUrl);
            System.IO.File.Delete(filePath);
        }

        //Slider Image Process
        public static string SliderImageUpload(HttpPostedFileBase file)
        {
            if (file== null)
            {
                return null;
            }
            string fileName = Guid.NewGuid().ToString() + "-" + Path.GetFileName(file.FileName);
            string virtualPath = "~/Upload/Images/Slider/" + fileName;
            string physicalPath = HttpContext.Current.Server.MapPath(virtualPath);

            file.SaveAs(physicalPath);
            return fileName;

        }
        public static void SliderDelete(string documentUrl)
        {
            string filePath = HttpContext.Current.Server.MapPath("~/Upload/Images/Slider/" + documentUrl);
            System.IO.File.Delete(filePath);
        }

        //Notice Image Process
        public static string NoticeImageUpload(HttpPostedFileBase file)
        {
            if (file == null)
            {
                return null;
            }
            string fileName = Guid.NewGuid().ToString() + "-" + Path.GetFileName(file.FileName);
            string virtualPath = "~/Upload/Images/Notice/" + fileName;
            string physicalPath = HttpContext.Current.Server.MapPath(virtualPath);

            file.SaveAs(physicalPath);
            return fileName;

        }
        public static void NoticeImageDelete(string documentUrl)
        {
            string filePath = HttpContext.Current.Server.MapPath("~/Upload/Images/Notice/" + documentUrl);
            System.IO.File.Delete(filePath);
        }

        //News Image Process
        public static string NewsImageUpload(HttpPostedFileBase file)
        {
            if (file == null)
            {
                return null;
            }
            string fileName = Guid.NewGuid().ToString() + "-" + Path.GetFileName(file.FileName);
            string virtualPath = "~/Upload/Images/News/" + fileName;
            string physicalPath = HttpContext.Current.Server.MapPath(virtualPath);

            file.SaveAs(physicalPath);
            return fileName;

        }
        public static void NewsImageDelete(string documentUrl)
        {
            string filePath = HttpContext.Current.Server.MapPath("~/Upload/Images/News/" + documentUrl);
            System.IO.File.Delete(filePath);
        }

        //Academic Staff Image Process

        public static string AcademicStaffImageUpload(HttpPostedFileBase file)
        {
            if (file == null)
            {
                return null;
            }
            string fileName = Guid.NewGuid().ToString() + "-" + Path.GetFileName(file.FileName);
            string virtualPath = "~/Upload/Images/AcademicStaff/" + fileName;
            string physicalPath = HttpContext.Current.Server.MapPath(virtualPath);

            file.SaveAs(physicalPath);
            return fileName;

        }
        public static void AcademicStaffImageDelete(string documentUrl)
        {
            string filePath = HttpContext.Current.Server.MapPath("~/Upload/Images/AcademicStaff/" + documentUrl);
            System.IO.File.Delete(filePath);
        }
    }
}