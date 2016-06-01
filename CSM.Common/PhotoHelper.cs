using System;
using System.Collections.Generic;
using System.Configuration;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

namespace CSM.Common
{
    public class PhotoHelper
    {
        static string wapPhotoUrl = "";
        static string wapPhotoPath = "";

        static PhotoHelper()
        {
            wapPhotoUrl = ConfigurationManager.AppSettings[Constant.AppKeys.WapPhotoRoot];

            if (HttpContext.Current != null)
            {
                wapPhotoPath = HttpContext.Current.Server.MapPath(wapPhotoUrl);
            }
        }

        public static dynamic SavePhotoWithThumb(HttpPostedFile file)
        {
            string fileName = "";
            string prefix = "";

            DateTime timespan = DateTime.Now;

            fileName = timespan.ToString("yyyyMMddHHmmssfff") + "_thumbnail" + Path.GetExtension(file.FileName);
            prefix = string.Format("{0}/{1}/", wapPhotoUrl, timespan.ToString("yyyyMMdd"));

            //save thumbnail
            SavePhoto(file, prefix + fileName);

            //orignal photo
            fileName = fileName.Replace("_thumbnail", "");
            SavePhoto(file, prefix + fileName);

            dynamic photoInfo = new ExpandoObject();
            photoInfo.FileName = fileName;
            photoInfo.Prefix = prefix;

            return photoInfo;
        }

        private static void SavePhoto(HttpPostedFile file, string photoUrl)
        {
            string photoLocal = HttpContext.Current.Server.MapPath(photoUrl);
            string dir = Path.GetDirectoryName(photoLocal);

            if (!Directory.Exists(dir)) Directory.CreateDirectory(dir);

            file.SaveAs(photoLocal);
        }

        public static string SavePhoto(string orgName, string fileName = "")
        {
            string photoUrl = "";

            DateTime timespan = DateTime.Now;

            if (string.IsNullOrEmpty(fileName))
            {
                photoUrl = string.Format("{0}/{1}/{2}",
                                            wapPhotoUrl,
                                            timespan.ToString("yyyyMM"),
                                            timespan.ToString("yyyyMMddHHmmssfff") + Path.GetExtension(orgName));
            }
            else
            {
                photoUrl = string.Format("{0}/{1}/{2}",
                            wapPhotoUrl,
                            fileName.Substring(0, 6),
                            fileName);

            }            

            string photoLocal = HttpContext.Current.Server.MapPath(photoUrl);
            string dir = Path.GetDirectoryName(photoLocal);

            if (!Directory.Exists(dir)) Directory.CreateDirectory(dir);

            //save

            return photoUrl;
        }

        public static void DeletePhoto(string photoUrl)
        {
            string photoLocal = HttpContext.Current.Server.MapPath(photoUrl);
            if (File.Exists(photoLocal)) File.Delete(photoLocal);
        }
    }
}
