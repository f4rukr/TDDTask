using FluentAssertions;
using TDDMicroExercises.UnicodeFileToHtmlTextConverter;
using UnicodeFileToHtmlConverter.Unit.Tests.Stubs;
using Xunit;

namespace UnicodeFileToHtmlConverter.Unit.Tests
{
    public class UniCodeFileToHtmlValidatorTests
    {

        private const string MULTIPLE_LINES_TEXT = "first line\nsecond line\nthird line";
        private const string AMPERSAND_TEXT = "Tom & Jerry";

        [Theory]
        [InlineData(MULTIPLE_LINES_TEXT)]
        public void Should_Append_Breakline_On_Every_Line(string multipleLinesText)
        {
            //Arrange
            var stub = new StubTextSource(multipleLinesText);
            var converter = new UnicodeFileToHtmlTextConverter(stub);

            //Act
            string result = converter.ConvertToHtml();

            //Assert
            result.Should().Be("first line<br />second line<br />third line<br />");
        }

        [Theory]
        [InlineData(AMPERSAND_TEXT)]
        public void Should_Convert_And_To_Special_Character_Ampersand(string ampersandText)
        {
            //Arrange
            var stub = new StubTextSource(ampersandText);
            var converter = new UnicodeFileToHtmlTextConverter(stub);

            //Act
            string result = converter.ConvertToHtml();

            //Assert
            result.Should().Be("Tom &amp; Jerry<br />");
        }
    }
}