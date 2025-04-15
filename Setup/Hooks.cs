using System.Configuration;
using OpenQA.Selenium;
using Reqnroll;
using Reqnroll.BoDi;

namespace LetsRoll.Setup;

[Binding]
public sealed class Hooks(IObjectContainer container)
{
    [BeforeScenario]
    public void SetupWebDriver()
    {
        var factory = new BrowserFactory(ConfigurationManager.AppSettings["browser"]);
        container.RegisterInstanceAs(factory.Browser);
    }

    [AfterScenario]
    public void DestroyWebDriver()
    {
        var driver = container.Resolve<IWebDriver>();
        if (driver is null) return;
        driver.Quit();
        driver.Dispose();
    }
}