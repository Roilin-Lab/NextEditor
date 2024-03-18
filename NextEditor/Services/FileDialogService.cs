using System.IO;
using Microsoft.Win32;
using NextEditor.Helpers;

namespace NextEditor.Utility;

public class FileDialogService
{
    private FileDialog _dialog;
    private readonly string _filter;

#pragma warning disable CS8618 // Поле, не допускающее значения NULL, должно содержать значение, отличное от NULL, при выходе из конструктора. Возможно, стоит объявить поле как допускающее значения NULL.
    public FileDialogService()
#pragma warning restore CS8618 // Поле, не допускающее значения NULL, должно содержать значение, отличное от NULL, при выходе из конструктора. Возможно, стоит объявить поле как допускающее значения NULL.
    {
        _filter = SupportExtension.GetFormatsFilter();
    }

    public bool ShowDialog(FileMode fileMode, out string? path)
    {
        switch (fileMode)
        {
            case FileMode.Open:
                _dialog = new OpenFileDialog();
                break;
            case FileMode.Create:
                _dialog = new SaveFileDialog();
                break;
            default:
                throw new ArgumentException($"Supported mod file: Create, Open");
        }

        _dialog.Filter = _filter;

        if (_dialog.ShowDialog() ?? false)
        {
            path = _dialog.FileName;
            _dialog.Reset();
            return true;
        }

        path = null;
        return false;
    }
}