﻿using System.IO;
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
        var doc = new FlowDocument();
        LoadDocument(ref doc);
        _fileModel = new FileModel(path, doc);
    }

    public void Save()
    {
        throw new NotImplementedException();
    }
    static public void LoadDocument(ref FlowDocument document) { throw new NotImplementedException();}
}