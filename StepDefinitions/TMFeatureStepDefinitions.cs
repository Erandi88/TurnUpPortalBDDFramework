using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using Reqnroll;
using ReqnrollTurnUpPortal.Pages;
using ReqnrollTurnUpPortal.Utilities;
using System;

namespace ReqnrollTurnUpPortal.StepDefinitions
{
    [Binding]
    public class TMFeatureStepDefinitions : CommonDriver
    {
        LoginPage loginPageObj = new LoginPage();
        HomePage homePageObj = new HomePage();
        TMPage tmPageObj = new TMPage();

        [BeforeScenario]
        public void Setup()
        {

            var options = new ChromeOptions();

            options.AddUserProfilePreference("credentials_enable_service", false);
            options.AddUserProfilePreference("profile.password_manager_enabled", false);
            options.AddUserProfilePreference("profile.password_manager_leak_detection", false);
            options.AddArgument("--disable-features=PasswordLeakDetection");
            //options.AddArgument("--user-data-dir=C:\\TempChromeProfile");

            driver = new ChromeDriver(options);
        }

        [Given("I logged into Turnup portal successfully")]
        public void GivenILoggedIntoTurnupPortalSuccessfully()
        {
          
            loginPageObj.LoginActions(driver);
        }

        [Given("I nevigate to the time and material page")]
        public void GivenINevigateToTheTimeAndMaterialPage()
        {
            homePageObj.NavigateToTMPage(driver);
        }

        [When("I crete a new time and material record")]
        public void WhenICreteANewTimeAndMaterialRecord()
        {
            tmPageObj.CreateNewTimeAndMaterialRecord(driver);
        }

        [Then("The record should be created successfully")]
        public void ThenTheRecordShouldBeCreatedSuccessfully()
        {
            /*string newCode = tmPageObj.GetCode(driver);
            string newDescription = tmPageObj.getDescription(driver);
            string newPrice = tmPageObj.getPrice(driver);*/

            string newCode = tmPageObj.GetLastRowCellText(driver, 1);
            string newDescription = tmPageObj.GetLastRowCellText(driver, 3);
            string newPrice = tmPageObj.GetLastRowCellText(driver, 4);

            Assert.Multiple(() =>
            {
                Assert.That(newCode, Is.EqualTo("TA Programme 999"), "Actual Code and expected Code do not match.");
                Assert.That(newDescription, Is.EqualTo("This is description for code 999."), "Actual Description and expected Description do not match.");
                Assert.That(newPrice, Is.EqualTo("17"), "Actual Price and expected Price do not match.");
            });

            //Assert.That(newCode == "TA Programme 999", "Actual Code and expected Code do not match.");
            //Assert.That(newDescription == "This is description for code 999.", "Actual Description and expected Description do not match.");
            //Assert.That(newPrice == "17", "Actual Price and expected Price do not match.");
        }

        [When("I update the {string} and {string} on an existing Time record")]
        public void WhenIUpdateTheAndOnAnExistingTimeRecord(string code, string description)
        {
            tmPageObj.EditTimeAndMaterialRecord(driver, code, description);
        }

        [Then("the record should have the updated {string} and {string}")]
        public void ThenTheRecordShouldHaveTheUpdatedAnd(string code, string description)
        {
            string editedCode = tmPageObj.GetEditedCode(driver);
            string editedDescription = tmPageObj.GetEditedDescription(driver);

            Assert.That(editedCode, Is.EqualTo(code), "Actual edited Code and expected edited Code do not match.");
            Assert.That(editedDescription, Is.EqualTo(description), "Expected Edited Description and actual edited description do not match.");
        }

        [AfterScenario]
        public void CloseTestRun()
        {
            driver?.Quit(); //This avoids problems if driver creation failed.
        }


    }
}
