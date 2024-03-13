using System.Windows.Documents;

namespace NextEditor.ViewModels
{
    internal interface IDocumentViewModel
    {
        public string Title { get; set; }
        public FlowDocument Document { get; }
    }
}
