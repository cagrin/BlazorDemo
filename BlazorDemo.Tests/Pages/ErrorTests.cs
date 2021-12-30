namespace BlazorDemo.Tests.Pages
{
    using BlazorDemo.Pages;

    [TestClass]
    public class ErrorTests
    {
        [TestMethod]
        public void ErrorShouldHasRequestId()
        {
            var cut = new ErrorModel(logger: null!);
            Assert.IsFalse(cut.ShowRequestId);
        }

        [TestMethod]
        public void ErrorShouldHasOnGet()
        {
            var cut = new ErrorModel(logger: null!);
            cut.OnGet();
        }
    }
}