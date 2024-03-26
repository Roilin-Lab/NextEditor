﻿using System.Runtime.CompilerServices;
using System.Windows.Controls;
using System.Windows.Input;
using NextEditor.Helpers;
using NextEditor.Models;
using NextEditor.Services;

namespace NextEditor.ViewModels;

public class FileViewModel : ObservableObject, IDocumentViewModel
{
    private FileModel _fileModel;
    private bool _isVisibleFindAndReplace = false;
    private string _findText = string.Empty;
    private string _replaceText = string.Empty;

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

    private void CloseFindAndReplace()
    {
        IsVisibleFindAndReplace = false;
    }

    public ICommand CloseFindAndReplaceCommand => new RelayCommand(p => CloseFindAndReplace());

    public IDocument Document => _fileModel;
    public bool IsVisibleFindAndReplace { get => _isVisibleFindAndReplace; set => SetField(ref _isVisibleFindAndReplace, value); }

    public string FindText { get => _findText; set => SetField(ref _findText, value); }
    public string ReplaceText { get => _replaceText; set => SetField(ref _replaceText, value); }
}