﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Crom.Controls;
using Crom.Controls.Docking;
using DBMS.Properties;
using System.Collections;

namespace DBMS
{
    public partial class MainForm : Form
    {
        private string mConnectionString = @"Data Source=.\SQLEXPRESS;Integrated Security=True;";

        private string mDatabaseName;

        private string mTableName;

        private DataTable mDataTable;

        public MainForm()
        {
            InitializeComponent();

            dockContainer.DockForm(AddDockableForm(dataGridView, "Rows", (Icon)Resources.icon6), DockStyle.Right, zDockMode.Outer);
            dockContainer.DockForm(AddDockableForm(outputRichTextBox, "Output", (Icon)Resources.icon5), DockStyle.Right, zDockMode.Outer);
            dockContainer.DockForm(AddDockableForm(connectionSplitContainer, "Connection string", (Icon)Resources.icon2), DockStyle.Top, zDockMode.Inner);
            dockContainer.DockForm(AddDockableForm(tablesListBox, "Tabels", (Icon)Resources.icon3), DockStyle.Top, zDockMode.Inner);
            dockContainer.DockForm(AddDockableForm(sqlSplitContainer, "Sql statement", (Icon)Resources.icon7), DockStyle.Top, zDockMode.Inner);
        }

        private DockableFormInfo AddDockableForm(Control control, string name, Icon icon)
        {
            control.Dock = DockStyle.Fill;
            Form form = new Form();
            form.Text = name;
            form.Icon = icon;
            form.Controls.Add(control);
            return dockContainer.Add(form, Crom.Controls.Docking.zAllowedDock.All, Guid.NewGuid());
        }

        private void PrintOutput(string message, PrintType type)
        {
            string str =
                DateTime.Now.ToLongTimeString()
                + " >>> "
                + type.ToString() + ": ";
            RichTextBox rtb = new RichTextBox();
            rtb.Text = str + message + "\r\n";


            rtb.Select(0, str.Length);
            switch (type)
            {
                case PrintType.Error:
                    rtb.SelectionColor = Color.Red;
                    break;
                case PrintType.Execute:
                    rtb.SelectionColor = Color.Green;
                    break;
                case PrintType.Warning:
                    rtb.SelectionColor = Color.DarkGoldenrod;
                    break;
            }

            rtb.SelectAll();
            outputRichTextBox.Select(0, 0);
            outputRichTextBox.SelectedRtf = rtb.SelectedRtf;
        }

        #region Load Data

        private void LoadDatabaseNames()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                databasesComboBox.DataSource = null;
                databasesComboBox.Items.Clear();
     

                databasesComboBox.DisplayMember = "DATABASE_NAME";
                databasesComboBox.ValueMember = "DATABASE_NAME";
                var dt = DBHelper.GetDatabases(mConnectionString);
                databasesComboBox.DataSource = dt;
               
            }
            catch (Exception ex)
            {
                PrintOutput(ex.Message, PrintType.Error);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
                //UpdateControls();
            }
        }

        private void LoadTableNames(string dbName)
        {                
            tablesListBox.DataSource = null;
            tablesListBox.Items.Clear();

            var dt = DBHelper.GetDatabaseTables(mConnectionString, dbName);
            tablesListBox.DisplayMember = "TABLE_NAME";
            tablesListBox.ValueMember = "TABLE_NAME";
            tablesListBox.DataSource = dt;
        }

        private string[] GetPrimaryKeyColumns()
        {
            var dt = DBHelper.GetPrimaryKey(mConnectionString, mDatabaseName, mTableName);
            List<string> keyColumns = new List<string>();
            foreach (DataRow row in dt.Rows)
            {
                keyColumns.Add(row["name"].ToString());
            }
            return keyColumns.ToArray();
        }

        private void Execute(string query)
        {
            if (query.Trim() == string.Empty)
            {
                PrintOutput("SQL statement can't be empty", PrintType.Warning);
                return;
            }

            try
            {
                PrintOutput(query, PrintType.Execute);
                Cursor.Current = Cursors.WaitCursor;

                mDataTable = DBHelper.LoadDataTable(mConnectionString, mDatabaseName, query);
                dataGridView.DataSource = mDataTable;

                string[] keys = GetPrimaryKeyColumns();
                foreach (string key in keys)
                {
                    dataGridView.Columns[key].ReadOnly = true;
                }
            }
            catch (Exception ex)
            {
                PrintOutput(ex.Message, PrintType.Error);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        #endregion

        #region Generate Sql

        private void GenerateSqlStatements()
        {
            string sql = string.Empty;

            // create an array of all the columns that are to be included
            List<string> columns = new List<string>();
            foreach (DataColumn col in mDataTable.Columns)
            {
                columns.Add(col.ColumnName);
            }
            if (columns.Count <= 0)
            {
                MessageBox.Show("No columns selected!  Please check/select some columns to include!");
                return;
            }

            if (mTableName == string.Empty)
            {
                MessageBox.Show("No valid target table name!  Please enter a table name to be used in the SQL statements!");
                return;
            }

            var dt = DBHelper.GetPrimaryKey(mConnectionString, mDatabaseName, mTableName);
            List<string> keyColumns = new List<string>();
            foreach (DataRow row in dt.Rows)
            {
                keyColumns.Add(row["name"].ToString());
            }

            sql = SqlGenHelper.GenerateSql(columns.ToArray(), keyColumns.ToArray(), mDataTable, mTableName, QueryType.Update);
            sqlRichTextBox.Text = sql;
        }

        private void GenerateUpdate(int rowIndex, int colIndex)
        {
            string query = "";
            query = SqlGenHelper.GenerateSqlUpdate(new string[] { mDataTable.Columns[colIndex].ColumnName }, GetPrimaryKeyColumns(), mDataTable, mTableName, rowIndex);
            sqlRichTextBox.Text = query;
        }

        private void GenerateDelete(int rowIndex)
        {
            string query = "";
            query = SqlGenHelper.GenerateSqlDelete(GetPrimaryKeyColumns(), mDataTable, mTableName, rowIndex);
            sqlRichTextBox.Text = query;
        }

        #endregion

        #region Events

        private void serverNameTextBox_TextChanged(object sender, EventArgs e)
        {
            mConnectionString = "Data Source=" + serverNameTextBox.Text + ";Integrated Security=True;";
        }

        private void databasesComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            mDatabaseName = databasesComboBox.SelectedValue.ToString();
            LoadTableNames(mDatabaseName);
            Cursor.Current = Cursors.Default;
        }

        private void tablesListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tablesListBox.SelectedValue != null)
            {
                mTableName = tablesListBox.SelectedValue.ToString();
                Execute("SELECT * FROM [" + mTableName + "]");
            }

            //dgTableInfo.DataSource = null;
            //UpdateControls();
        }

        private void connectButton_Click(object sender, EventArgs e)
        {
            LoadDatabaseNames();
        }

        private void executeButton_Click(object sender, EventArgs e)
        {
            Execute(sqlRichTextBox.Text);
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            GenerateSqlStatements();
        }

        private void dataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            GenerateUpdate(e.RowIndex, e.ColumnIndex);
        }
    
        private void dataGridView_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            GenerateDelete(e.RowIndex);
        }
        
        #endregion


    }
}
