using System;
using System.Collections.Generic;
using System.Threading;
using discover_camping.helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

public class ReservationPoller : IDisposable {
    
    public IWebDriver Driver {get; private set;}
    public IDictionary<String, Object> Vars {get; private set;}
    public IJavaScriptExecutor Js {get; private set;}

    public ReservationPoller()
    {
        var options = new ChromeOptions();
        options.AddArgument(Constants.HEADLESS);

        Driver = new ChromeDriver(options);
        Js = (IJavaScriptExecutor)Driver;
        Vars = new Dictionary<String, Object>();
    }

    public void Dispose()
    {
        Driver.Quit();
    }

    public bool IsReservationAvailable(string location, int month = Constants.AUGUST, string day = Constants.SIX) {

        OpenDiscoverCamping();
        SetLocation(location);
        SetDate(month, day);
        Search();

        var isBookingAvailable = IsBookingAvailable();

        return isBookingAvailable;
    }

    private void OpenDiscoverCamping()
    {
        Driver.Navigate().GoToUrl(Constants.DISCOVER_BACKCOUNTRY_RESERVATIONS);
        Driver.Manage().Window.Size = new System.Drawing.Size(1708, 920);
    }

    private void SetLocation(string location)
    {
        Driver.FindElement(By.Id(CssSelectors.LOCATION)).Click();
        {
            var dropdown = Driver.FindElement(By.Id(CssSelectors.LOCATION));
            dropdown.FindElement(By.XPath(location)).Click();
        }
        Driver.FindElement(By.Id(CssSelectors.LOCATION)).Click();
    }

    private void SetDate(int month, string day)
    {
        var currentMonth = DateTime.Today.Month;
        var numMonthsToAdvance = month - currentMonth;

        Driver.FindElement(By.Id(CssSelectors.ARRIVAL_DATE)).Click();
        
        while (numMonthsToAdvance-- > 0)
        {
            Driver.FindElement(By.CssSelector(CssSelectors.MONTH_NEXT)).Click();
        }

        Driver.FindElement(By.LinkText(day)).Click();
    }

    private void Search()
    {
        Driver.FindElement(By.Id(CssSelectors.SEARCH)).Click();
        Thread.Sleep(1500); // wait for page to load
    }

    private bool IsBookingAvailable()
    {
        var element = Driver.FindElement(By.Id(CssSelectors.DATE_BOX));

        return (!element.Text.Contains(Constants.NOT_AVAILABLE));
    }
}