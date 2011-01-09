using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ZedGraph;

namespace Spreadsheetq
{
    public partial class Spreadsheet : UserControl
    {
        private Dictionary<string, string> Formulas = new Dictionary<string, string>();
        private Dictionary<string, string> Data = new Dictionary<string, string>();

        private List<Dictionary<string, string>> DataSaves = new List<Dictionary<string, string>>();
        private List<Dictionary<string, string>> FormulasSaves = new List<Dictionary<string, string>>();
        private int CurrentRevision = 0;
        private int CopiedRevision = 0;

        private int LastRowIndex = 0;
        private int LastColumnIndex = 0;
        private string LastColumnName = "A";
        private string LastCellName = "A0";
        private int RowIndex = 0;

        private int ColumnIndex = 0;
        private string ColumnName = "A";
        private string CellName = "A0";

        private int CopiedRowIndex = 0;
        private int CopiedColumnIndex = 0;
        private string CopiedBuffer = "";

        public Spreadsheet()
        {
            InitializeComponent();
            CreateTable(20, 20);
            FormulasSaves.Add(new Dictionary<string, string>());
            DataSaves.Add(new Dictionary<string, string>());
        }
        
        public void CreateTable(int rowCount, int columnCount)
        {
            table.Rows.Clear();
            table.Columns.Clear();
            if (columnCount > 500)
            {
                throw new Exception("Too much columns: " + columnCount.ToString());
            }
            for (int i = 0; i < Math.Min(columnCount, 26); i++)
            {
                string columnName = "";
                columnName = ((char)((int)'A' + i)).ToString();
                table.Columns.Add(columnName, columnName);
            }
            if (columnCount > 26)
            {
                for (int i = 26; i < columnCount; i++)
                {
                    string columnName = "";
                    columnName = ((char)((int)'A' + (i - 26) / 26)).ToString() + ((char)((int)'A' + (i - 26) % 26)).ToString();
                    table.Columns.Add(columnName, columnName);
                }
            }
            table.Rows.Add(rowCount);
            for (int i = 0; i < rowCount; i++)
            {
                table.Rows[i].HeaderCell.Value = i.ToString();
            }
        }
        
        private void CalculateCells(DataGridViewCell cell)
        {
            if (cell.Value == null)
            {
                return;
            }
            if (cell.Value.ToString().StartsWith("="))
            {
                Parser parser = new Parser { Formula = Formulas[table.Columns[cell.ColumnIndex].Name + cell.RowIndex.ToString()].Substring(1) };
                try
                {
                    cell.Value = parser.Calculate(Data);
                }
                catch
                {
                    cell.Value = "????";
                }
            }
        }
        
        private void SaveCellChanges(int rowIndex, string colName, string value)
        {
            if (value == "")
            {
                if (Data.ContainsKey(colName + rowIndex.ToString()))
                {
                    Data.Remove(colName + rowIndex.ToString());
                }
                if (Formulas.ContainsKey(colName + rowIndex.ToString()))
                {
                    Formulas.Remove(colName + rowIndex.ToString());
                }
                table.Rows[rowIndex].Cells[colName].Value = "";
                table.Rows[rowIndex].Cells[colName].Style.BackColor = Color.White;
            }
            else if (value.StartsWith("="))
            {
                Parser parser = new Parser { Formula = value.Substring(1) };
                Formulas[colName + rowIndex.ToString()] = value;
                string calcVal = "????";
                try
                {
                    calcVal = parser.Calculate(Data).ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Incorrect Input");
                }
                table.Rows[rowIndex].Cells[colName].Value = calcVal;
                Data[colName +rowIndex.ToString()] = calcVal;
                table.Rows[rowIndex].Cells[colName].Style.BackColor = Color.AliceBlue;
            }
            else
            {
                Formulas.Remove(colName + rowIndex.ToString());
                Data[colName + rowIndex.ToString()] = value;
                table.Rows[rowIndex].Cells[colName].Value = value;
                table.Rows[rowIndex].Cells[colName].Style.BackColor = Color.White;
            }
            foreach (string key in Formulas.Keys)
            {
                KeyValuePair<int, string> p = ParseCellName(key);
                Parser parser = new Parser { Formula = Formulas[key].Substring(1) };
                string calcVal = "????";
                try
                {
                    calcVal = parser.Calculate(Data).ToString();
                }
                catch (Exception ex)
                {
                    //MessageBox.Show("aa");
                }
                table.Rows[p.Key].Cells[p.Value].Value = calcVal;
                Data[key] = calcVal;
            }
        }
        
