using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;
using System.Xml.Serialization;

namespace DirectoryExtensionDeleter.classes
{
    public class GenUtil
    {

        /// <summary>
        /// </summary>
        public static string NVL(object a, object b)
        {
            if (!IsNull(a))
            {
                return SafeTrim(a);
            }
            else if (!IsNull(b))
            {
                return SafeTrim(b);
            }
            else
            {
                return "";
            }
        }

        /// <summary>
        /// </summary>
        public static string ToNull(object x)
        {
            if ((x == null)
                || (Convert.IsDBNull(x))
                || x.ToString().Trim().Length == 0)
                return null;
            else
                return x.ToString();
        }

        /// <summary>
        /// </summary>
        public static bool IsNull(object x)
        {
            if ((x == null)
                || (Convert.IsDBNull(x))
                || x.ToString().Trim().Length == 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// </summary>
        public static string SafeTrim(object x)
        {
            if (IsNull(x))
                return "";
            else
                return x.ToString().Trim();
        }

        /// <summary>
        /// If not valid returns 0.
        /// </summary>
        public static int SafeToNum(object o)
        {
            if (IsNull(o))
                return 0;
            else
            {
                if (IsInt(o))
                    return int.Parse(o.ToString());
                else
                    return 0;
            }
        }

        /// <summary>
        /// If not valid returns 0.
        /// </summary>
        public static double SafeToDouble(object o)
        {
            if (IsNull(o))
                return -1;
            else
            {
                double test;
                if (!double.TryParse(o.ToString(), out test))
                    return -1;
                else
                    return test;
            }
        }

        /// <summary>
        /// If not valid returns false.
        /// </summary>
        public static bool SafeToBool(object o)
        {
            if (IsNull(o))
                return false;
            else
            {
                bool result;
                if (!bool.TryParse(o.ToString(), out result))
                {
                    if (o.ToString() == "1" || o.ToString().Trim().ToLower() == "yes" || o.ToString().Trim().ToLower() == "true")
                        return true;
                    else
                        return false;
                }
                else
                    return result;
            }
        }

        /// <summary>
        /// If not valid returns 01/01/1900 12:00:00 AM.
        /// </summary>
        public static DateTime SafeToDateTime(object o)
        {
            if (IsNull(o))
                return DateTime.Parse("01/01/1900 12:00:00 AM");
            else
            {
                DateTime dummy;

                if (IsInt(o))
                    return new DateTime(Convert.ToInt64(o)); // use ticks
                else
                {
                    if (DateTime.TryParse(o.ToString(), out dummy))
                        return dummy;
                    else
                        return DateTime.Parse("01/01/1900 12:00:00 AM"); ;
                }
            }
        }

        /// <summary>
        /// </summary>
        public static bool IsInt(object o)
        {
            if (IsNull(o))
                return false;

            Int64 dummy = 0;
            return Int64.TryParse(o.ToString(), out dummy);
        }

        /// <summary>
        /// </summary>
        public static bool IsDouble(object o)
        {
            if (IsNull(o))
                return false;

            Double dummy = 0;
            return Double.TryParse(o.ToString(), out dummy);
        }

        /// <summary>
        /// Trims and converts to upper case.
        /// </summary>
        public static string SafeToUpper(object o)
        {
            if (IsNull(o))
                return "";
            else
                return SafeTrim(o).ToUpper();
        }

        /// <summary>
        /// </summary>
        public static string SafeToProperCase(object o)
        {
            if (IsNull(o))
                return "";
            else
            {
                if (o.ToString().Trim().Length == 1)
                    return o.ToString().Trim().ToUpper();
                else
                    return o.ToString().Trim().Substring(0, 1).ToUpper() + o.ToString().Trim().Substring(1).ToLower();
            }
        }

        /// <summary>
        /// </summary>
        public static string SafeGetArrayVal(string[] list, int index)
        {
            return index < list.Length ? SafeTrim(list[index]) : "";
        }

        /// <summary>
        /// </summary>
        public static string SafeGetArrayVal(List<string> list, int index)
        {
            return index < list.Count ? SafeTrim(list[index]) : "";
        }

        /// <summary>
        /// </summary>
        public static string NormalizeEol(string s)
        {
            return Regex.Replace(SafeTrim(s), @"\r\n|\n\r|\n|\r", "\r\n");
        }

    }
}
