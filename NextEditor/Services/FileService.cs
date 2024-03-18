using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NextEditor.Services
{
    internal class FileService
    {
        internal static Stream GetStream(string path)
        {
            return File.OpenRead(path);
        }
    }
}