        private KeyValuePair<int, string> ParseCellName(string name)
        {
            string rowName = "";
            string colName = "";
            rowName = name.Substring(1);
            int rowIndex = 0;
            if (int.TryParse(rowName, out rowIndex))
            {
                colName = name.Substring(0, 1);
            }
            else
            {
                rowName = colName.Substring(2);
                rowIndex = int.Parse(rowName);
                colName = name.Substring(0, 2);
            }
            return new KeyValuePair<int, string>(rowIndex, colName);
        }
        
        private void UpdateTable()
        {
            if (CurrentRevision < 0)
            {
                throw new Exception("No more changes available");
            }
            if (CurrentRevision >= FormulasSaves.Count)
            {
                throw new Exception("No more changes available");
            }
            for (int i = 0; i < table.Rows.Count; i++)
            {
                for (int j = 0; j < table.Columns.Count; j++)
                {
                    table.Rows[i].Cells[j].Value = "";
                }
            }
            foreach (string key in DataSaves[CurrentRevision].Keys)
            {
                KeyValuePair<int, string> p = ParseCellName(key);
                table.Rows[p.Key].Cells[p.Value].Value = DataSaves[CurrentRevision][key];
            }
            foreach (string key in Formulas.Keys)
            {
                KeyValuePair<int, string> p = ParseCellName(key);
                table.Rows[p.Key].Cells[p.Value].Style.BackColor = Color.White;
            }

            Data = new Dictionary<string, string>(DataSaves[CurrentRevision]);
            Formulas = new Dictionary<string, string>(FormulasSaves[CurrentRevision]);

            foreach (string key in Formulas.Keys)
            {
                KeyValuePair<int, string> p = ParseCellName(key);
                table.Rows[p.Key].Cells[p.Value].Style.BackColor = Color.AliceBlue;
            }
        }

        #region UndoRedo

        public void Undo()
        {
            table.EndEdit();
            CurrentRevision--;
            UpdateTable();   
        }
        
        public void Redo() 
        {
            CurrentRevision++;
            UpdateTable();
        }
        
        public bool CanUndo()
        {
            return CurrentRevision > 0;
        }
        
        public bool CanRedo()
        {
            return CurrentRevision < DataSaves.Count - 1;
        }

        private void Save()
        {
            if (FormulasSaves.Count > CurrentRevision + 1)
            {
                FormulasSaves.RemoveRange(CurrentRevision + 1, FormulasSaves.Count - CurrentRevision - 1);
            }
            if (DataSaves.Count > CurrentRevision + 1)
            {
                DataSaves.RemoveRange(CurrentRevision + 1, DataSaves.Count - CurrentRevision - 1);
            }

            DataSaves.Add(new Dictionary<string, string>(Data));
            FormulasSaves.Add(new Dictionary<string, string>(Formulas));
            CurrentRevision++;
        }

        #endregion

        private string ReplaceCellNames(int rowShift, int colShift, string value)
        {
            for (int i = table.Columns.Count - 1; i >= 0; i--)
            {
                for(int j = table.Rows.Count - 1; j  >= 0; j--)
                {
                    if (i - colShift < table.Columns.Count && i - colShift >= 0 && j - rowShift < table.Rows.Count && j - rowShift >= 0)
                    {
                        string oldCellName = table.Columns[i].Name + j.ToString();
                        string newCellName = table.Columns[i - colShift].Name + (j - rowShift).ToString();
                        value = value.Replace(oldCellName, newCellName);
                    }
                }
            }
            return value;
        }

