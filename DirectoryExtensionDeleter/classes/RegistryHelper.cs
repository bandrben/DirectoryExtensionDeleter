using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DirectoryExtensionDeleter.classes
{
    public class RegistryHelper
    {

        const string REG_KEY_APP_NAME = "BenDirectoryExtensionDeleter";
        const string REG_KEY_VALUE_PATH1 = "path1";
        const string REG_KEY_VALUE_EXTS = "exts";

        /// <summary>
        /// </summary>
        public static bool GetRegStuff(out string path1, out string exts, out string msg)
        {
            path1 = "";
            exts = "";
            msg = "";

            try
            {
                var key = Registry.CurrentUser.OpenSubKey("Software");
                var appKey = key.OpenSubKey(REG_KEY_APP_NAME);

                if (appKey != null)
                {
                    path1 = GenUtil.SafeTrim(appKey.GetValue(REG_KEY_VALUE_PATH1));
                    exts = GenUtil.SafeTrim(appKey.GetValue(REG_KEY_VALUE_EXTS));
                }

            }
            catch (Exception ex)
            {
                msg = "Registry read error: " + ex.Message;
            }

            return msg == "";
        }

        /// <summary>
        /// </summary>
        public static bool SaveRegStuff(string path1, string exts, out string msg)
        {
            msg = "";

            try
            {
                var key = Registry.CurrentUser.OpenSubKey("Software", true);
                var appKey = key.OpenSubKey(REG_KEY_APP_NAME, true);

                if (appKey == null)
                {
                    appKey = key.CreateSubKey(REG_KEY_APP_NAME);
                }

                appKey.SetValue(REG_KEY_VALUE_PATH1, GenUtil.SafeTrim(path1));
                appKey.SetValue(REG_KEY_VALUE_EXTS, GenUtil.SafeTrim(exts));

            }
            catch (Exception ex)
            {
                msg = "Registry save error: " + ex.Message;
            }

            return msg == "";
        }

    }
}
