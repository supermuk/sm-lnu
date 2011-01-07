using System;
using System.Collections.Generic;
using System.Text;

namespace DBMS
{
    public class TypeHelper
    {
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
