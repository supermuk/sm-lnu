using DigitalRune.Windows.TextEditor;
using DigitalRune.Windows.TextEditor.Document;
using DigitalRune.Windows.TextEditor.Insight;

namespace Compiler
{
  class MethodInsightDataProvider : AbstractInsightDataProvider
  {
    int _argumentStartOffset;   // The offset where the method arguments starts.
    string[] _insightText;      // The insight information.


    protected override int ArgumentStartOffset
    {
      get { return _argumentStartOffset; }
    }


    public override int InsightDataCount
    {
      get { return (_insightText != null) ? _insightText.Length : 0; }
    }


    public override string GetInsightData(int number)
    {
      return (_insightText != null) ? _insightText[number] : string.Empty;
    }


    public override void SetupDataProvider(string fileName)
    {

    }


    private void SetupDataProviderForMethod(string methodName, int argumentStartOffset)
    {
      
    }
  }
}
