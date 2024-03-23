using System.Windows.Controls;
using NextEditor.Helpers;
using NextEditor.Models;
using NextEditor.Services;

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

    public string GetPathFile() => _fileModel.FilePath;

    public void OnTextChanged(object sender, TextChangedEventArgs e)
    {
        if (e.Changes.Any())
        {
            _fileModel.OnTextChanged();
        }
    }

    public void Save(string? path = null)
    {
        FileService.SaveDocument(_fileModel, path);
    }

}