using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace processKR
{
    class CIni
    {

        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);

        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);

        [DllImport("kernel32")]
        private static extern IntPtr CreateFile(string fileName, uint DesiredAccess, uint ShareMode, uint SecurityAttributes, uint CreateDisposition, uint FlagAndAttributes, int hTemplateFile);

        public static string Save(string sec, string key, string val, string path)
        {
            long rt = 0;
            string strR;
            WritePrivateProfileString(sec, key, val, path);
            strR = rt.ToString();
            return strR;
        }

        public static string Load(string sec, string key, string def, string path)
        {
            int rt = 0;
            string strRt;
            StringBuilder sb = new StringBuilder(1024);
            rt = GetPrivateProfileString(sec, key, def, sb, 1024, path);
            strRt = sb.ToString();

            return strRt;
        }

        public static bool Load(string sec, string key, bool def, string path)
        {
            string sRs = Load(sec, key, def.ToString(), path);
            if (sRs.ToUpper() == "FALSE")
                return false;

            return true;
        }

        public static int Load(string sec, string key, int def, string path)
        {
            string sRs = Load(sec, key, def.ToString(), path);
            int nRs = 0;

            try
            {
                nRs = int.Parse(sRs);
            }
            catch (Exception)
            {
                nRs = 0;
            }

            return nRs;
        }
    }
}