        private void CopyToBuffer()
        {
            CopiedRowIndex = table.Rows.Count;
            CopiedColumnIndex = table.Columns.Count;
            int maxRowIndex = 0;
            int maxColumnIndex = 0;
            CopiedBuffer = "";
            foreach (DataGridViewCell cell in table.SelectedCells)
            {
                if (cell.RowIndex < CopiedRowIndex)
                {
                    CopiedRowIndex = cell.RowIndex;
                    CopiedColumnIndex = cell.ColumnIndex;
                }
                else if (cell.RowIndex == CopiedRowIndex && cell.ColumnIndex < CopiedColumnIndex)
                {
                    CopiedRowIndex = cell.RowIndex;
                    CopiedColumnIndex = cell.ColumnIndex;
                }
                if (cell.RowIndex > maxRowIndex)
                {
                    maxRowIndex = cell.RowIndex;
                    maxColumnIndex = cell.ColumnIndex;
                }
                else if (cell.RowIndex == maxRowIndex && cell.ColumnIndex > maxColumnIndex)
                {
                    maxRowIndex = cell.RowIndex;
                    maxColumnIndex = cell.ColumnIndex;
                }
            }

            for(int i = CopiedRowIndex; i <= maxRowIndex; i++)
            {
                for (int j = CopiedColumnIndex; j <= maxColumnIndex; j++)
                {
                    object value = table.Rows[i].Cells[j].Value;
                    CopiedBuffer += value == null ? "" : value.ToString();
                    if (j != maxColumnIndex)
                    {
                        CopiedBuffer += "\t";
                    }
                }
                if (i != maxRowIndex)
                {
                    CopiedBuffer += "\r\n";
                }
            }
            Clipboard.SetText(CopiedBuffer);
        }

        private void ClearStyle()
        {
            for (int i = 0; i < table.Rows.Count; i++)
            {
                for (int j = 0; j < table.Rows[i].Cells.Count; j++)
                {
                    table.Rows[i].Cells[j].Style.BackColor = Color.White;
                }
            }
        }

        public string SaveFile()
        {
            string text = "";
            int maxRowIndex = 0;
            int maxColumnIndex = 0;
            for (int i = 0; i < table.Rows.Count; i++)
            {
                for (int j = 0; j < table.Rows[i].Cells.Count; j++)
                {
                    if (table.Rows[i].Cells[j].Value != null)
                    {
                        if (maxColumnIndex < j)
                        {
                            maxColumnIndex = j;
                        }
                        if (maxRowIndex < i)
                        {
                            maxRowIndex = i;
                        }
                    }
                }
            }

            for (int i = 0; i <= maxRowIndex; i++)
            {
                for (int j = 0; j <= maxColumnIndex; j++)
                {
                    object value = table.Rows[i].Cells[j].Value;
                    string key = table.Columns[j].Name + i.ToString();
                    if (Formulas.ContainsKey(key))
                    {
                        text += Formulas[key];
                    }
                    else
                    {
                        text += value == null ? "" : value.ToString();
                    }
                    if (j != maxColumnIndex)
                    {
                        text += "\t";
                    }
                }
                if (i != maxRowIndex)
                {
                    text += "\r\n";
                }
            }
            return text;
        }

        public void OpenFile(string text)
        {
            string[] lines = text.Split('\n');
            int rowIndex = 0;
            foreach (string line in lines)
            {
                string[] cells = line.Split('\t');
                for (int j = 0; j < cells.Length; j++)
                {
                    if (rowIndex < table.Rows.Count && j < table.Columns.Count)
                    {
                        string value = cells[j];
                        SaveCellChanges(rowIndex, table.Columns[j].Name, value);
                    }
                }
                rowIndex++;
            }
            Changed.Invoke(this, new EventArgs());
            Save();
        }

