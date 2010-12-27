namespace Compiler
{
    partial class CodeEditor
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    /*protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }*/

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        this.components = new System.ComponentModel.Container();
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CodeEditor));
        this.statusStrip = new System.Windows.Forms.StatusStrip();
        this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
        this.textEditorControl = new DigitalRune.Windows.TextEditor.TextEditorControl();
        this.menuStrip = new System.Windows.Forms.MenuStrip();
        this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
        this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
        this.printToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        this.printPreviewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
        this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        this.undoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        this.redoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
        this.cutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
        this.selectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        this.buildToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        this.buildProgramToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        this.runProgramToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        this.toolStrip = new System.Windows.Forms.ToolStrip();
        this.newToolStripButton = new System.Windows.Forms.ToolStripButton();
        this.openToolStripButton = new System.Windows.Forms.ToolStripButton();
        this.saveToolStripButton = new System.Windows.Forms.ToolStripButton();
        this.printToolStripButton = new System.Windows.Forms.ToolStripButton();
        this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
        this.cutToolStripButton = new System.Windows.Forms.ToolStripButton();
        this.copyToolStripButton = new System.Windows.Forms.ToolStripButton();
        this.pasteToolStripButton = new System.Windows.Forms.ToolStripButton();
        this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
        this.buildToolStripButton = new System.Windows.Forms.ToolStripButton();
        this.runToolStripButton = new System.Windows.Forms.ToolStripButton();
        this.timer = new System.Windows.Forms.Timer(this.components);
        this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
        this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
        this.printDialog = new System.Windows.Forms.PrintDialog();
        this.printPreviewDialog = new System.Windows.Forms.PrintPreviewDialog();
        this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
        this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
        this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
        this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
        this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
        this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
        this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
        this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
        this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripMenuItem();
        this.splitContainer1 = new System.Windows.Forms.SplitContainer();
        this.tabControl1 = new System.Windows.Forms.TabControl();
        this.tabPage2 = new System.Windows.Forms.TabPage();
        this.outputRichTextBox = new System.Windows.Forms.RichTextBox();
        this.toolStripContainer1.ContentPanel.SuspendLayout();
        this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
        this.toolStripContainer1.SuspendLayout();
        this.menuStrip.SuspendLayout();
        this.toolStrip.SuspendLayout();
        this.contextMenuStrip.SuspendLayout();
        this.splitContainer1.Panel1.SuspendLayout();
        this.splitContainer1.Panel2.SuspendLayout();
        this.splitContainer1.SuspendLayout();
        this.tabControl1.SuspendLayout();
        this.tabPage2.SuspendLayout();
        this.SuspendLayout();
        // 
        // statusStrip
        // 
        this.statusStrip.Location = new System.Drawing.Point(0, 624);
        this.statusStrip.Name = "statusStrip";
        this.statusStrip.Size = new System.Drawing.Size(740, 22);
        this.statusStrip.TabIndex = 0;
        this.statusStrip.Text = "statusStrip1";
        // 
        // toolStripContainer1
        // 
        // 
        // toolStripContainer1.ContentPanel
        // 
        this.toolStripContainer1.ContentPanel.Controls.Add(this.textEditorControl);
        this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(740, 427);
        this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
        this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
        this.toolStripContainer1.Name = "toolStripContainer1";
        this.toolStripContainer1.Size = new System.Drawing.Size(740, 476);
        this.toolStripContainer1.TabIndex = 1;
        this.toolStripContainer1.Text = "toolStripContainer1";
        // 
        // toolStripContainer1.TopToolStripPanel
        // 
        this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.menuStrip);
        this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.toolStrip);
        // 
        // textEditorControl
        // 
        this.textEditorControl.ConvertTabsToSpaces = true;
        this.textEditorControl.Dock = System.Windows.Forms.DockStyle.Fill;
        this.textEditorControl.Location = new System.Drawing.Point(0, 0);
        this.textEditorControl.Name = "textEditorControl";
        this.textEditorControl.ShowHRuler = true;
        this.textEditorControl.Size = new System.Drawing.Size(740, 427);
        this.textEditorControl.TabIndent = 2;
        this.textEditorControl.TabIndex = 0;
        this.textEditorControl.ToolTipRequest += new System.EventHandler<DigitalRune.Windows.TextEditor.ToolTipRequestEventArgs>(this.ToolTipRequest);
        this.textEditorControl.CompletionRequest += new System.EventHandler<DigitalRune.Windows.TextEditor.Completion.CompletionEventArgs>(this.CompletionRequest);
        this.textEditorControl.InsightRequest += new System.EventHandler<DigitalRune.Windows.TextEditor.Insight.InsightEventArgs>(this.InsightRequest);
        // 
        // menuStrip
        // 
        this.menuStrip.Dock = System.Windows.Forms.DockStyle.None;
        this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.buildToolStripMenuItem});
        this.menuStrip.Location = new System.Drawing.Point(0, 0);
        this.menuStrip.Name = "menuStrip";
        this.menuStrip.Size = new System.Drawing.Size(740, 24);
        this.menuStrip.TabIndex = 0;
        this.menuStrip.Text = "menuStrip1";
        // 
        // fileToolStripMenuItem
        // 
        this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.toolStripSeparator,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.toolStripSeparator1,
            this.printToolStripMenuItem,
            this.printPreviewToolStripMenuItem,
            this.toolStripSeparator2,
            this.exitToolStripMenuItem});
        this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
        this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
        this.fileToolStripMenuItem.Text = "&File";
        // 
        // newToolStripMenuItem
        // 
        this.newToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("newToolStripMenuItem.Image")));
        this.newToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
        this.newToolStripMenuItem.Name = "newToolStripMenuItem";
        this.newToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
        this.newToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
        this.newToolStripMenuItem.Text = "&New";
        this.newToolStripMenuItem.Click += new System.EventHandler(this.New);
        // 
        // openToolStripMenuItem
        // 
        this.openToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("openToolStripMenuItem.Image")));
        this.openToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
        this.openToolStripMenuItem.Name = "openToolStripMenuItem";
        this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
        this.openToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
        this.openToolStripMenuItem.Text = "&Open";
        this.openToolStripMenuItem.Click += new System.EventHandler(this.Open);
        // 
        // toolStripSeparator
        // 
        this.toolStripSeparator.Name = "toolStripSeparator";
        this.toolStripSeparator.Size = new System.Drawing.Size(143, 6);
        // 
        // saveToolStripMenuItem
        // 
        this.saveToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripMenuItem.Image")));
        this.saveToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
        this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
        this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
        this.saveToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
        this.saveToolStripMenuItem.Text = "&Save";
        this.saveToolStripMenuItem.Click += new System.EventHandler(this.Save);
        // 
        // saveAsToolStripMenuItem
        // 
        this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
        this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
        this.saveAsToolStripMenuItem.Text = "Save &As";
        this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.SaveAs);
        // 
        // toolStripSeparator1
        // 
        this.toolStripSeparator1.Name = "toolStripSeparator1";
        this.toolStripSeparator1.Size = new System.Drawing.Size(143, 6);
        // 
        // printToolStripMenuItem
        // 
        this.printToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("printToolStripMenuItem.Image")));
        this.printToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
        this.printToolStripMenuItem.Name = "printToolStripMenuItem";
        this.printToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
        this.printToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
        this.printToolStripMenuItem.Text = "&Print";
        this.printToolStripMenuItem.Click += new System.EventHandler(this.Print);
        // 
        // printPreviewToolStripMenuItem
        // 
        this.printPreviewToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("printPreviewToolStripMenuItem.Image")));
        this.printPreviewToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
        this.printPreviewToolStripMenuItem.Name = "printPreviewToolStripMenuItem";
        this.printPreviewToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
        this.printPreviewToolStripMenuItem.Text = "Print Pre&view";
        this.printPreviewToolStripMenuItem.Click += new System.EventHandler(this.PrintPreview);
        // 
        // toolStripSeparator2
        // 
        this.toolStripSeparator2.Name = "toolStripSeparator2";
        this.toolStripSeparator2.Size = new System.Drawing.Size(143, 6);
        // 
        // exitToolStripMenuItem
        // 
        this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
        this.exitToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
        this.exitToolStripMenuItem.Text = "E&xit";
        this.exitToolStripMenuItem.Click += new System.EventHandler(this.Exit);
        // 
        // editToolStripMenuItem
        // 
        this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.undoToolStripMenuItem,
            this.redoToolStripMenuItem,
            this.toolStripSeparator3,
            this.cutToolStripMenuItem,
            this.copyToolStripMenuItem,
            this.pasteToolStripMenuItem,
            this.toolStripSeparator4,
            this.selectAllToolStripMenuItem});
        this.editToolStripMenuItem.Name = "editToolStripMenuItem";
        this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
        this.editToolStripMenuItem.Text = "&Edit";
        // 
        // undoToolStripMenuItem
        // 
        this.undoToolStripMenuItem.Name = "undoToolStripMenuItem";
        this.undoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
        this.undoToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
        this.undoToolStripMenuItem.Text = "&Undo";
        this.undoToolStripMenuItem.Click += new System.EventHandler(this.Undo);
        // 
        // redoToolStripMenuItem
        // 
        this.redoToolStripMenuItem.Name = "redoToolStripMenuItem";
        this.redoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Y)));
        this.redoToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
        this.redoToolStripMenuItem.Text = "&Redo";
        this.redoToolStripMenuItem.Click += new System.EventHandler(this.Redo);
        // 
        // toolStripSeparator3
        // 
        this.toolStripSeparator3.Name = "toolStripSeparator3";
        this.toolStripSeparator3.Size = new System.Drawing.Size(141, 6);
        // 
        // cutToolStripMenuItem
        // 
        this.cutToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("cutToolStripMenuItem.Image")));
        this.cutToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
        this.cutToolStripMenuItem.Name = "cutToolStripMenuItem";
        this.cutToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
        this.cutToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
        this.cutToolStripMenuItem.Text = "Cu&t";
        this.cutToolStripMenuItem.Click += new System.EventHandler(this.Cut);
        // 
        // copyToolStripMenuItem
        // 
        this.copyToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("copyToolStripMenuItem.Image")));
        this.copyToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
        this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
        this.copyToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
        this.copyToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
        this.copyToolStripMenuItem.Text = "&Copy";
        this.copyToolStripMenuItem.Click += new System.EventHandler(this.Copy);
        // 
        // pasteToolStripMenuItem
        // 
        this.pasteToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("pasteToolStripMenuItem.Image")));
        this.pasteToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
        this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
        this.pasteToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
        this.pasteToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
        this.pasteToolStripMenuItem.Text = "&Paste";
        this.pasteToolStripMenuItem.Click += new System.EventHandler(this.Paste);
        // 
        // toolStripSeparator4
        // 
        this.toolStripSeparator4.Name = "toolStripSeparator4";
        this.toolStripSeparator4.Size = new System.Drawing.Size(141, 6);
        // 
        // selectAllToolStripMenuItem
        // 
        this.selectAllToolStripMenuItem.Name = "selectAllToolStripMenuItem";
        this.selectAllToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
        this.selectAllToolStripMenuItem.Text = "Select &All";
        this.selectAllToolStripMenuItem.Click += new System.EventHandler(this.SelectAll);
        // 
        // buildToolStripMenuItem
        // 
        this.buildToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buildProgramToolStripMenuItem,
            this.runProgramToolStripMenuItem});
        this.buildToolStripMenuItem.Name = "buildToolStripMenuItem";
        this.buildToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
        this.buildToolStripMenuItem.Text = "Build";
        // 
        // buildProgramToolStripMenuItem
        // 
        this.buildProgramToolStripMenuItem.Name = "buildProgramToolStripMenuItem";
        this.buildProgramToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F7)));
        this.buildProgramToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
        this.buildProgramToolStripMenuItem.Text = "Build program";
        this.buildProgramToolStripMenuItem.Click += new System.EventHandler(this.buildProgramToolStripMenuItem_Click);
        // 
        // runProgramToolStripMenuItem
        // 
        this.runProgramToolStripMenuItem.Name = "runProgramToolStripMenuItem";
        this.runProgramToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F5)));
        this.runProgramToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
        this.runProgramToolStripMenuItem.Text = "Run program";
        this.runProgramToolStripMenuItem.Click += new System.EventHandler(this.runProgramToolStripMenuItem_Click);
        // 
        // toolStrip
        // 
        this.toolStrip.Dock = System.Windows.Forms.DockStyle.None;
        this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripButton,
            this.openToolStripButton,
            this.saveToolStripButton,
            this.printToolStripButton,
            this.toolStripSeparator6,
            this.cutToolStripButton,
            this.copyToolStripButton,
            this.pasteToolStripButton,
            this.toolStripSeparator7,
            this.buildToolStripButton,
            this.runToolStripButton});
        this.toolStrip.Location = new System.Drawing.Point(3, 24);
        this.toolStrip.Name = "toolStrip";
        this.toolStrip.Size = new System.Drawing.Size(231, 25);
        this.toolStrip.TabIndex = 1;
        // 
        // newToolStripButton
        // 
        this.newToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
        this.newToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("newToolStripButton.Image")));
        this.newToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
        this.newToolStripButton.Name = "newToolStripButton";
        this.newToolStripButton.Size = new System.Drawing.Size(23, 22);
        this.newToolStripButton.Text = "&New";
        this.newToolStripButton.Click += new System.EventHandler(this.New);
        // 
        // openToolStripButton
        // 
        this.openToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
        this.openToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("openToolStripButton.Image")));
        this.openToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
        this.openToolStripButton.Name = "openToolStripButton";
        this.openToolStripButton.Size = new System.Drawing.Size(23, 22);
        this.openToolStripButton.Text = "&Open";
        this.openToolStripButton.Click += new System.EventHandler(this.Open);
        // 
        // saveToolStripButton
        // 
        this.saveToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
        this.saveToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripButton.Image")));
        this.saveToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
        this.saveToolStripButton.Name = "saveToolStripButton";
        this.saveToolStripButton.Size = new System.Drawing.Size(23, 22);
        this.saveToolStripButton.Text = "&Save";
        this.saveToolStripButton.Click += new System.EventHandler(this.Save);
        // 
        // printToolStripButton
        // 
        this.printToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
        this.printToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("printToolStripButton.Image")));
        this.printToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
        this.printToolStripButton.Name = "printToolStripButton";
        this.printToolStripButton.Size = new System.Drawing.Size(23, 22);
        this.printToolStripButton.Text = "&Print";
        this.printToolStripButton.Click += new System.EventHandler(this.Print);
        // 
        // toolStripSeparator6
        // 
        this.toolStripSeparator6.Name = "toolStripSeparator6";
        this.toolStripSeparator6.Size = new System.Drawing.Size(6, 25);
        // 
        // cutToolStripButton
        // 
        this.cutToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
        this.cutToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("cutToolStripButton.Image")));
        this.cutToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
        this.cutToolStripButton.Name = "cutToolStripButton";
        this.cutToolStripButton.Size = new System.Drawing.Size(23, 22);
        this.cutToolStripButton.Text = "C&ut";
        this.cutToolStripButton.Click += new System.EventHandler(this.Cut);
        // 
        // copyToolStripButton
        // 
        this.copyToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
        this.copyToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("copyToolStripButton.Image")));
        this.copyToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
        this.copyToolStripButton.Name = "copyToolStripButton";
        this.copyToolStripButton.Size = new System.Drawing.Size(23, 22);
        this.copyToolStripButton.Text = "&Copy";
        this.copyToolStripButton.Click += new System.EventHandler(this.Copy);
        // 
        // pasteToolStripButton
        // 
        this.pasteToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
        this.pasteToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("pasteToolStripButton.Image")));
        this.pasteToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
        this.pasteToolStripButton.Name = "pasteToolStripButton";
        this.pasteToolStripButton.Size = new System.Drawing.Size(23, 22);
        this.pasteToolStripButton.Text = "&Paste";
        this.pasteToolStripButton.Click += new System.EventHandler(this.Paste);
        // 
        // toolStripSeparator7
        // 
        this.toolStripSeparator7.Name = "toolStripSeparator7";
        this.toolStripSeparator7.Size = new System.Drawing.Size(6, 25);
        // 
        // buildToolStripButton
        // 
        this.buildToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
        this.buildToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("buildToolStripButton.Image")));
        this.buildToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
        this.buildToolStripButton.Name = "buildToolStripButton";
        this.buildToolStripButton.Size = new System.Drawing.Size(23, 22);
        this.buildToolStripButton.Text = "toolStripButton1";
        this.buildToolStripButton.Click += new System.EventHandler(this.buildToolStripButton_Click);
        // 
        // runToolStripButton
        // 
        this.runToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
        this.runToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("runToolStripButton.Image")));
        this.runToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
        this.runToolStripButton.Name = "runToolStripButton";
        this.runToolStripButton.Size = new System.Drawing.Size(23, 22);
        this.runToolStripButton.Text = "toolStripButton1";
        this.runToolStripButton.Click += new System.EventHandler(this.runToolStripButton_Click);
        // 
        // timer
        // 
        this.timer.Enabled = true;
        this.timer.Interval = 2000;
        this.timer.Tick += new System.EventHandler(this.UpdateFoldings);
        // 
        // openFileDialog
        // 
        this.openFileDialog.Filter = "Compile files (*.smp)|*.smp|All files (*.*)|*.*";
        // 
        // saveFileDialog
        // 
        this.saveFileDialog.Filter = "Compile files (*.smp)|*.smp|All files (*.*)|*.*";
        // 
        // printDialog
        // 
        this.printDialog.UseEXDialog = true;
        // 
        // printPreviewDialog
        // 
        this.printPreviewDialog.AutoScrollMargin = new System.Drawing.Size(0, 0);
        this.printPreviewDialog.AutoScrollMinSize = new System.Drawing.Size(0, 0);
        this.printPreviewDialog.ClientSize = new System.Drawing.Size(400, 300);
        this.printPreviewDialog.Enabled = true;
        this.printPreviewDialog.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog.Icon")));
        this.printPreviewDialog.Name = "printPreviewDialog";
        this.printPreviewDialog.Visible = false;
        // 
        // contextMenuStrip
        // 
        this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripMenuItem2,
            this.toolStripSeparator5,
            this.toolStripMenuItem3,
            this.toolStripMenuItem4,
            this.toolStripMenuItem5,
            this.toolStripSeparator8,
            this.toolStripMenuItem6});
        this.contextMenuStrip.Name = "contextMenuStrip";
        this.contextMenuStrip.Size = new System.Drawing.Size(123, 148);
        // 
        // toolStripMenuItem1
        // 
        this.toolStripMenuItem1.Name = "toolStripMenuItem1";
        this.toolStripMenuItem1.Size = new System.Drawing.Size(122, 22);
        this.toolStripMenuItem1.Text = "Undo";
        this.toolStripMenuItem1.Click += new System.EventHandler(this.Undo);
        // 
        // toolStripMenuItem2
        // 
        this.toolStripMenuItem2.Name = "toolStripMenuItem2";
        this.toolStripMenuItem2.Size = new System.Drawing.Size(122, 22);
        this.toolStripMenuItem2.Text = "Redo";
        this.toolStripMenuItem2.Click += new System.EventHandler(this.Redo);
        // 
        // toolStripSeparator5
        // 
        this.toolStripSeparator5.Name = "toolStripSeparator5";
        this.toolStripSeparator5.Size = new System.Drawing.Size(119, 6);
        // 
        // toolStripMenuItem3
        // 
        this.toolStripMenuItem3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem3.Image")));
        this.toolStripMenuItem3.ImageTransparentColor = System.Drawing.Color.Magenta;
        this.toolStripMenuItem3.Name = "toolStripMenuItem3";
        this.toolStripMenuItem3.Size = new System.Drawing.Size(122, 22);
        this.toolStripMenuItem3.Text = "Cut";
        this.toolStripMenuItem3.Click += new System.EventHandler(this.Cut);
        // 
        // toolStripMenuItem4
        // 
        this.toolStripMenuItem4.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem4.Image")));
        this.toolStripMenuItem4.ImageTransparentColor = System.Drawing.Color.Magenta;
        this.toolStripMenuItem4.Name = "toolStripMenuItem4";
        this.toolStripMenuItem4.Size = new System.Drawing.Size(122, 22);
        this.toolStripMenuItem4.Text = "Copy";
        this.toolStripMenuItem4.Click += new System.EventHandler(this.Copy);
        // 
        // toolStripMenuItem5
        // 
        this.toolStripMenuItem5.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem5.Image")));
        this.toolStripMenuItem5.ImageTransparentColor = System.Drawing.Color.Magenta;
        this.toolStripMenuItem5.Name = "toolStripMenuItem5";
        this.toolStripMenuItem5.Size = new System.Drawing.Size(122, 22);
        this.toolStripMenuItem5.Text = "Paste";
        this.toolStripMenuItem5.Click += new System.EventHandler(this.Paste);
        // 
        // toolStripSeparator8
        // 
        this.toolStripSeparator8.Name = "toolStripSeparator8";
        this.toolStripSeparator8.Size = new System.Drawing.Size(119, 6);
        // 
        // toolStripMenuItem6
        // 
        this.toolStripMenuItem6.Name = "toolStripMenuItem6";
        this.toolStripMenuItem6.Size = new System.Drawing.Size(122, 22);
        this.toolStripMenuItem6.Text = "Select All";
        this.toolStripMenuItem6.Click += new System.EventHandler(this.SelectAll);
        // 
        // splitContainer1
        // 
        this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
        this.splitContainer1.Location = new System.Drawing.Point(0, 0);
        this.splitContainer1.Name = "splitContainer1";
        this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
        // 
        // splitContainer1.Panel1
        // 
        this.splitContainer1.Panel1.Controls.Add(this.toolStripContainer1);
        // 
        // splitContainer1.Panel2
        // 
        this.splitContainer1.Panel2.Controls.Add(this.tabControl1);
        this.splitContainer1.Size = new System.Drawing.Size(740, 624);
        this.splitContainer1.SplitterDistance = 476;
        this.splitContainer1.TabIndex = 2;
        // 
        // tabControl1
        // 
        this.tabControl1.Controls.Add(this.tabPage2);
        this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
        this.tabControl1.Location = new System.Drawing.Point(0, 0);
        this.tabControl1.Name = "tabControl1";
        this.tabControl1.SelectedIndex = 0;
        this.tabControl1.Size = new System.Drawing.Size(740, 144);
        this.tabControl1.TabIndex = 0;
        // 
        // tabPage2
        // 
        this.tabPage2.Controls.Add(this.outputRichTextBox);
        this.tabPage2.Location = new System.Drawing.Point(4, 22);
        this.tabPage2.Name = "tabPage2";
        this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
        this.tabPage2.Size = new System.Drawing.Size(732, 118);
        this.tabPage2.TabIndex = 1;
        this.tabPage2.Text = "Output";
        this.tabPage2.UseVisualStyleBackColor = true;
        // 
        // outputRichTextBox
        // 
        this.outputRichTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
        this.outputRichTextBox.Location = new System.Drawing.Point(3, 3);
        this.outputRichTextBox.Name = "outputRichTextBox";
        this.outputRichTextBox.Size = new System.Drawing.Size(726, 112);
        this.outputRichTextBox.TabIndex = 0;
        this.outputRichTextBox.Text = "";
        // 
        // CodeEditor
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(740, 646);
        this.Controls.Add(this.splitContainer1);
        this.Controls.Add(this.statusStrip);
        this.Name = "CodeEditor";
        this.Text = "SampleEditor";
        this.toolStripContainer1.ContentPanel.ResumeLayout(false);
        this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
        this.toolStripContainer1.TopToolStripPanel.PerformLayout();
        this.toolStripContainer1.ResumeLayout(false);
        this.toolStripContainer1.PerformLayout();
        this.menuStrip.ResumeLayout(false);
        this.menuStrip.PerformLayout();
        this.toolStrip.ResumeLayout(false);
        this.toolStrip.PerformLayout();
        this.contextMenuStrip.ResumeLayout(false);
        this.splitContainer1.Panel1.ResumeLayout(false);
        this.splitContainer1.Panel2.ResumeLayout(false);
        this.splitContainer1.ResumeLayout(false);
        this.tabControl1.ResumeLayout(false);
        this.tabPage2.ResumeLayout(false);
        this.ResumeLayout(false);
        this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.StatusStrip statusStrip;
    private System.Windows.Forms.ToolStripContainer toolStripContainer1;
    private DigitalRune.Windows.TextEditor.TextEditorControl textEditorControl;
    private System.Windows.Forms.MenuStrip menuStrip;
    private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
    private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    private System.Windows.Forms.ToolStripMenuItem printToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem printPreviewToolStripMenuItem;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
    private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem undoToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem redoToolStripMenuItem;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
    private System.Windows.Forms.ToolStripMenuItem cutToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
    private System.Windows.Forms.ToolStripMenuItem selectAllToolStripMenuItem;
    private System.Windows.Forms.ToolStrip toolStrip;
    private System.Windows.Forms.ToolStripButton newToolStripButton;
    private System.Windows.Forms.ToolStripButton openToolStripButton;
    private System.Windows.Forms.ToolStripButton saveToolStripButton;
    private System.Windows.Forms.ToolStripButton printToolStripButton;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
    private System.Windows.Forms.ToolStripButton cutToolStripButton;
    private System.Windows.Forms.ToolStripButton copyToolStripButton;
    private System.Windows.Forms.ToolStripButton pasteToolStripButton;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
    private System.Windows.Forms.Timer timer;
    private System.Windows.Forms.OpenFileDialog openFileDialog;
    private System.Windows.Forms.SaveFileDialog saveFileDialog;
    private System.Windows.Forms.PrintDialog printDialog;
    private System.Windows.Forms.PrintPreviewDialog printPreviewDialog;
    private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
    private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
    private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
    private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
    private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
    private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem5;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
    private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem6;
    private System.Windows.Forms.ToolStripButton buildToolStripButton;
    private System.Windows.Forms.ToolStripButton runToolStripButton;
    private System.Windows.Forms.SplitContainer splitContainer1;
    private System.Windows.Forms.TabControl tabControl1;
    private System.Windows.Forms.TabPage tabPage2;
    private System.Windows.Forms.RichTextBox outputRichTextBox;
    private System.Windows.Forms.ToolStripMenuItem buildToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem buildProgramToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem runProgramToolStripMenuItem;
  }
}

