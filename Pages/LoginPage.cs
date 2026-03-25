using OpenQA.Selenium;
using ReqnrollTurnUpPortal.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReqnrollTurnUpPortal.Pages
{
    public class LoginPage
    {
        private readonly string url = "http://horse.industryconnect.io/";

        private readonly By userNameTextboxLocator = By.Id("UserName");
        IWebElement usernametextbox;

        private readonly By passwordTextBoxLocator = By.Id("Password");
        IWebElement passwordTextbox;

        private readonly By loginBtnLocator = By.XPath("//*[@id=\"loginForm\"]/form/div[3]/input[1]");
        IWebElement loginButton;

        public void LoginActions(IWebDriver driver)
        {

            //Launch Turnup portal
            driver.Navigate().GoToUrl(url);
            driver.Manage().Window.Maximize();
            Thread.Sleep(1000);

            //Exceptional Handling
            /* try
             {
                 //Identify username textbox and enter valid username
                 usernametextbox = driver.FindElement(userNameTextboxLocator);
                 usernametextbox.SendKeys(userName);
             }
             catch (Exception ex) {

                 Assert.Fail("UserName Textbox has not found. " +ex.Message);
            }*/

            //Identify username textbox and enter valid username
            usernametextbox = driver.FindElement(userNameTextboxLocator);
            usernametextbox.SendKeys("hari");

            Wait.WaitToBeVisible(driver, "Id", "Password", 3);

            //Identify password textbox and enter valid passowrd
            passwordTextbox = driver.FindElement(passwordTextBoxLocator);
            passwordTextbox.SendKeys("123123");

            //Identify login button and check on it
            loginButton = driver.FindElement(loginBtnLocator);
            loginButton.Click();
            Thread.Sleep(2000);
        }

    }
}
