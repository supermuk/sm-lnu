using DigitalRune.Windows.TextEditor.Insight;

namespace Compiler.GUI
{
    class MethodInsightDataProvider : AbstractInsightDataProvider
    {
        readonly int _ArgumentStartOffset;   // The offset where the method arguments starts.
        readonly string[] _InsightText;      // The insight information.

        public MethodInsightDataProvider(int argumentStartOffset, string[] insightText)
        {
            _ArgumentStartOffset = argumentStartOffset;
            _InsightText = insightText;
        }

        public MethodInsightDataProvider()
        {
            // TODO: Complete member initialization
        }


        protected override int ArgumentStartOffset
        {
            get { return _ArgumentStartOffset; }
        }


        public override int InsightDataCount
        {
            get { return (_InsightText != null) ? _InsightText.Length : 0; }
        }


        public override string GetInsightData(int number)
        {
            return (_InsightText != null) ? _InsightText[number] : string.Empty;
        }


        public override void SetupDataProvider(string fileName)
        {

        }
    }
}
