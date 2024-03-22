using System.Collections.ObjectModel;
using System.IO;
using System.Windows.Input;
using NextEditor.Helpers;
using NextEditor.Models;
using NextEditor.Utility;

namespace NextEditor.ViewModels;

public class MainWindowViewModel : ObservableObject
{
    private readonly ObservableCollection<IDocumentViewModel> _files;
    private FileViewModel _selectedFile;

    public IEnumerable<IDocumentViewModel> Files => _files;
    public FileViewModel SelectedFile
    {
        get => _selectedFile;
        set => SetField(ref _selectedFile, value);
    }

    public MainWindowViewModel()
    {
        _files = new ObservableCollection<IDocumentViewModel>();
        var startUpFile = new FileViewModel();
        _files.Add(startUpFile);
        _selectedFile = startUpFile;
    }

    public void CreateFile()
    {
        var file = new FileViewModel();
        _files.Add(file);
        _selectedFile = file;
        OnPropertyChanged(nameof(SelectedFile));
    }

    public void OpenFile()
    {
        if (FileDialogService.ShowDialog(FileMode.Open, out string? path) && path != null)
        {
            var file = new FileViewModel(path);
            _files.Add(file);
            _selectedFile = file;
            OnPropertyChanged(nameof(SelectedFile));
        }
    }

    public void SaveAsFile(object parameter)
    {
        var file = (parameter as FileViewModel)!;

        if (FileDialogService.ShowDialog(FileMode.Create, out string? path) && path != null)
        {
            file.Save(path);
        }
    }

    public void SaveFile(object parameter)
    {
        var file = (parameter as FileViewModel)!;

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

        if (_files.Count == 1) CreateFile();
        _files.Remove((parameter as FileViewModel)!);
    }

    public ICommand CreateCommand => new RelayCommand(_ => CreateFile());
    public ICommand OpenCommand => new RelayCommand(_ => OpenFile());
    public ICommand CloseCommand => new RelayCommand(CloseFile);
    public ICommand SaveAsCommand => new RelayCommand(SaveAsFile);
    public ICommand SaveCommand => new RelayCommand(SaveFile);

}