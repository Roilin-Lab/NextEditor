using System.Collections.ObjectModel;
using System.IO;
using System.Windows.Input;
using NextEditor.Commands;
using NextEditor.Utility;

namespace NextEditor.ViewModels;

public class MainWindowViewModel : BaseViewModel
{
    private readonly ObservableCollection<FileViewModel> _files = [];
    private readonly FileDialogService _dialogService = new();
    private FileViewModel _selectedFile;

    public ObservableCollection<FileViewModel> Files => _files;
    public FileViewModel SelectedFile
    {
        get => _selectedFile;
        set => SetField(ref _selectedFile, value);
    }

    public MainWindowViewModel()
    {
        CloseCommand = new RelayCommand(CloseFile);
        CreateCommand = new RelayCommand(_ => CreateFile());
        OpenCommand = new RelayCommand(_ => OpenFile());
        SaveAsCommand = new RelayCommand(SaveAsFile);
        SaveCommand = new RelayCommand(SaveFile);

        CreateFile();
        _selectedFile = _files[0];
    }

    public void CreateFile()
    {
        FileViewModel file = new FileViewModel();
        _files.Add(file);
        SelectedFile = file;
    }

    public void OpenFile()
    {
        if (_dialogService.ShowDialog(FileMode.Open, out var path) && path != null)
        {
            FileViewModel file = new FileViewModel(path);
            _files.Add(file);
            SelectedFile = file;
        }
    }

    public void SaveAsFile(object parameter)
    {
        if (_dialogService.ShowDialog(FileMode.Create, out var path) && path != null)
        {
            var file = (parameter as FileViewModel)!;
            file.Save(path);
        }
    }

    public void SaveFile(object parameter)
    {
        var file = (parameter as FileViewModel)!;
        if (file.IsNew)
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

    public ICommand CreateCommand { get; }
    public ICommand OpenCommand { get; }
    public ICommand CloseCommand { get; }
    public ICommand SaveAsCommand { get; }
    public ICommand SaveCommand { get; }

}