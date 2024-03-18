using System.Windows.Documents;

namespace NextEditor.Models
{
    public interface IDocument
    {
        string Title { get; set; }
        FlowDocument Document { get; set; }
    }
}
