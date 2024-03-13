using System.Windows;

namespace NextEditor.Utility;

public static class SupportExtension
{
    public static readonly Dictionary<string, string> Extension = new()
    {
        { ".txt", DataFormats.Text },
        { ".rtf", DataFormats.Rtf },
        { ".html", DataFormats.Html },
        { ".xaml", DataFormats.Xaml },
    };

    public static string ConvertToDataFormats(string extension)
    {
        return Extension[extension];
    }

    public static string GetFormatsFilter()
    {
        List<string> filter = new List<string>();
        filter.Add($"All files|*.*");

        foreach (var item in Extension)
        {
            filter.Add($"{item.Value} file (*{item.Key})|*{item.Key}");
        }
        return string.Join("|", filter);
    }
}
