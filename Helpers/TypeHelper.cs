using System;
using System.Collections.Generic;
using System.Text;

namespace DBMS
{
    public class TypeHelper
    {
        public static string GetType(object obj)
        {
            string type = obj.GetType().ToString();
            switch (type.Trim().ToLower())
            {
                case "system.boolean":
                    return (Convert.ToBoolean(obj) == true ? "1" : "0");
                case "system.string":
                    return string.Format("'{0}'", SqlGenHelper.QuoteSQLString(obj));
                case "system.datetime":
                    string time = SqlGenHelper.QuoteSQLString(obj);
                    if (TypeHelper.IsDateTime(time) == true)
                        time = System.DateTime.Parse(time).ToString("yyyy-MM-dd HH:mm:ss");
                    else
                        time = "";
                    return string.Format("'{0}'", time);
                case "system.byte[]":
                    return string.Format("'{0}'", Convert.ToBase64String((byte[])obj));
                default:
                    if (obj == System.DBNull.Value)
                        return "NULL";
                    else
                        return Convert.ToString(obj);
            }
        }

        public static bool IsNumeric(Object objValue)
        {
            bool res = false;
            try
            {
                double y = Convert.ToDouble(objValue);
                res = true;
                return res;
            }
            catch
            {
                res = false;
            }

            try
            {                
                int x = Convert.ToInt32(objValue);                
                res = true;
                return res;
            }
            catch
            {
                res = false;
            }

            return res;
        }
        public static bool IsDateTime(string sDateTime)
        {
            bool res = false;

            try
            {
                System.DateTime.Parse(sDateTime);
                res = true;
            }
            catch
            {
                res = false;
            }

            return res;
        }
    }
}
