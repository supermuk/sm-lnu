using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DBMS
{
    public partial class CreateTableForm : Form
    {
        public List<ColumnModel> Columns = new List<ColumnModel>();

        public string PrimaryKey;

        public CreateTableForm()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Columns.Clear();
            for(int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                try
                {
                    DataGridViewRow row = dataGridView1.Rows[i];
                    Columns.Add(new ColumnModel
                    {
                        Name = row.Cells[0].Value.ToString(),
                        Type = row.Cells[1].Value.ToString(),
                        AllowNull = Convert.ToBoolean(row.Cells[2].Value)
                    });
                }
                catch { }
            }
        }

        private void dataGridView1_RowLeave(object sender, DataGridViewCellEventArgs e)
        {
            comboBox1.Items.Clear();
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                object val = dataGridView1.Rows[i].Cells[0].Value;
                if (val != null)
                {
                    comboBox1.Items.Add(val.ToString());
                }
            }
            if (comboBox1.Items.Count > 0)
            {
                comboBox1.SelectedIndex = 0;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {
                PrimaryKey = comboBox1.SelectedItem.ToString();
            }
        }
    }
}
