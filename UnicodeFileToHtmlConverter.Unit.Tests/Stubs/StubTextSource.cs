using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDDMicroExercises.UnicodeFileToHtmlTextConverter.Interfaces;

namespace UnicodeFileToHtmlConverter.Unit.Tests.Stubs
{
    public class StubTextSource : ITextSource
    {
        public string Text { get { return _text; } }
        private string _text;
        public StubTextSource(string text)
        {
            _text = text;
        }

        public TextReader GetReader()
        {
            return new StringReader(Text);
        }
    }
}
