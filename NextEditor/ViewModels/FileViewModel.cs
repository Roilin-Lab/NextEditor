using System.IO;
using System.Windows.Documents;
using NextEditor.Helpers;
using NextEditor.Models;
using NextEditor.Utility;

namespace NextEditor.ViewModels;

public class FileViewModel : ObservableObject, IDocumentViewModel
{
    private FileModel _fileModel;

    public IDocument Document => _fileModel;

    public FileViewModel()
    {
        _fileModel = new FileModel();
    }

    public FileViewModel(string path)
    {
        _fileModel = FileModel.CreateDocument(path);
    }

    public void OnTextChanged() => _fileModel.IsSaved = false;

    public void Save()
    {
        throw new NotImplementedException();
    }
    public static void LoadDocument(ref FlowDocument document) { throw new NotImplementedException();}
}