using System.Collections.Generic;
using System.Windows.Forms;
using DigitalRune.Windows.TextEditor;
using DigitalRune.Windows.TextEditor.Completion;


namespace Compiler
{
  class CodeCompletionDataProvider : AbstractCompletionDataProvider
  {
    private readonly ImageList _imageList;

    public override ImageList ImageList
    {
      get { return _imageList; }
    }


    public CodeCompletionDataProvider()
    {
      // Create the image-list that is needed by the completion windows
      _imageList = new ImageList();
      _imageList.Images.Add(Resources.TemplateIcon);
      _imageList.Images.Add(Resources.FieldIcon);
      _imageList.Images.Add(Resources.MethodIcon);
    }


    public override ICompletionData[] GenerateCompletionData(string fileName, TextArea textArea, char charTyped)
    {
      // This class provides the data for the Code-Completion-Window.
      // Some random variables and methods are returned as completion data.

      List<ICompletionData> completionData = new List<ICompletionData>
      {
        // Add some random methods
        new DefaultCompletionData("print", "print method.", 2),
        new DefaultCompletionData("read_int", "read method", 2),
        new DefaultCompletionData("var", "variable declaration", 2),
      };


      // Add some snippets (text templates).
      List<Snippet> snippets = new List<Snippet>
      {
        new Snippet("for", "for|to  do\nend;", "for loop"),
      };

      // Add the snippets to the completion data
      foreach(Snippet snippet in snippets)
        completionData.Add(new SnippetCompletionData(snippet, 0));

      return completionData.ToArray();
    }
  }
}
