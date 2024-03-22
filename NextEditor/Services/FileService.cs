using System.IO;
using NextEditor.Helpers;
using System.Windows.Documents;
using NextEditor.Models;


namespace NextEditor.Services
{
    internal class FileService
    {
        internal static Stream GetStream(string path, FileMode fileMode)
        {
            return File.Open(path, fileMode);
        }

        public static void SaveDocument(FileModel fileModel, string? path = null)
        {
            var filePath = path ?? fileModel.FilePath;

            if (string.IsNullOrEmpty(filePath))
                throw new NullOrEmptyPathException($"Argument path is null or empty");

            var textRange = new TextRange(fileModel.Document.ContentStart, fileModel.Document.ContentEnd);
            var stream = GetStream(filePath, FileMode.Create);
            textRange.Save(stream, SupportExtension.ConvertToDataFormats(Path.GetExtension(filePath)));

            fileModel.UpdateFileWhenSaved(filePath);
            stream.Close();
        }
    }

    public class NullOrEmptyPathException(string S) : Exception
    {
        public string S { get; init; } = S;

        public void Deconstruct(out string S)
        {
            S = this.S;
        }
    }
}
