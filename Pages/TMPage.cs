using NUnit.Framework;
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
    public class TMPage
    {
        public void CreateNewTimeAndMaterialRecord(IWebDriver driver)
        {
            //Exceptional Handling
            try
            {
                //Click on create new button
                IWebElement clickCreateNewButton = driver.FindElement(By.XPath("//*[@id=\"container\"]/p/a"));
                clickCreateNewButton.Click();
            }
            catch (Exception ex)
            {

                Assert.Fail("Create New button has not found. " + ex.Message);

            }

            //Select the time from description
            IWebElement selectTypeCode = driver.FindElement(By.XPath("//span[contains(text(),'select')]"));
            selectTypeCode.Click();
            //Thread.Sleep(2000);

            IWebElement timeOption = driver.FindElement(By.XPath("//*[@id=\"TypeCode_listbox\"]/li[2]"));
            timeOption.Click();

            //Type code into code textbox
            IWebElement typeCode = driver.FindElement(By.Id("Code"));
            typeCode.SendKeys("TA Programme 999");

            //Type description into description textbox
            IWebElement typeDescription = driver.FindElement(By.Id("Description"));
            typeDescription.SendKeys("This is description for code 999.");

            //Type price into price textbox
            IWebElement priceTapOverlap = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[4]/div/span[1]/span/input[1]"));
            priceTapOverlap.Click();

            IWebElement typePrice = driver.FindElement(By.Id("Price"));
            typePrice.SendKeys("17");

            Wait.WaitToBeClickable(driver, "Id", "SaveButton", 3);

            //Click on save button
            IWebElement clickSaveButton = driver.FindElement(By.Id("SaveButton"));
            clickSaveButton.Click();

            //Thread.Sleep(5000);
            /// Wait until Last Page button is clickable
            Wait.WaitToBeClickable(driver, "XPath", "//span[@class='k-icon k-i-seek-e']", 10);

            //checked if time record has been created successfully
            IWebElement goToLastPage = driver.FindElement(By.XPath("//span[@class='k-icon k-i-seek-e']"));
            goToLastPage.Click();

            // Wait until last row is visible
            Wait.WaitToBeVisible(driver, "XPath", "//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]", 10);
  
        }

        /*public string GetCode(IWebDriver driver)
        {
            IWebElement getNewCode = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));
            return getNewCode.Text;

        }

        public string getDescription(IWebDriver driver)
        {
            IWebElement getNewDescription = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[3]"));
            return getNewDescription.Text;
        }

        public string getPrice(IWebDriver driver)
        {
            IWebElement getNewPrice = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[4]"));
            return getNewPrice.Text;
        }*/

        //Use this following method to avod repeted code (GetCode, getDescription, getPrice)
        public string GetLastRowCellText(IWebDriver driver, int columnNumber)
        {
            string xpath = $"//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[{columnNumber}]";
            return driver.FindElement(By.XPath(xpath)).Text;
        }

        public void EditTimeAndMaterialRecord(IWebDriver driver, string code, string description)
        {
            Thread.Sleep(5000);
            IWebElement lastPageButton = driver.FindElement(By.XPath("//span[@class='k-icon k-i-seek-e']"));
            lastPageButton.Click();
            Thread.Sleep(5000);

            // Click Edit button on last row
            IWebElement editButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[5]/a[1]"));
            editButton.Click();
            //*[@id="tmsGrid"]/div[3]/table/tbody/tr[last()]/td[5]/a[1]

            Thread.Sleep(3000);
            //Edit code in the code textbox
            IWebElement editCodeTextbox = driver.FindElement(By.Id("Code"));
            editCodeTextbox.Clear();
            editCodeTextbox.SendKeys(code);

            //Edit description in description textbox
            IWebElement editDescriptionField = driver.FindElement(By.Id("Description"));
            editDescriptionField.Clear();
            editDescriptionField.SendKeys(description);

            //Edit price into price textbox
            IWebElement editPriceTapOverlap = driver.FindElement(By.XPath("//input[contains(@class,'k-formatted-value')]"));
            editPriceTapOverlap.Click();

            IWebElement editPrice = driver.FindElement(By.XPath("//input[@id='Price']"));
            editPrice.SendKeys(Keys.Control + "a");
            editPrice.SendKeys(Keys.Delete);
            editPrice.SendKeys("10");

            //click the save button
            IWebElement saveEditButton = driver.FindElement(By.Id("SaveButton"));
            saveEditButton.Click();
            Thread.Sleep(5000);

            //checked if time record has been edited successfully
            IWebElement goToLastPageCheckEditRow = driver.FindElement(By.XPath("//span[@class='k-icon k-i-seek-e']"));
            goToLastPageCheckEditRow.Click();
 
        }

        public string GetEditedCode(IWebDriver driver)
        {
            IWebElement editedCode = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));
            return editedCode.Text;
        }

        public string GetEditedDescription(IWebDriver driver)
        {
            IWebElement editedDescription = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[3]"));
            return editedDescription.Text;
        }

        public void DeleteTimeAndMaterialRecord(IWebDriver driver)
        {
            Thread.Sleep(5000);
            IWebElement lastPageButton = driver.FindElement(By.XPath("//span[@class='k-icon k-i-seek-e']"));
            lastPageButton.Click();
            Thread.Sleep(5000);

            //Click the delete button last row
            String codeValueLastRow = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]")).Text;
            Console.WriteLine("codeValueLastRow : " + codeValueLastRow);

            IWebElement clickDeleteButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[5]/a[2]"));
            clickDeleteButton.Click();

            //Click the Ok button 
            IAlert alert = driver.SwitchTo().Alert();
            alert.Accept();
            Thread.Sleep(2000);

            driver.Navigate().Refresh();

            Thread.Sleep(4000);
            IWebElement lastPageButtonToCheckDelete = driver.FindElement(By.XPath("//span[@class='k-icon k-i-seek-e']"));
            lastPageButtonToCheckDelete.Click();

            //checked if time record has been deleted successfully
            bool isRecordPresent = driver.PageSource.Contains(codeValueLastRow);

            Assert.That(isRecordPresent, Is.False, "Time Record was NOT deleted successfully");


            /* if (!isRecordPresent)
             {
                 Console.WriteLine("Time Record deleted successfully");
             }
             else
             {
                 Console.WriteLine("Time Record still exists");
             }**/
        }
    }
}
