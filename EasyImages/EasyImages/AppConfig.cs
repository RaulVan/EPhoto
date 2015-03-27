using System;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyImages
{
   public static class AppConfig
    {
        /// <summary> 
        /// 是否首次
        /// </summary> 
        public static bool IsRunFirst
        {
            get
            {
                return IsolatedStorageSettings.ApplicationSettings.Contains("IsRunFirst") ? (bool)IsolatedStorageSettings.ApplicationSettings["IsRunFirst"] : false;
            }
            set
            {
                IsolatedStorageSettings.ApplicationSettings["IsRunFirst"] = value;
                IsolatedStorageSettings.ApplicationSettings.Save();
            }
        }

       
        public static double FontSize
        {
            get
            {
                return IsolatedStorageSettings.ApplicationSettings.Contains("FontSize") ? (double)IsolatedStorageSettings.ApplicationSettings["FontSize"] : 21;
            }
            set
            {
                IsolatedStorageSettings.ApplicationSettings["FontSize"] = value;
                IsolatedStorageSettings.ApplicationSettings.Save();
            }
        }

        public static string TextMsgString
        {
            get
            {
                return IsolatedStorageSettings.ApplicationSettings.Contains("TextMsgString") ? (string)IsolatedStorageSettings.ApplicationSettings["TextMsgString"] : "劳 Raul";
            }
            set
            {
                IsolatedStorageSettings.ApplicationSettings["TextMsgString"] = value;
                IsolatedStorageSettings.ApplicationSettings.Save();
            }
        }
    }
}
