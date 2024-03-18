using System.Collections.ObjectModel;
using System.IO;
using System.Windows.Input;
using NextEditor.Helpers;
using NextEditor.Utility;

namespace NextEditor.ViewModels;

public class MainWindowViewModel : ObservableObject
{
    private readonly ObservableCollection<FileViewModel> _files;
    private FileViewModel _selectedFile;

    public ObservableCollection<FileViewModel> Files => _files;
    public FileViewModel SelectedFile
    {
        get => _selectedFile;
        set => SetField(ref _selectedFile, value);
    }

    public MainWindowViewModel()
    {
        _files = new ObservableCollection<FileViewModel>();
        var startUpFile = new FileViewModel();
        _files.Add(startUpFile);
        _selectedFile = startUpFile;
    }

    public void CreateFile()
    {
        throw new NotImplementedException();
    }

    public void OpenFile()
    {
        throw new NotImplementedException();
    }

    public void SaveAsFile(object parameter)
    {
        throw new NotImplementedException();
    }

    public void SaveFile(object parameter)
    {
        throw new NotImplementedException();
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