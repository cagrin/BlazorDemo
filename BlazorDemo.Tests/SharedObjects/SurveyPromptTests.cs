namespace BlazorDemo.Tests.SharedObjects
{
    using BlazorDemo.Shared;
    using Bunit;

    [TestClass]
    public class SurveyPromptTests
    {
        [TestMethod]
        public void SurveyPromptShouldHasTitle()
        {
            const string surveyPromptTitle = "SurveyPromptTitle";

            using var ctx = new TestContext();
            var cut = ctx.RenderComponent<SurveyPrompt>(parameters => parameters.Add(p => p.Title, surveyPromptTitle));

            cut.Find("strong").MarkupMatches($"<strong>{surveyPromptTitle}</strong>");
        }
    }
}