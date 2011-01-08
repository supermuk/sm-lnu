namespace DBMS
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.label1 = new System.Windows.Forms.Label();
            this.serverNameTextBox = new System.Windows.Forms.TextBox();
            this.databasesComboBox = new System.Windows.Forms.ComboBox();
            this.tablesListBox = new System.Windows.Forms.ListBox();
            this.sqlRichTextBox = new System.Windows.Forms.RichTextBox();
            this.outputRichTextBox = new System.Windows.Forms.RichTextBox();
            this.dockContainer = new Crom.Controls.Docking.DockContainer();
            this.connectButton = new System.Windows.Forms.Button();
            this.executeButton = new System.Windows.Forms.Button();
            this.sqlSplitContainer = new System.Windows.Forms.SplitContainer();
            this.connectionSplitContainer = new System.Windows.Forms.SplitContainer();
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.sqlSplitContainer.Panel1.SuspendLayout();
            this.sqlSplitContainer.Panel2.SuspendLayout();
            this.sqlSplitContainer.SuspendLayout();
            this.connectionSplitContainer.Panel1.SuspendLayout();
            this.connectionSplitContainer.Panel2.SuspendLayout();
            this.connectionSplitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 8);
            this.label1.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Server Name:";
            // 
            // serverNameTextBox
            // 
            this.serverNameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.serverNameTextBox.Location = new System.Drawing.Point(81, 5);
            this.serverNameTextBox.Name = "serverNameTextBox";
            this.serverNameTextBox.Size = new System.Drawing.Size(191, 20);
            this.serverNameTextBox.TabIndex = 1;
            this.serverNameTextBox.Text = ".\\SQLEXPRESS";
            this.serverNameTextBox.TextChanged += new System.EventHandler(this.serverNameTextBox_TextChanged);
            // 
            // databasesComboBox
            // 
            this.databasesComboBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.databasesComboBox.FormattingEnabled = true;
            this.databasesComboBox.Location = new System.Drawing.Point(0, 0);
            this.databasesComboBox.Name = "databasesComboBox";
            this.databasesComboBox.Size = new System.Drawing.Size(279, 21);
            this.databasesComboBox.TabIndex = 0;
            this.databasesComboBox.SelectedIndexChanged += new System.EventHandler(this.databasesComboBox_SelectedIndexChanged);
            // 
            // tablesListBox
            // 
            this.tablesListBox.FormattingEnabled = true;
            this.tablesListBox.Location = new System.Drawing.Point(6, 209);
            this.tablesListBox.Name = "tablesListBox";
            this.tablesListBox.Size = new System.Drawing.Size(183, 238);
            this.tablesListBox.TabIndex = 0;
            this.tablesListBox.SelectedIndexChanged += new System.EventHandler(this.tablesListBox_SelectedIndexChanged);
            // 
            // sqlRichTextBox
            // 
            this.sqlRichTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sqlRichTextBox.Location = new System.Drawing.Point(0, 0);
            this.sqlRichTextBox.Name = "sqlRichTextBox";
            this.sqlRichTextBox.Size = new System.Drawing.Size(116, 100);
            this.sqlRichTextBox.TabIndex = 0;
            this.sqlRichTextBox.Text = "";
            // 
            // outputRichTextBox
            // 
            this.outputRichTextBox.Location = new System.Drawing.Point(264, 414);
            this.outputRichTextBox.Name = "outputRichTextBox";
            this.outputRichTextBox.Size = new System.Drawing.Size(330, 75);
            this.outputRichTextBox.TabIndex = 0;
            this.outputRichTextBox.Text = "";
            // 
            // dockContainer
            // 
            this.dockContainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(118)))), ((int)(((byte)(118)))));
            this.dockContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dockContainer.Location = new System.Drawing.Point(0, 0);
            this.dockContainer.Name = "dockContainer";
            this.dockContainer.Size = new System.Drawing.Size(928, 512);
            this.dockContainer.TabIndex = 65;
            // 
            // connectButton
            // 
            this.connectButton.Location = new System.Drawing.Point(6, 27);
            this.connectButton.Name = "connectButton";
            this.connectButton.Size = new System.Drawing.Size(75, 23);
            this.connectButton.TabIndex = 1;
            this.connectButton.Text = "connect";
            this.connectButton.UseVisualStyleBackColor = true;
            this.connectButton.Click += new System.EventHandler(this.connectButton_Click);
            // 
            // executeButton
            // 
            this.executeButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.executeButton.Image = global::DBMS.Properties.Resources.execute;
            this.executeButton.Location = new System.Drawing.Point(0, 0);
            this.executeButton.Name = "executeButton";
            this.executeButton.Size = new System.Drawing.Size(30, 100);
            this.executeButton.TabIndex = 67;
            this.executeButton.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.executeButton.UseVisualStyleBackColor = true;
            this.executeButton.Click += new System.EventHandler(this.executeButton_Click);
            // 
            // sqlSplitContainer
            // 
            this.sqlSplitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.sqlSplitContainer.Location = new System.Drawing.Point(659, 209);
            this.sqlSplitContainer.Name = "sqlSplitContainer";
            // 
            // sqlSplitContainer.Panel1
            // 
            this.sqlSplitContainer.Panel1.Controls.Add(this.sqlRichTextBox);
            // 
            // sqlSplitContainer.Panel2
            // 
            this.sqlSplitContainer.Panel2.Controls.Add(this.executeButton);
            this.sqlSplitContainer.Size = new System.Drawing.Size(150, 100);
            this.sqlSplitContainer.SplitterDistance = 116;
            this.sqlSplitContainer.TabIndex = 68;
            // 
            // connectionSplitContainer
            // 
            this.connectionSplitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.connectionSplitContainer.IsSplitterFixed = true;
            this.connectionSplitContainer.Location = new System.Drawing.Point(570, 49);
            this.connectionSplitContainer.Name = "connectionSplitContainer";
            this.connectionSplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // connectionSplitContainer.Panel1
            // 
            this.connectionSplitContainer.Panel1.Controls.Add(this.serverNameTextBox);
            this.connectionSplitContainer.Panel1.Controls.Add(this.label1);
            // 
            // connectionSplitContainer.Panel2
            // 
            this.connectionSplitContainer.Panel2.Controls.Add(this.button1);
            this.connectionSplitContainer.Panel2.Controls.Add(this.databasesComboBox);
            this.connectionSplitContainer.Panel2.Controls.Add(this.connectButton);
            this.connectionSplitContainer.Size = new System.Drawing.Size(279, 100);
            this.connectionSplitContainer.SplitterDistance = 31;
            this.connectionSplitContainer.TabIndex = 69;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(169, 27);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridView
            // 
            this.dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(281, 175);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.Size = new System.Drawing.Size(240, 150);
            this.dataGridView.TabIndex = 70;
            this.dataGridView.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellEndEdit);
            this.dataGridView.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dataGridView_RowsRemoved);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(928, 512);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.connectionSplitContainer);
            this.Controls.Add(this.sqlSplitContainer);
            this.Controls.Add(this.outputRichTextBox);
            this.Controls.Add(this.tablesListBox);
            this.Controls.Add(this.dockContainer);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "Form1";
            this.sqlSplitContainer.Panel1.ResumeLayout(false);
            this.sqlSplitContainer.Panel2.ResumeLayout(false);
            this.sqlSplitContainer.ResumeLayout(false);
            this.connectionSplitContainer.Panel1.ResumeLayout(false);
            this.connectionSplitContainer.Panel1.PerformLayout();
            this.connectionSplitContainer.Panel2.ResumeLayout(false);
            this.connectionSplitContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox tablesListBox;
        private System.Windows.Forms.RichTextBox outputRichTextBox;
        private System.Windows.Forms.ComboBox databasesComboBox;
        private System.Windows.Forms.RichTextBox sqlRichTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox serverNameTextBox;
        private Crom.Controls.Docking.DockContainer dockContainer;
        private System.Windows.Forms.Button connectButton;
        private System.Windows.Forms.Button executeButton;
        private System.Windows.Forms.SplitContainer sqlSplitContainer;
        private System.Windows.Forms.SplitContainer connectionSplitContainer;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dataGridView;
    }
}

