using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;


namespace UnitTestProject1
{
    class WebPageInteraction
    {
        // Region to create and declare WebElements
        #region elements definition
        By byTagNWebSiteTitle = By.TagName("title");
        By byCssCreateNewAccountBtn = By.CssSelector("#content>div>div>div>div:nth-of-type(2)>div>div>form>div:nth-of-type(5)>a");
        By byCssFirstNameInput = By.CssSelector("#reg_form_box>div>div>div>div:nth-of-type(1)>input:nth-of-type(1)");
        By byCssLastNameInput = By.CssSelector("#reg_form_box>div>div>div>div>div>input");
        By byCssPhoneNumberInput = By.CssSelector("#reg_form_box>div:nth-of-type(2) input");
        By byCssPasswordInput = By.CssSelector("#reg_form_box>div:nth-of-type(4) input");
        By byCssMonthSel = By.CssSelector("#month");
        By byCssDaySel = By.CssSelector("#day");
        By byCssYearSel = By.CssSelector("#year");
        By byCssGenderOpt = By.CssSelector("#reg_form_box>div:nth-of-type(7)>span>span:nth-of-type(1)");
        By textDisplayed = By.CssSelector("body div:nth-of-type(3)>div>div>div>div>div:nth-of-type(2)");
        #endregion

        // Property
        public String webSiteTitle { get; set; }

        String firstNameStr = "Miriam";
        String lastNameStr = "Ramirez";
        String phoneNumberStr = "0123456789";
        String passwordStr = "myPasswordE2";
        String monthValueStr = "11";
        String dayValueStr = "31";
        String yearValueStr = "2000";
        String textExpected = "It’s quick and easy.";

        public void gotoWebSite(IWebDriver driver)
        {
            // Go to facebook.com
            driver.Navigate().GoToUrl("https://www.facebook.com/");
        }

        public void validatePageTitle(IWebDriver driver)
        {
            // Validate the title of the page. Use A property to obtain Web title and assert to validate it 
            waitWebElement(driver, byTagNWebSiteTitle, "");
            webSiteTitle = getWebSiteTitle(driver);
            Assert.AreEqual(driver.Title.ToString(), webSiteTitle);
        }

        public void FillInformation(IWebDriver driver)
        {
            // Fill all Sign Up section and print the information that you are filling
            waitWebElement(driver, byCssCreateNewAccountBtn, "ElementToBeClickable");
            clickAction(driver, byCssCreateNewAccountBtn);
            waitWebElement(driver, byCssFirstNameInput, "elementToBePresent");
            sendKeysAction(driver, byCssFirstNameInput, firstNameStr);
            Console.WriteLine("Filled Field: {0} with value: \"{1}\"", firstNameStr, "First Name");
            waitWebElement(driver, byCssLastNameInput, "elementToBePresent");
            sendKeysAction(driver, byCssLastNameInput, lastNameStr);
            Console.WriteLine("Filled Field: {0} with value: \"{1}\"",lastNameStr, "Last Name");
            waitWebElement(driver, byCssPhoneNumberInput, "elementToBePresent");
            sendKeysAction(driver, byCssPhoneNumberInput, phoneNumberStr);
            Console.WriteLine("Filled Field: {0} with value: \"{1}\"",phoneNumberStr, "Phone Number");
            waitWebElement(driver, byCssPasswordInput, "elementToBePresent");
            sendKeysAction(driver, byCssPasswordInput, passwordStr);
            Console.WriteLine("Filled Field: {0} with value: \"{1}\"",passwordStr, "Password");           
        }
        
        public void ChooseDifferentBD(IWebDriver driver)
        {
            // Choose a different Birthday not the default one
            waitWebElement(driver, byCssDaySel, "ElementToBeClickable");
            fillBirthday(driver, byCssDaySel, dayValueStr);
            waitWebElement(driver, byCssMonthSel, "ElementToBeClickable");
            fillBirthday(driver, byCssMonthSel, monthValueStr);
            waitWebElement(driver, byCssYearSel, "ElementToBeClickable");
            fillBirthday(driver, byCssYearSel, yearValueStr);
        }

        public void ClickOnFemale(IWebDriver driver)
        {
            // Click on Female. Create your custome click method that contains the logger 
            waitWebElement(driver, byCssGenderOpt, "ElementToBeSelected");
            clickAction(driver, byCssGenderOpt, true);
        }

        public void ValidateTextIsPresent(IWebDriver driver)
        {
            // Validate text is present. Create a custom Assert Method to print a sucessful message
            var actualStr = driver.FindElement(textDisplayed).Text.ToString(); 
            if (actualStr ==  textExpected)
            {
                Console.WriteLine($"Custom Assert. Successful Assert! The text \"{actualStr}\" is equal to \"{textExpected}\"");
            }
            else
            {
                throw new CustomException($"Custom Exception Message. Custom Assert. Failed Assert: The text \"{actualStr}\" is different compared with \"{textExpected}\"");
            }
        }

        // Element Interaction
        public void waitWebElement(IWebDriver driver, By byElement, String condition)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
                switch (condition)
                {
                    case "ElementToBeClickable":
                        wait.Until(ExpectedConditions.ElementToBeClickable(byElement));
                        break;
                    case "elementToBePresent":
                        wait.Until(ExpectedConditions.ElementIsVisible(byElement));
                        break;
                    default:
                        wait.Until(ExpectedConditions.ElementExists(byElement));
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: {0}", ex.Message);
            }
        }

        public String getWebSiteTitle(IWebDriver driver)
        {
            return driver.Title;
        }

        public void clickAction(IWebDriver driver, By ByElement)
        {
            driver.FindElement(ByElement).Click();
        }
        public void clickAction(IWebDriver driver, By ByElement, Boolean logAction)
        {
            driver.FindElement(ByElement).Click();
            Console.WriteLine("Female option was selected");
        }

        public void sendKeysAction(IWebDriver driver, By ByElement, String strValue)
        {
            driver.FindElement(ByElement).SendKeys(strValue);

        }

        public void fillBirthday(IWebDriver driver, By ByElement, String value)
        {
            var myDropDown = new SelectElement(driver.FindElement(ByElement));
            myDropDown.SelectByValue(value);
        }
    }
}
