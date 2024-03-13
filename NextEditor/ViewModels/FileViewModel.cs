using System.IO;
using System.Windows.Documents;
using NextEditor.Models;
using NextEditor.Utility;

namespace NextEditor.ViewModels;

public class FileViewModel : BaseViewModel
{
    private  string _name;
	private readonly FileModel _file = new();
    private FlowDocument _document = new();
    private TextRange _textRange;
    private bool _saved = false;

    public string Name
    {
        get => _name;
        set => SetField(ref _name, value);
    }

    public bool Saved
    {
        get => _saved;
        set => SetField(ref _saved, value);
    }

    public bool IsNew => _file.IsNew;

    public FlowDocument Document
    {
        get => _document;
        set => SetField(ref _document, value);
    }
    public FileViewModel()
    {
        _name = _file.Name;
        _textRange = new TextRange(_document.ContentStart, _document.ContentEnd);
    }

    public FileViewModel(string path): this()
    {
        _file = new FileModel(path);
        OpenExisting();
    }

    private void OpenExisting()
    {
        using (var stream = _file.GetStream(FileMode.Open))
        {
            _textRange.Load(stream, SupportExtension.ConvertToDataFormats(_file.Format));
        }

        Saved = true;
    }

    public void Save(string? path = null)
    {
        if (path != null) _file.UpdatePropertyFromPath(path);
        
        using (var stream = _file.GetStream(FileMode.Create, path))
        {
            _textRange.Save(stream, SupportExtension.ConvertToDataFormats(_file.Format));
        }
        Saved = true;
    }

    public void OnTextChanged()
    {
        Saved = false;
    }
}