using System.IO;
using Microsoft.Win32;
using NextEditor.Helpers;

namespace NextEditor.Utility;

public static class FileDialogService
{
    public static bool ShowDialog(FileMode fileMode, out string? path)
    {
        FileDialog dialog;
        switch (fileMode)
        {
            case FileMode.Open:
                dialog = new OpenFileDialog();
                break;
            case FileMode.Create:
                dialog = new SaveFileDialog();
                break;
            default:
                throw new ArgumentException($"Supported mod file: Create, Open");
        }

        dialog.Filter = SupportExtension.GetFormatsFilter();

        if (dialog.ShowDialog() ?? false)
        {
            path = dialog.FileName;
            dialog.Reset();
            return true;
        }

        path = null;
        return false;
    }
}