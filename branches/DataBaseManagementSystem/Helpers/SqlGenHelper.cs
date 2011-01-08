using System;
using System.Xml;
using System.IO;
using System.Collections;
using System.Data;
using System.Collections.Generic;
using System.Text;

namespace DBMS
{
    public class SqlGenHelper
    {
        public static string GenerateSql(string[] columns, string[] whereColumns, DataTable table, string tableName, QueryType type)
        {
            StringBuilder query = new StringBuilder("");

            for(int i = 0; i < table.Rows.Count; i++)
            {
                string s = "";
                switch (type)
                {
                    case QueryType.Insert:
                        s = GenerateSqlInsert(columns, table, tableName, i);
                        break;
                    case QueryType.Delete:
                        s = GenerateSqlDelete(columns, table, tableName, i);
                        break;
                    case QueryType.Update:
                        s = GenerateSqlUpdate(columns, whereColumns, table, tableName, i);
                        break;
                }
                query.Append(s);
                query.AppendLine();
            }

            return query.ToString();;
        }

        public static string GenerateSqlInsert(string[] columns, DataTable table, string tableName, int rowIndex)
        {
            StringBuilder cols = new StringBuilder("");

            foreach (string colname in columns)
            {
                if (cols.ToString() != "")
                    cols.Append(", ");

                cols.Append("[" + colname + "]");
            }
            DataRow drow = table.Rows[rowIndex];
            StringBuilder values = new StringBuilder("");
            foreach (string col in columns)
            {
                if (values.ToString() != "")
                    values.Append(", ");

                try
                {
                    values.Append(TypeHelper.GetType(drow[col]));
                }
                catch
                {
                    values.Append(string.Format("'{0}'", QuoteSQLString(drow[col])));
                }
            }
            StringBuilder query = new StringBuilder("");
            query.Append(string.Format("INSERT INTO [{0}] ({1}) ", tableName, cols.ToString()));
            query.AppendLine();
            query.Append('\t');
            query.Append(string.Format("VALUES({0});", values.ToString()));
            query.AppendLine();
            query.AppendLine();
            return query.ToString();
        }

        public static string GenerateSqlInsert(string[] columns, object[] values, DataTable table, string tableName, int rowIndex)
        {
            StringBuilder cols = new StringBuilder("");

            for(int i = 0; i < columns.Length; i++)
            {
                if (cols.ToString() != "")
                    cols.Append(", ");

                cols.Append("[" + columns[i] + "]");
            }
            //DataRow drow = table.Rows[rowIndex];
            StringBuilder vals = new StringBuilder("");
            for(int i = 0; i < values.Length; i++)
            {
                if (vals.ToString() != "")
                    vals.Append(", ");

                try
                {
                    vals.Append(TypeHelper.GetType(values[i]));
                }
                catch
                {
                    vals.Append(string.Format("'{0}'", QuoteSQLString(values[i])));
                }
            }
            StringBuilder query = new StringBuilder("");
            query.Append(string.Format("INSERT INTO [{0}] ({1}) ", tableName, cols.ToString()));
            query.AppendLine();
            query.Append('\t');
            query.Append(string.Format("VALUES({0});", vals.ToString()));
            query.AppendLine();
            query.AppendLine();
            return query.ToString();
        }

        public static string GenerateSqlUpdate(string[] columns, string[] whereColumns, DataTable table, string tableName, int rowIndex)
        {
            DataRow drow = table.Rows[rowIndex];
            StringBuilder values = new StringBuilder("");

            foreach (string col in columns)
            {
                StringBuilder newValues = new StringBuilder("[" + col + "] = ");
                if (values.ToString() != "")
                {
                    values.Append(", ");
                }

                try
                {
                    newValues.Append(TypeHelper.GetType(drow[col]));
                }
                catch
                {
                    newValues.Append(string.Format("'{0}'", QuoteSQLString(drow[col])));
                }

                values.Append(newValues.ToString());
            }

            StringBuilder whereValues = new StringBuilder("");
            foreach (string col in whereColumns)
            {
                StringBuilder newValues = new StringBuilder("[" + col + "] = ");
                if (whereValues.ToString() != "")
                {
                    whereValues.Append(" AND ");
                }

                try
                {
                    newValues.Append(TypeHelper.GetType(drow[col]));
                }
                catch
                {
                    newValues.Append(string.Format("'{0}'", QuoteSQLString(drow[col])));
                }

                whereValues.Append(newValues.ToString());
            }

            return string.Format("UPDATE [{0}] SET {1} WHERE {2};", tableName, values.ToString(), whereValues.ToString());
        }

        public static string GenerateSqlDelete(string[] columns, DataTable table, string tableName, int rowIndex)
        {
            DataRow drow = table.Rows[rowIndex];
            StringBuilder values = new StringBuilder("");
            foreach (string col in columns)
            {
                StringBuilder newValues = new StringBuilder("[" + col + "] = ");

                if (values.ToString() != "")
                {
                    values.Append(" AND ");
                }

                try
                {
                    newValues.Append(TypeHelper.GetType(drow[col]));
                }
                catch
                {
                    newValues.Append(string.Format("'{0}'", QuoteSQLString(drow[col])));
                }

                values.Append(newValues.ToString());
            }
            return string.Format("DELETE FROM [{0}] WHERE {1};", tableName, values.ToString());
        }

        public static string GenerateCreateTable(ColumnModel[] columns, string tableName, string primaryKey)
        {
            string query = "";
            foreach (ColumnModel col in columns)
            {
                if (query != "")
                {
                    query += ",\r\n";
                }
                query += "[" + col.Name + "] " + col.Type + (col.AllowNull ? "" : " NOT NULL");
                if (col.Name == primaryKey)
                {
                    query += " PRIMARY KEY";
                }
            }

            query = "CREATE TABLE " + tableName + " (\r\n" + query + "\r\n)";
            return query;
        }

        public static string QuoteSQLString(string str)
        {
            return str.Replace("'", "''");
        }

        public static string QuoteSQLString(object obj)
        {
            return obj.ToString().Replace("'", "''");
        }
    }
}
