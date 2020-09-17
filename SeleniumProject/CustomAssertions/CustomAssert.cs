using FluentAssertions;
using log4net;
using SeleniumProject.Logging;

namespace SeleniumProject.CustomAssertions
{
    public static class CustomAssert
    {
        private static readonly ILog Logger = LogHelper.GetXmlLogger(typeof(CustomAssert));

        public static void AssertThatTextIsCorrect(string expectedText, string actualText)
        {
            Logger.Info($"Expected Text: {expectedText} : Actual text: {actualText}");
            expectedText.Should().Be(actualText);

        }

        public static void AssertThatTextContainsExpectedString(string expectedText, string actualText)
        {
            Logger.Info($"Actual Text: {actualText} should contain: {expectedText}");
            actualText.Should().Contain(expectedText);

        }

    }
}
