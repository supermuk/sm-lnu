using System;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;
using Compiler.Compile;
using Compiler.GUI;
using DigitalRune.Windows.TextEditor;
using DigitalRune.Windows.TextEditor.Actions;
using DigitalRune.Windows.TextEditor.Completion;
using DigitalRune.Windows.TextEditor.Document;
using DigitalRune.Windows.TextEditor.Highlighting;
using DigitalRune.Windows.TextEditor.Insight;
using DigitalRune.Windows.TextEditor.Markers;
using DigitalRune.Windows.TextEditor.Selection;
using System.IO;
using System.Text;


namespace Compiler
{
    public partial class CodeEditor : Form
    {
        private const string _DefaultContent = "";
        private string _FileName = String.Empty;


        public CodeEditor()
        {
            InitializeComponent();

            // Show the default text in the editor
            textEditorControl.Document.TextContent = _DefaultContent;
            // Set the syntax-highlighting for C#
            textEditorControl.Document.HighlightingStrategy = HighlightingManager.Manager.FindHighlighter("SMP");

            // Set the formatting for C#
            //textEditorControl.Document.FormattingStrategy = new CSharpFormattingStrategy();

            // Set a simple folding strategy that folds all "{ ... }" blocks
            textEditorControl.Document.FoldingManager.FoldingStrategy = new CodeFoldingStrategy();

            // ----- Use the following settings for XML content instead of C#
            //textEditorControl.Document.HighlightingStrategy = HighlightingManager.Manager.FindHighlighter("XML");
            //textEditorControl.Document.FormattingStrategy = new XmlFormattingStrategy();
            //textEditorControl.Document.FoldingManager.FoldingStrategy = new XmlFoldingStrategy();
            // -----

            // Try to set font "Consolas", because it's a lot prettier:
            var consolasFont = new Font("Consolas", 9.75f);
            
            if (consolasFont.Name == "Consolas")        // Set font if it is available on this machine.
                textEditorControl.Font = consolasFont;

            // Add a context menu to the text editor
            textEditorControl.ContextMenuStrip = contextMenuStrip;
        }


        private void New(object sender, EventArgs e)
        {
            textEditorControl.Document.TextContent = "";
            textEditorControl.Refresh();
        }


        private void Open(object sender, EventArgs e)
        {
            var result = openFileDialog.ShowDialog();

            if (result != DialogResult.OK)
            {
                return;
            }

            _FileName = openFileDialog.FileName;
            textEditorControl.LoadFile(_FileName);
        }


        private void Save(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(_FileName))
            {
                SaveAs(sender, e);
            }
            else
            {
                textEditorControl.SaveFile(_FileName);
            }
        }


        private void SaveAs(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(_FileName))
            {
                saveFileDialog.FileName = _FileName;
            }

            var result = saveFileDialog.ShowDialog();

            if (result != DialogResult.OK)
            {
                return;
            }

