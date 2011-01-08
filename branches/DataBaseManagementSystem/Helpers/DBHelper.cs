using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;
using Microsoft.ApplicationBlocks.Data;

namespace DBMS
{
    public class DBHelper
    {

        public static SqlConnection GetConnection(string connection, string database)
        {
            SqlConnection conn = null;
            conn = new SqlConnection(connection);
            conn.Open();

            if (database.Trim() != string.Empty)
            {
                conn.ChangeDatabase(database);
            }
            return conn;
        }

        public static DataTable GetDatabases(string connection)
        {
            SqlConnection conn = null;
            DataTable dt = null;

            conn = GetConnection(connection, string.Empty);

            if (connection == null)
            {
                return dt;
            }

            string cmd = "SELECT name AS DATABASE_NAME, 0 AS DATABASE_SIZE, NULL AS REMARKS FROM master.dbo.sysdatabases WHERE HAS_DBACCESS(name) = 1  ORDER BY name";
            DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.Text, cmd);

            if ((ds != null) && (ds.Tables.Count > 0))
            {
                dt = ds.Tables[0];
            }

            if (conn != null)
            {
                conn.Close();
                conn.Dispose();
            }

            return dt;
        }

        public static DataTable GetDatabaseTables(string connection, string database)
        {
            SqlConnection conn = null;
            DataTable dt = null;

            conn = GetConnection(connection, database);
            if (connection == null)
            {
                return dt;
            }

            SqlCommand cmd = new SqlCommand("sp_tables", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@table_type", "'TABLE'");

            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);

            if ((ds != null) && (ds.Tables.Count > 0))
            {
                dt = ds.Tables[0];
            }
            if (conn != null)
            {
                conn.Close();
                conn.Dispose();
            }

            return dt;
        }

        public static DataTable GetDatabaseTableColumns(string connection, string database, string sTableName)
        {
            SqlConnection conn = null;
            DataTable dt = null;

            conn = GetConnection(connection, database);
            if (connection == null)
                return dt;

            SqlParameter[] sqlParms = new SqlParameter[] { new SqlParameter("@table_name", sTableName) };
            DataSet dset = SqlHelper.ExecuteDataset(conn, "sp_columns", sqlParms);

            if ((dset != null) && (dset.Tables.Count > 0))
            {
                dt = dset.Tables[0];
            }

            if (conn != null)
            {
                conn.Close();
                conn.Dispose();
            }

            return dt;
        }

        public static DataTable GetPrimaryKey(string connection, string databaseName, string tableName)
        {
            string query =
                "SELECT [name]  FROM syscolumns WHERE [id] IN (SELECT [id] FROM sysobjects WHERE [name] = '"
                + tableName
                + "')AND colid IN (SELECT SIK.colid FROM sysindexkeys SIK JOIN sysobjects SO ON SIK.[id] = SO.[id] WHERE SIK.indid = 1 AND SO.[name] = '"
                + tableName
                +"')";
            return LoadDataTable(connection, databaseName, query);
        }

        public static DataTable LoadDataTable(string connection, string database, string sQuery)
        {
            SqlConnection conn = null;
            DataTable dt = null;

            conn = GetConnection(connection, database);
            if (connection == null)
            {
                return dt;
            }

            DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.Text, sQuery);
            if ((ds != null) && (ds.Tables.Count > 0))
            {
                dt = ds.Tables[0];
            }
            if (connection != null)
            {
                conn.Close();
                conn.Dispose();
            }
            
            return dt;
        }
    }
}
