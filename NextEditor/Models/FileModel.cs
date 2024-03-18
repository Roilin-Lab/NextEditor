﻿using NextEditor.Helpers;
using System.IO;
using System.Windows;
using System.Windows.Documents;

namespace NextEditor.Models;

public class FileModel : ObservableObject, IDocument
{
    private string _fileName;
    private string _filePath;
    private bool _isSaved;
    private readonly string _extension;
    private FlowDocument _document;

    private const string DEFAULT_FILE_NAME = "New File";
    private const string DEFAULT_DATA_EXTENSION = ".txt";

    public FileModel()
    {
        _fileName = DEFAULT_FILE_NAME;
        _extension = DEFAULT_DATA_EXTENSION;
        _filePath = "";
        _isSaved = false;
        _document = new FlowDocument();
    }

    public FileModel(string filePath, FlowDocument document)
    {
        _filePath = filePath;
        _document = document;
        _fileName = Path.GetFileName(_filePath);
        _extension = Path.GetExtension(_filePath);
        _isSaved = true;
    }

    public string Title { get => _fileName; set => SetField(ref _fileName, value); }
    public FlowDocument Document { get => _document; set => SetField(ref _document, value); }
    public bool IsSaved { get => _isSaved; set => SetField(ref _isSaved, value); }
    public string FilePath { get => _filePath; set => SetField(ref _filePath, value); }
}