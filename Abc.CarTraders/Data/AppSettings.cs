using System;
using System.IO;

namespace Daph.Breeding.Data
{
    class AppSettings
    {
        public static string ServerIp
        {
            get { return Properties.Settings.Default.ServerIp; }
            set
            {
                Properties.Settings.Default.ServerIp = value;
                Properties.Settings.Default.Save();
            }
        }

        public static int Port
        {
            get { return Properties.Settings.Default.Port; }
            set
            {
                Properties.Settings.Default.Port = value;
                Properties.Settings.Default.Save();
            }
        }

        public static string LastUsername
        {
            get { return Properties.Settings.Default.LastUsername; }
            set
            {
                Properties.Settings.Default.LastUsername = value;
                Properties.Settings.Default.Save();
            }
        }

        public static string DbUserId
        {
            get { return Properties.Settings.Default.DbUserId; }
            set
            {
                Properties.Settings.Default.DbUserId = value;
                Properties.Settings.Default.Save();
            }
        }

        public static string DbPassword
        {
            get { return Properties.Settings.Default.DbPassword; }
            set
            {
                Properties.Settings.Default.DbPassword = value;
                Properties.Settings.Default.Save();
            }
        }

        public static int ConnectionTimeout
        {
            get { return Properties.Settings.Default.ConnectionTimeout; }
            set
            {
                Properties.Settings.Default.ConnectionTimeout = value;
                Properties.Settings.Default.Save();
            }
        }

        public static int ColorIndex
        {
            get { return Properties.Settings.Default.ColorIndex; }
            set
            {
                Properties.Settings.Default.ColorIndex = value;
                Properties.Settings.Default.Save();
            }
        }

        public static string DaphFolderPath
        {
            get { return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDoc‌​uments), "Daph"); }
        }

    }
}
