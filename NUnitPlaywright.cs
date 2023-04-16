using Microsoft.Playwright;
using NUnit.Framework;
using Microsoft.Playwright.NUnit;

namespace PlaywrightTests;

public class NUnitPlaywright : PageTest
{
    [SetUp]
    public async Task Setup()
    {
        await Page.GotoAsync("http://eaapp.somee.com/");
    }

    [Test]
    public async Task Test1()
    {
        
        await Page.ClickAsync("text=Login");
        await Page.ScreenshotAsync(new PageScreenshotOptions
        {
            Path = "eapp.jpg"
        });
        await Page.FillAsync("#UserName", "admin");
        await Page.FillAsync("#Password", "password");
        await Page.ClickAsync("text=Log in");
        var isExist = await Page.Locator("text=Employee Details").IsVisibleAsync();
        Assert.IsTrue(isExist);
        await Expect(Page.Locator("text=Employee Details")).ToBeVisibleAsync();
    }
}