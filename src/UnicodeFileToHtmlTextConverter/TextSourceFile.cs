using System.IO;
using TDDMicroExercises.UnicodeFileToHtmlTextConverter.Interfaces;

namespace TDDMicroExercises.UnicodeFileToHtmlTextConverter
{
    public class TextSourceFile : ITextSource
    {
        private readonly string _fullFilenameWithPath;

        public TextSourceFile(string fullFilenameWithPath)
        {
            _fullFilenameWithPath = fullFilenameWithPath;
        }

        public TextReader GetReader()
        {
            return File.OpenText(_fullFilenameWithPath);
        }
    }
}
