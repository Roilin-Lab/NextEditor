using System.IO;

namespace NextEditor.Models;

public class FileModel
{
    public string Name { get; set; }
    public string Format { get; private set; }

    public bool IsNew => _path == null;

    private string? _path;
    private const string DefaultName = "Новый файл.txt";
    private const string DefaultFormat = ".txt";

    public FileModel()
    {
        Name = DefaultName;
        Format = DefaultFormat;
    }

    public FileModel(string path)
    {
        _path = path;
        Name = Path.GetFileName(path);
        Format = Path.GetExtension(path);
    }

    public Stream GetStream(FileMode fileMode, string? path = null)
    {
        if (_path == null && path == null)
            throw new NullReferenceException("You cannot create a Stream with a null path. Update the path or provide it as an argument.");
        
        return File.Open(path ?? _path, fileMode);
    }

    public void UpdatePropertyFromPath(string path)
    {
        _path = path;
        Name = Path.GetFileName(path);
        Format = Path.GetExtension(path);
    }
}