        public double[] GetSelectedArray()
        {
            List<double> arr = new List<double>();
            foreach (DataGridViewCell cell in table.SelectedCells)
            {
                string cellName = table.Columns[cell.ColumnIndex].Name + cell.RowIndex.ToString();
                arr.Add(double.Parse(Data[cellName]));
            }

            return arr.ToArray();
        }

        #region Events

        public event EventHandler Changed;

        private void table_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            string value = "";
            if (table.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                value = table.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
            }
            string colName = table.Columns[e.ColumnIndex].Name;
            SaveCellChanges(RowIndex, colName, value);
            Save();
            Changed.Invoke(this, new EventArgs());
        }

        private void table_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                foreach (DataGridViewCell cell in table.SelectedCells)
                {
                    SaveCellChanges(cell.RowIndex, table.Columns[cell.ColumnIndex].Name, "");
                }
                Changed.Invoke(this, new EventArgs());
                Save();
            }
            else if (e.Control && e.KeyCode == Keys.V)
            {
                if (Clipboard.ContainsText(TextDataFormat.Text))
                {
                    string data = Clipboard.GetText();
                    string[] lines = data.Split('\n');
                    int rowIndex = table.CurrentCell.RowIndex;
                    int colIndex = table.CurrentCell.ColumnIndex;
                    int rowShift = 0;
                    int colShift = 0;
                    if (data == CopiedBuffer)
                    {
                        rowShift = CopiedRowIndex - rowIndex;
                        colShift = CopiedColumnIndex - colIndex;
                    }
                    foreach (string line in lines)
                    {
                        string[] cells = line.Split('\t');
                        for (int j = 0; j < cells.Length; j++)
                        {
                            if (rowIndex < table.Rows.Count && colIndex + j < table.Columns.Count)
                            {
                                string value = cells[j];
                                string key = table.Columns[CopiedColumnIndex + j].Name + (rowIndex + rowShift).ToString();
                                if (FormulasSaves[CopiedRevision].ContainsKey(key))
                                {
                                    value = ReplaceCellNames(rowShift, colShift, FormulasSaves[CopiedRevision][key]);
                                }

                                SaveCellChanges(rowIndex, table.Columns[colIndex + j].Name, value);
                            }
                        }
                        rowIndex++;
                    }
                    Changed.Invoke(this, new EventArgs());
                    Save();
                }
            }
            else if (e.Control && e.KeyCode == Keys.C)
            {
                CopyToBuffer();
                CopiedRevision = CurrentRevision;
            }
            else if (e.Control && e.KeyCode == Keys.X)
            {
                CopyToBuffer();
                foreach (DataGridViewCell cell in table.SelectedCells)
                {
                    SaveCellChanges(cell.RowIndex, table.Columns[cell.ColumnIndex].Name, "");
                }
                Changed.Invoke(this, new EventArgs());
                Save();
            }
        }

        private void table_SelectionChanged(object sender, EventArgs e)
        {
            RowIndex = table.CurrentCell.RowIndex;
            ColumnIndex = table.CurrentCell.ColumnIndex;
            ColumnName = table.Columns[ColumnIndex].Name;
            CellName = ColumnName + RowIndex.ToString();
            toolStripStatusLabel1.Text = "Cell: " + CellName;
            if (Formulas.ContainsKey(LastCellName))
            {
                CalculateCells(table.Rows[LastRowIndex].Cells[LastColumnIndex]);
            }
            if (Formulas.ContainsKey(CellName))
            {
                table.CurrentCell.Value = Formulas[CellName];
            }

            LastColumnName = ColumnName;
            LastColumnIndex = ColumnIndex;
            LastRowIndex = RowIndex;
            LastCellName = ColumnName + RowIndex.ToString();
        }

        #endregion
    }
}
