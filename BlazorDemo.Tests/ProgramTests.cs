namespace BlazorDemo.Tests
{
    using BlazorDemo;
    using Bunit;

    [TestClass]
    public class ProgramTests
    {
        [TestMethod]
        public void ProgramShouldRun()
        {
            Application.Run(args: null!);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ConfigureShouldThrowArgumentNullException()
        {
            Application.Configure(app: null!);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddServicesShouldThrowArgumentNullException()
        {
            Application.AddServices(builder: null!);
        }
    }
}