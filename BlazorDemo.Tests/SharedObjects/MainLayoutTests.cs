namespace BlazorDemo.Tests.SharedObjects
{
    using BlazorDemo.Shared;
    using Bunit;

    [TestClass]
    public class MainLayoutTests
    {
        [TestMethod]
        public void MainLayoutTestsShouldRender()
        {
            using var ctx = new TestContext();
            var cut = ctx.RenderComponent<MainLayout>();
        }
    }
}