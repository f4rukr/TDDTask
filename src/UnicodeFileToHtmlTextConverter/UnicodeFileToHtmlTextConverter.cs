using System.IO;
using System.Web;
using TDDMicroExercises.UnicodeFileToHtmlTextConverter.Interfaces;

namespace TDDMicroExercises.UnicodeFileToHtmlTextConverter
{
    public class UnicodeFileToHtmlTextConverter
    {
        private readonly ITextSource _textSource;

        public UnicodeFileToHtmlTextConverter(ITextSource textSource)
        {
            _textSource = textSource;
        }

        public string ConvertToHtml()
        {
            using (TextReader unicodeFileStream = _textSource.GetReader())
            {
                string html = string.Empty;

                string line = unicodeFileStream.ReadLine();
                while (line != null)
                {
                    html += HttpUtility.HtmlEncode(line);
                    html += "<br />";
                    line = unicodeFileStream.ReadLine();
                }

                return html;
            }
        }
    }
}
