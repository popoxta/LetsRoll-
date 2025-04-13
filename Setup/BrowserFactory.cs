using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace LetsRoll;

internal enum BrowserTypes
{
    Chrome,
    Firefox,
    Edge,
    Safari,
}

public class BrowserFactory
{
    private readonly Dictionary<string, BrowserTypes> _browserNames = new()
    {
        { "chrome", BrowserTypes.Chrome },
        { "firefox", BrowserTypes.Firefox },
        { "edge", BrowserTypes.Edge },
        { "safari", BrowserTypes.Safari },
    };

    public IWebDriver Browser { get; private set; }


    private void GetBrowserConfiguration(string browserType, List<string> options = null)
    {
        var browser = _browserNames[browserType.ToLower()];
        Browser = browser switch
        {
            BrowserTypes.Chrome => GetChromeDriver(options),
            BrowserTypes.Firefox or BrowserTypes.Edge or BrowserTypes.Safari => throw new NotImplementedException(
                $"Browser type {browser} is not implemented!"),
            _ => throw new ArgumentException("Invalid browser configuration!")
        };
    }

    private static ChromeDriver GetChromeDriver(List<string> options = null)
    {
        var browserOptions = new ChromeOptions();
        if (options is not null)
            browserOptions.AddArguments(options);
        return new ChromeDriver("", browserOptions);
    }
}