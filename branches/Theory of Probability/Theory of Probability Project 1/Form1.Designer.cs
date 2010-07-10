namespace Theory_of_Probability_Project_1
{
    partial class Form1
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.label1 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.labelSkewness = new System.Windows.Forms.Label();
            this.labelKurtosis = new System.Windows.Forms.Label();
            this.labelR = new System.Windows.Forms.Label();
            this.labelD = new System.Windows.Forms.Label();
            this.labelSS = new System.Windows.Forms.Label();
            this.labelAvg = new System.Windows.Forms.Label();
            this.labelModa = new System.Windows.Forms.Label();
            this.labelMe = new System.Windows.Forms.Label();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.labelOk = new System.Windows.Forms.Label();
            this.labelBad = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.labelXiCritical = new System.Windows.Forms.Label();
            this.labelXiEmp = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файдToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.відкритиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.зберегтиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.trackBarPro1 = new Theory_of_Probability_Project_1.TrackBarPro();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 25);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.numericUpDown1);
            this.splitContainer1.Panel1.Controls.Add(this.trackBarPro1);
            this.splitContainer1.Panel1.Controls.Add(this.dataGridView1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabControl1);
            this.splitContainer1.Size = new System.Drawing.Size(674, 483);
            this.splitContainer1.SplitterDistance = 289;
            this.splitContainer1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.Gray;
            this.label1.Location = new System.Drawing.Point(377, 239);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(191, 24);
            this.label1.TabIndex = 7;
            this.label1.Text = "Кількість проміжків";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.numericUpDown1.Location = new System.Drawing.Point(574, 240);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(42, 26);
            this.numericUpDown1.TabIndex = 6;
            this.numericUpDown1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.Thistle;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Top;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.Size = new System.Drawing.Size(670, 217);
            this.dataGridView1.TabIndex = 4;
            this.dataGridView1.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellEndEdit);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Enabled = false;
            this.tabControl1.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(670, 186);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Controls.Add(this.dataGridView2);
            this.tabPage1.Location = new System.Drawing.Point(4, 26);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(662, 156);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Частотна таблиця";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(6, 109);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(177, 41);
            this.button1.TabIndex = 6;
            this.button1.Text = "Об\'єданти проміжки";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.BackgroundColor = System.Drawing.Color.Thistle;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Dock = System.Windows.Forms.DockStyle.Top;
            this.dataGridView2.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridView2.Location = new System.Drawing.Point(3, 3);
            this.dataGridView2.Name = "dataGridView2";
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.dataGridView2.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView2.Size = new System.Drawing.Size(656, 95);
            this.dataGridView2.TabIndex = 5;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.checkBox1);
            this.tabPage2.Location = new System.Drawing.Point(4, 26);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(662, 156);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Полігон частот";
            this.tabPage2.UseVisualStyleBackColor = true;
            this.tabPage2.Paint += new System.Windows.Forms.PaintEventHandler(this.tabPage2_Paint);
            this.tabPage2.Click += new System.EventHandler(this.tabPage2_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.checkBox2);
            this.tabPage3.Location = new System.Drawing.Point(4, 26);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(662, 156);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Гістограма частот";
            this.tabPage3.UseVisualStyleBackColor = true;
            this.tabPage3.Paint += new System.Windows.Forms.PaintEventHandler(this.tabPage3_Paint);
            this.tabPage3.Click += new System.EventHandler(this.tabPage3_Click);
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.label2);
            this.tabPage4.Controls.Add(this.labelSkewness);
            this.tabPage4.Controls.Add(this.labelKurtosis);
            this.tabPage4.Controls.Add(this.labelR);
            this.tabPage4.Controls.Add(this.labelD);
            this.tabPage4.Controls.Add(this.labelSS);
            this.tabPage4.Controls.Add(this.labelAvg);
            this.tabPage4.Controls.Add(this.labelModa);
            this.tabPage4.Controls.Add(this.labelMe);
            this.tabPage4.Location = new System.Drawing.Point(4, 26);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(662, 156);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Статистики";
            this.tabPage4.UseVisualStyleBackColor = true;
            this.tabPage4.Paint += new System.Windows.Forms.PaintEventHandler(this.tabPage4_Paint);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.Color.Gray;
            this.label2.Location = new System.Drawing.Point(32, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(22, 24);
            this.label2.TabIndex = 8;
            this.label2.Text = "_";
            // 
            // labelSkewness
            // 
            this.labelSkewness.AutoSize = true;
            this.labelSkewness.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelSkewness.ForeColor = System.Drawing.Color.Gray;
            this.labelSkewness.Location = new System.Drawing.Point(452, 19);
            this.labelSkewness.Name = "labelSkewness";
            this.labelSkewness.Size = new System.Drawing.Size(79, 24);
            this.labelSkewness.TabIndex = 7;
            this.labelSkewness.Text = "asimetr";
            // 
            // labelKurtosis
            // 
            this.labelKurtosis.AutoSize = true;
            this.labelKurtosis.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelKurtosis.ForeColor = System.Drawing.Color.Gray;
            this.labelKurtosis.Location = new System.Drawing.Point(452, 60);
            this.labelKurtosis.Name = "labelKurtosis";
            this.labelKurtosis.Size = new System.Drawing.Size(55, 24);
            this.labelKurtosis.TabIndex = 6;
            this.labelKurtosis.Text = "exec";
            // 
            // labelR
            // 
            this.labelR.AutoSize = true;
            this.labelR.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelR.ForeColor = System.Drawing.Color.Gray;
            this.labelR.Location = new System.Drawing.Point(295, 102);
            this.labelR.Name = "labelR";
            this.labelR.Size = new System.Drawing.Size(77, 24);
            this.labelR.TabIndex = 5;
            this.labelR.Text = "rozmah";
            // 
            // labelD
            // 
            this.labelD.AutoSize = true;
            this.labelD.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelD.ForeColor = System.Drawing.Color.Gray;
            this.labelD.Location = new System.Drawing.Point(295, 60);
            this.labelD.Name = "labelD";
            this.labelD.Size = new System.Drawing.Size(25, 24);
            this.labelD.TabIndex = 4;
            this.labelD.Text = "D";
            // 
            // labelSS
            // 
            this.labelSS.AutoSize = true;
            this.labelSS.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelSS.ForeColor = System.Drawing.Color.Gray;
            this.labelSS.Location = new System.Drawing.Point(295, 19);
            this.labelSS.Name = "labelSS";
            this.labelSS.Size = new System.Drawing.Size(44, 24);
            this.labelSS.TabIndex = 3;
            this.labelSS.Text = "S^2";
            // 
            // labelAvg
            // 
            this.labelAvg.AutoSize = true;
            this.labelAvg.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelAvg.ForeColor = System.Drawing.Color.Gray;
            this.labelAvg.Location = new System.Drawing.Point(32, 102);
            this.labelAvg.Name = "labelAvg";
            this.labelAvg.Size = new System.Drawing.Size(44, 24);
            this.labelAvg.TabIndex = 2;
            this.labelAvg.Text = "avg";
            // 
            // labelModa
            // 
            this.labelModa.AutoSize = true;
            this.labelModa.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelModa.ForeColor = System.Drawing.Color.Gray;
            this.labelModa.Location = new System.Drawing.Point(32, 60);
            this.labelModa.Name = "labelModa";
            this.labelModa.Size = new System.Drawing.Size(62, 24);
            this.labelModa.TabIndex = 1;
            this.labelModa.Text = "Moda";
            // 
            // labelMe
            // 
            this.labelMe.AutoSize = true;
            this.labelMe.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelMe.ForeColor = System.Drawing.Color.Gray;
            this.labelMe.Location = new System.Drawing.Point(32, 19);
            this.labelMe.Name = "labelMe";
            this.labelMe.Size = new System.Drawing.Size(39, 24);
            this.labelMe.TabIndex = 0;
            this.labelMe.Text = "Me";
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.labelOk);
            this.tabPage5.Controls.Add(this.labelBad);
            this.tabPage5.Controls.Add(this.label6);
            this.tabPage5.Controls.Add(this.label5);
            this.tabPage5.Controls.Add(this.label4);
            this.tabPage5.Controls.Add(this.label3);
            this.tabPage5.Controls.Add(this.comboBox1);
            this.tabPage5.Controls.Add(this.labelXiCritical);
            this.tabPage5.Controls.Add(this.labelXiEmp);
            this.tabPage5.Controls.Add(this.textBox1);
            this.tabPage5.Location = new System.Drawing.Point(4, 26);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(662, 156);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "Гіпотеза";
            this.tabPage5.UseVisualStyleBackColor = true;
            this.tabPage5.Paint += new System.Windows.Forms.PaintEventHandler(this.tabPage5_Paint);
            // 
            // labelOk
            // 
            this.labelOk.AutoSize = true;
            this.labelOk.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelOk.ForeColor = System.Drawing.Color.Green;
            this.labelOk.Location = new System.Drawing.Point(360, 76);
            this.labelOk.Name = "labelOk";
            this.labelOk.Size = new System.Drawing.Size(96, 22);
            this.labelOk.TabIndex = 9;
            this.labelOk.Text = "приймаєм";
            this.labelOk.Visible = false;
            // 
            // labelBad
            // 
            this.labelBad.AutoSize = true;
            this.labelBad.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelBad.ForeColor = System.Drawing.Color.Red;
            this.labelBad.Location = new System.Drawing.Point(359, 76);
            this.labelBad.Name = "labelBad";
            this.labelBad.Size = new System.Drawing.Size(97, 22);
            this.labelBad.TabIndex = 8;
            this.labelBad.Text = "відхиляєм";
            this.labelBad.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.ForeColor = System.Drawing.Color.Gray;
            this.label6.Location = new System.Drawing.Point(276, 76);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 22);
            this.label6.TabIndex = 7;
            this.label6.Text = "гіпотезу";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.ForeColor = System.Drawing.Color.Gray;
            this.label5.Location = new System.Drawing.Point(35, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 22);
            this.label5.TabIndex = 6;
            this.label5.Text = "α = ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.ForeColor = System.Drawing.Color.Gray;
            this.label4.Location = new System.Drawing.Point(52, 76);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 16);
            this.label4.TabIndex = 5;
            this.label4.Text = "емпіричне";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.ForeColor = System.Drawing.Color.Gray;
            this.label3.Location = new System.Drawing.Point(52, 116);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "критичне";
            // 
            // comboBox1
            // 
            this.comboBox1.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBox1.ForeColor = System.Drawing.Color.Gray;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "0,01",
            "0,025",
            "0,05",
            "0,95",
            "0,975",
            "0,99"});
            this.comboBox1.Location = new System.Drawing.Point(81, 19);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 30);
            this.comboBox1.TabIndex = 3;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // labelXiCritical
            // 
            this.labelXiCritical.AutoSize = true;
            this.labelXiCritical.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelXiCritical.ForeColor = System.Drawing.Color.Gray;
            this.labelXiCritical.Location = new System.Drawing.Point(35, 101);
            this.labelXiCritical.Name = "labelXiCritical";
            this.labelXiCritical.Size = new System.Drawing.Size(61, 22);
            this.labelXiCritical.TabIndex = 2;
            this.labelXiCritical.Text = "χ     = ";
            // 
            // labelXiEmp
            // 
            this.labelXiEmp.AutoSize = true;
            this.labelXiEmp.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelXiEmp.ForeColor = System.Drawing.Color.Gray;
            this.labelXiEmp.Location = new System.Drawing.Point(35, 63);
            this.labelXiEmp.Name = "labelXiEmp";
            this.labelXiEmp.Size = new System.Drawing.Size(61, 22);
            this.labelXiEmp.TabIndex = 1;
            this.labelXiEmp.Text = "χ     = ";
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox1.ForeColor = System.Drawing.Color.Gray;
            this.textBox1.Location = new System.Drawing.Point(507, 19);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(149, 131);
            this.textBox1.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.OldLace;
            this.menuStrip1.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файдToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(674, 25);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файдToolStripMenuItem
            // 
            this.файдToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.відкритиToolStripMenuItem,
            this.зберегтиToolStripMenuItem});
            this.файдToolStripMenuItem.Name = "файдToolStripMenuItem";
            this.файдToolStripMenuItem.Size = new System.Drawing.Size(55, 21);
            this.файдToolStripMenuItem.Text = "Файл";
            // 
            // відкритиToolStripMenuItem
            // 
            this.відкритиToolStripMenuItem.Name = "відкритиToolStripMenuItem";
            this.відкритиToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.відкритиToolStripMenuItem.Text = "Відкрити";
            this.відкритиToolStripMenuItem.Click += new System.EventHandler(this.відкритиToolStripMenuItem_Click);
            // 
            // зберегтиToolStripMenuItem
            // 
            this.зберегтиToolStripMenuItem.Name = "зберегтиToolStripMenuItem";
            this.зберегтиToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.зберегтиToolStripMenuItem.Text = "Зберегти";
            this.зберегтиToolStripMenuItem.Click += new System.EventHandler(this.зберегтиToolStripMenuItem_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // checkBox1
            // 
            this.checkBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(4, 138);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(51, 21);
            this.checkBox1.TabIndex = 0;
            this.checkBox1.Text = "grid";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // checkBox2
            // 
            this.checkBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(3, 139);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(51, 21);
            this.checkBox2.TabIndex = 1;
            this.checkBox2.Text = "grid";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // trackBarPro1
            // 
            this.trackBarPro1.BackColor = System.Drawing.SystemColors.Control;
            this.trackBarPro1.Location = new System.Drawing.Point(59, 237);
            this.trackBarPro1.MaxValue = 1F;
            this.trackBarPro1.MinValue = 0F;
            this.trackBarPro1.Name = "trackBarPro1";
            this.trackBarPro1.Size = new System.Drawing.Size(312, 34);
            this.trackBarPro1.TabIndex = 5;
            this.trackBarPro1.ThumbCount = 0;
            this.trackBarPro1.Values = ((System.Collections.Generic.List<float>)(resources.GetObject("trackBarPro1.Values")));
            this.trackBarPro1.ThumbMoved += new Theory_of_Probability_Project_1.TrackBarPro.Moved(this.trackBarPro1_ThumbMoved);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(674, 508);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip1);
            this.Name = "Form1";
            this.Text = "Статистика";
            this.ResizeEnd += new System.EventHandler(this.Form1_ResizeEnd);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.tabPage5.ResumeLayout(false);
            this.tabPage5.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private TrackBarPro trackBarPro1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.Label labelR;
        private System.Windows.Forms.Label labelD;
        private System.Windows.Forms.Label labelSS;
        private System.Windows.Forms.Label labelAvg;
        private System.Windows.Forms.Label labelModa;
        private System.Windows.Forms.Label labelMe;
        private System.Windows.Forms.Label labelSkewness;
        private System.Windows.Forms.Label labelKurtosis;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem файдToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem відкритиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem зберегтиToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label labelXiCritical;
        private System.Windows.Forms.Label labelXiEmp;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelOk;
        private System.Windows.Forms.Label labelBad;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBox2;

    }
}

