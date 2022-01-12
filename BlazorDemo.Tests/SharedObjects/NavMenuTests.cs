namespace BlazorDemo.Tests.SharedObjects
{
    using Bunit;

    [TestClass]
    public class NavMenuTests
    {
        [TestMethod]
        public void NavMenuShouldToggleWhenClicked()
        {
            using var ctx = new TestContext();
            var cut = ctx.RenderComponent<BlazorDemo.Shared.NavMenu>();

            var before = cut.FindAll("div")[1].HasAttribute("class");

            cut.Find("button").Click();

            var after = cut.FindAll("div")[1].HasAttribute("class");
            var diffs = cut.GetChangesSinceFirstRender();
            var diff = diffs.ShouldHaveSingleChange();

            Assert.IsTrue(before);
            Assert.IsFalse(after);
            Assert.IsNotNull(diff);
        }
    }
}