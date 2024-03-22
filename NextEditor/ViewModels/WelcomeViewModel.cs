using NextEditor.Helpers;
using NextEditor.Models;
using System.Windows.Documents;

namespace NextEditor.ViewModels
{
    internal class WelcomeViewModel : ObservableObject, IDocumentViewModel
    {
        public IDocument Document { get; set; }

        public WelcomeViewModel()
        {
            Document = new WelcomeDocument();
        }
    }

    class WelcomeDocument : IDocument
    {
        public string Title { get; }

        public FlowDocument Document { get; }

        public WelcomeDocument()
        {
            Title = "Welcome";
            Document = new FlowDocument();
        }
    }
}
