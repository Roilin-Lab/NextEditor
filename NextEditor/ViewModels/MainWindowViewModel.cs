using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using System.Windows.Input;
using NextEditor.Helpers;
using NextEditor.Utility;

namespace NextEditor.ViewModels;

public class MainWindowViewModel : ObservableObject
{
    private readonly ObservableCollection<IDocumentViewModel> _files;
    private IDocumentViewModel _selectedDocument;
    private readonly WelcomeViewModel welcomeDocument = new();

    public IEnumerable<IDocumentViewModel> Files => _files;
    public IDocumentViewModel SelectedDocument
    {
        get => _selectedDocument;
        set => SetField(ref _selectedDocument, value);
    }

    public MainWindowViewModel()
    {
        _files = [welcomeDocument];
        _selectedDocument = welcomeDocument;
    }

    public void CreateFile()
    {
        if (SelectedDocument is WelcomeViewModel) _files.Remove(welcomeDocument);

        var file = new FileViewModel();
        _files.Add(file);
        _selectedDocument = file;
        OnPropertyChanged(nameof(SelectedDocument));
    }

    public void OpenFile()
    {
        if (FileDialogService.ShowDialog(FileMode.Open, out string? path) && path != null)
        {
            if (SelectedDocument is WelcomeViewModel) _files.Remove(welcomeDocument);

            var file = new FileViewModel(path);
            _files.Add(file);
            _selectedDocument = file;
            OnPropertyChanged(nameof(SelectedDocument));
        }
    }

    public void SaveAsFile(object parameter)
    {
        if (parameter == null) return;

        var file = (parameter as FileViewModel);

        if (FileDialogService.ShowDialog(FileMode.Create, out string? path, file.Document.Title) && path != null)
        {
            file.Save(path);
        }
    }

    public void SaveFile(object parameter)
    {
        if (parameter is null) return;

        var file = (parameter as FileViewModel);

        if (string.IsNullOrEmpty(file.GetPathFile()))
        {
            SaveAsFile(file);
        }
        else
        {
            file.Save();
        }
    }

    public void CloseFile(object parameter)
    {
        if (parameter == null) return;

        if (_files.Count == 1) CreateFile();

        _files.Remove(parameter as IDocumentViewModel);
    }

    public ICommand CreateCommand => new RelayCommand(p => CreateFile());
    public ICommand OpenCommand => new RelayCommand(p => OpenFile());
    public ICommand CloseCommand => new RelayCommand(CloseFile);
    public ICommand SaveAsCommand => new RelayCommand(SaveAsFile, p => p is FileViewModel);
    public ICommand SaveCommand => new RelayCommand(SaveFile, p => p is FileViewModel);
    public ICommand AddWelcomePageCommand => new RelayCommand(p => _files.Add(welcomeDocument), p => !_files.Contains(welcomeDocument));
    public ICommand ExitCommand => new RelayCommand(p => Application.Current.Shutdown());

}