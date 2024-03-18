using NextEditor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NextEditor.ViewModels
{
    public interface IDocumentViewModel
    {
        public IDocument Document { get; }
    }
}
