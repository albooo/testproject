using CommonProject.Helpers;
using TechTalk.SpecFlow;
using static TechTalk.SpecFlow.ScenarioContext;

namespace TestProject.Bindings
{
    [Binding]
    public sealed class ScenarioInitialize
    {
        [BeforeScenario]
        public void RunBrowser()
        {
            Current.Set(WebDriver.Start());
        }

        [AfterScenario]
        public void QuitBrowser()
        {
            WebDriver.Quit();
        }
    }
}