            _FileName = saveFileDialog.FileName;
            textEditorControl.SaveFile(_FileName);
        }


        private void Print(object sender, EventArgs e)
        {
            var printDocument = textEditorControl.PrintDocument;
            
            printDialog.Document = printDocument;

            var result = printDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                printDocument.Print();
            }
        }


        private void PrintPreview(object sender, EventArgs e)
        {
            printPreviewDialog.Document = textEditorControl.PrintDocument;
            printPreviewDialog.ShowDialog();
        }


        private void Exit(object sender, EventArgs e)
        {
            Close();
        }


        private void Undo(object sender, EventArgs e)
        {
            var undo = new Undo();
            undo.Execute(textEditorControl);
        }


        private void Redo(object sender, EventArgs e)
        {
            var redo = new Redo();
            redo.Execute(textEditorControl);
        }


        private void Cut(object sender, EventArgs e)
        {
            var cut = new Cut();
            cut.Execute(textEditorControl);
        }


        private void Copy(object sender, EventArgs e)
        {
            var copy = new Copy();
            copy.Execute(textEditorControl);
        }


        private void Paste(object sender, EventArgs e)
        {
            var paste = new Paste();
            paste.Execute(textEditorControl);
        }

        private void SelectAll(object sender, EventArgs e)
        {
            var selectAll = new SelectWholeDocument();
            selectAll.Execute(textEditorControl);
        }

        private void UpdateFoldings(object sender, EventArgs e)
        {
            // The foldings needs to be manually updated:
            // In this example a timer updates the foldings every 2 seconds.
            // You should manually update the foldings when
            // - a new document is loaded
            // - content is added (paste)
            // - the parse-info is updated
            // - etc.
            textEditorControl.Document.FoldingManager.UpdateFolds(null, null);
        }

        private void CompletionRequest(object sender, CompletionEventArgs e)
        {
            if (textEditorControl.CompletionWindowVisible)
            {
                return;
            }

            // e.Key contains the key that the user wants to insert and which triggered
            // the CompletionRequest.
            // e.Key == '\0' means that the user triggered the CompletionRequest by pressing <Ctrl> + <Space>.

            if (e.Key == '\0')
            {
                // The user has requested the completion window by pressing <Ctrl> + <Space>.
                textEditorControl.ShowCompletionWindow(new CodeCompletionDataProvider(), e.Key, false);
            }
            else if (char.IsLetter(e.Key))
            {
                // The user is typing normally. 
                // -> Show the completion to provide suggestions. Automatically close the window if the 
                // word the user is typing does not match the completion data. (Last argument.)
                textEditorControl.ShowCompletionWindow(new CodeCompletionDataProvider(), e.Key, true);
            }
        }

        private void InsightRequest(object sender, InsightEventArgs e)
        {
            textEditorControl.ShowInsightWindow(new MethodInsightDataProvider());
        }

        private void ToolTipRequest(object sender, ToolTipRequestEventArgs e)
        {
            if (!e.InDocument || e.ToolTipShown)
            {
                return;
            }

            // Get word under cursor
            var position = e.LogicalPosition;
            var line = textEditorControl.Document.GetLineSegment(position.Y);

            if (line == null)
            {
                return;
            }

            var word = line.GetWord(position.X);
            
            if (word != null && !String.IsNullOrEmpty(word.Word))
            {
                e.ShowToolTip("Current word: \"" + word.Word + "\"\n" + "\nRow: " + (position.Y + 1) + " Column: " + (position.X + 1));
            }
        }

        private void Mark(object sender, EventArgs e)
        {
            if (!textEditorControl.ActiveTextAreaControl.TextArea.SelectionManager.HasSomethingSelected)
            {
                return;
            }

            foreach (var selection in textEditorControl.ActiveTextAreaControl.TextArea.SelectionManager.Selections)
            {
                var marker = new Marker(selection.Offset, selection.Length, MarkerType.SolidBlock, Color.DarkRed, Color.White);
                
                textEditorControl.Document.MarkerStrategy.AddMarker(marker);
            }

            textEditorControl.Refresh();
        }

        private void Underline(object sender, EventArgs e)
        {
            if (!textEditorControl.ActiveTextAreaControl.TextArea.SelectionManager.HasSomethingSelected)
            {
                return;
            }

            foreach (var selection in textEditorControl.ActiveTextAreaControl.TextArea.SelectionManager.Selections)
            {
                var marker = new Marker(selection.Offset, selection.Length, MarkerType.Underlined, Color.Blue);
                textEditorControl.Document.MarkerStrategy.AddMarker(marker);
            }

            textEditorControl.Refresh();
        }

        private void Zigzag(object sender, EventArgs e)
        {
            if (!textEditorControl.ActiveTextAreaControl.TextArea.SelectionManager.HasSomethingSelected)
            {
                return;
            }

            foreach (var selection in textEditorControl.ActiveTextAreaControl.TextArea.SelectionManager.Selections)
            {
                var marker = new Marker(selection.Offset, selection.Length, MarkerType.WaveLine, Color.Red);
                textEditorControl.Document.MarkerStrategy.AddMarker(marker);
            }
            textEditorControl.Refresh();
        }

        private void ClearMarkers(object sender, EventArgs e)
        {
            textEditorControl.Document.MarkerStrategy.Clear();
            textEditorControl.Refresh();
        }

        private bool Build()
        {
            try
            {
                Scanner scanner = null;

                if (_FileName == String.Empty)
                {
                    _FileName = "program.smp";
                }

                var sw = new StreamWriter(_FileName, false, Encoding.Unicode);
                sw.Write(textEditorControl.Text);
                sw.Close();

                using (TextReader input = File.OpenText(_FileName))
                {
                    scanner = new Scanner(input);
                }

                var parser = new Parser(scanner.Tokens);
                var generator = new Generator(parser.Result, Path.GetFileNameWithoutExtension(_FileName) + ".exe");
                outputRichTextBox.Text = DateTime.Now.ToShortTimeString() + " >>> " + Path.GetFileNameWithoutExtension(_FileName) + ".exe successfully build. \r\n" + outputRichTextBox.Text;
            }
            catch (Exception ex)
            {
                outputRichTextBox.Text = DateTime.Now.ToShortTimeString() + " >>> Error: " + ex.Message + "\r\n" + outputRichTextBox.Text;
                return false;
            }

            return true;
        }

        private void buildToolStripButton_Click(object sender, EventArgs e)
        {
            Build();
        }

        private void runToolStripButton_Click(object sender, EventArgs e)
        {
            if (Build())
            {
                var proc = new System.Diagnostics.Process
                               {
                                   StartInfo = {FileName = Path.GetFileNameWithoutExtension(_FileName) + ".exe"}
                               };

                proc.Start();
            }
            else
            {
                MessageBox.Show("There was errors during compiling");
            }
        }

    private void buildProgramToolStripMenuItem_Click(object sender, EventArgs e)
    {
        Build();
    }

    private void runProgramToolStripMenuItem_Click(object sender, EventArgs e)
    {
        if (Build())
        {
            var proc = new System.Diagnostics.Process
            {
                StartInfo = { FileName = Path.GetFileNameWithoutExtension(_FileName) + ".exe" }
            };

            proc.Start();
        }
        else
        {
            MessageBox.Show("There was errors during compiling");
        }
    }

  }
}