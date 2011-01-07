using System;
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

            dockContainer.DockForm(AddDockableForm(dataDataGrid, "Rows", (Icon)Resources.icon6), DockStyle.Right, zDockMode.Outer);
            dockContainer.DockForm(AddDockableForm(outputRichTextBox, "Output", (Icon)Resources.icon5), DockStyle.Right, zDockMode.Outer);
            dockContainer.DockForm(AddDockableForm(tableLayoutPanel1, "Connection string", (Icon)Resources.icon2), DockStyle.Top, zDockMode.Inner);
            dockContainer.DockForm(AddDockableForm(tablesListBox, "Tabels", (Icon)Resources.icon3), DockStyle.Top, zDockMode.Inner);
            dockContainer.DockForm(AddDockableForm(sqlRichTextBox, "Sql statement", (Icon)Resources.icon7), DockStyle.Top, zDockMode.Inner);
        }

        private void Initialize()
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

        private DockableFormInfo AddDockableForm(Control control, string name, Icon icon)
        {
            control.Dock = DockStyle.Fill;
            Form form = new Form();
            form.Text = name;
            form.Icon = icon;
            if (control == tableLayoutPanel1)
            {
                form.MaximumSize = new Size(400, 150);
            }
            form.Controls.Add(control);
            return dockContainer.Add(form, Crom.Controls.Docking.zAllowedDock.All, Guid.NewGuid());
        }

        private void LoadTableNames(string dbName)
        {                
            tablesListBox.DataSource = null;
            tablesListBox.Items.Clear();

            var dt = DBHelper.GetDatabaseTables(mConnectionString, dbName);
            tablesListBox.DisplayMember = "TABLE_NAME";
            tablesListBox.ValueMember = "TABLE_NAME";
            tablesListBox.DataSource = dt;
            tablesListBox.Invalidate();
        }

        private void PrintOutput(string message, PrintType type)
        {
            outputRichTextBox.Text = 
                DateTime.Now.ToShortTimeString() 
                + " >>> "
                + type.ToString() + ": "
                + message + "\r\n" 
                + outputRichTextBox.Text;
        }

        private void Execute(string sql)
        {
            if (sql.Trim() == string.Empty)
            {
                PrintOutput("SQL statement can't be empty", PrintType.Warning);
                return;
            }

            try
            {
                PrintOutput(sql, PrintType.Execute);
                Cursor.Current = Cursors.WaitCursor;

                mDataTable = DBHelper.LoadDataTable(mConnectionString, mDatabaseName, sql);
                dataDataGrid.DataSource = mDataTable;

                //chklstIncludeFields.Items.Clear();
                //foreach (DataColumn col in m_TableInfo.Columns)
                {
                    // exclude the primary/auto-increment key by default, but select/check all the others
                    //chklstIncludeFields.Items.Add(col.ColumnName, (chklstIncludeFields.Items.Count > 0));
                }
            }
            catch (Exception ex)
            {
                PrintOutput(ex.Message, PrintType.Error);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
                UpdateAll();
            }
        }

        private void UpdateAll()
        {
            tablesListBox.Refresh();
        }

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

            mTableName = tablesListBox.SelectedValue.ToString();
            Execute("SELECT * FROM " + mTableName);

            //dgTableInfo.DataSource = null;
            //UpdateControls();
        }

        #endregion

        private void connectButton_Click(object sender, EventArgs e)
        {
            Initialize();
        }

    }
}
