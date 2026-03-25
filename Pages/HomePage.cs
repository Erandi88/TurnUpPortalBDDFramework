using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using ReqnrollTurnUpPortal.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReqnrollTurnUpPortal.Pages
{
    public class HomePage
    {
        public void NavigateToTMPage(IWebDriver driver)
        {
            //Nevigate Time & material Page
            IWebElement admintrationTab = driver.FindElement(By.XPath("//a[normalize-space()='Administration']"));
            admintrationTab.Click();

            Wait.WaitToBeClickable(driver, "XPath", "/html/body/div[3]/div/div/ul/li[5]/ul/li[3]/a", 10);

            IWebElement timeAndMaterialOption = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/ul/li[3]/a"));
            timeAndMaterialOption.Click();
        }
    }
}
