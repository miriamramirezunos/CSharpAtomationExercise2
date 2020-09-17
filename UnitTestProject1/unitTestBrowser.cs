using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using Microsoft.VisualBasic;

namespace UnitTestProject1
{
    [TestClass]
    public class unitTestBrowser
    {
        // Property
        public String webSiteTitle { get; set; }

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

        // Browser Creation
        public IWebDriver driver;

        [TestMethod]
        public void TestMethod1()
        {
            try
            {
                driver = new ChromeDriver();
                var myInteraction = new unitTestWebPageInteraction();
                String webSite = "https://www.facebook.com/";
                String firstNameStr = "Miriam";
                String lastNameStr = "Ramirez";
                String phoneNumberStr = "0123456789";
                String passwordStr = "myPasswordE2";
                String monthValueStr = "12";
                String dayValueStr = "31";
                String yearValueStr = "2000";
                String textExpected = "It’s quick and easy.";
                // Go to facebook.com
                gotoWebSite(webSite);
                // Validate driver title
                waitWebElement(byTagNWebSiteTitle, "");
                webSiteTitle = getWebSiteTitle();
                myInteraction.validatePageTitle(driver, webSiteTitle);
                // Fill all Sign Up section
                waitWebElement(byCssCreateNewAccountBtn, "ElementToBeClickable");
                clickAction(byCssCreateNewAccountBtn);
                waitWebElement(byCssFirstNameInput, "elementToBePresent");
                sendKeysAction(byCssFirstNameInput, firstNameStr);
                myInteraction.filledInformation(firstNameStr, "First Name");
                waitWebElement(byCssLastNameInput, "elementToBePresent");
                sendKeysAction(byCssLastNameInput, lastNameStr);
                myInteraction.filledInformation(lastNameStr, "Last Name");                
                waitWebElement(byCssPhoneNumberInput, "elementToBePresent");
                sendKeysAction(byCssPhoneNumberInput, phoneNumberStr);
                myInteraction.filledInformation(phoneNumberStr, "Phone Number");
                waitWebElement(byCssPasswordInput, "elementToBePresent");
                sendKeysAction(byCssPasswordInput, passwordStr);
                myInteraction.filledInformation(passwordStr, "Password");
                // Choose a different Birthday not the default one
                waitWebElement(byCssMonthSel, "ElementToBeClickable");
                fillBirthday(byCssMonthSel, monthValueStr); 
                waitWebElement(byCssDaySel, "ElementToBeClickable");
                fillBirthday(byCssDaySel, dayValueStr);
                waitWebElement(byCssYearSel, "ElementToBeClickable");
                fillBirthday(byCssYearSel, yearValueStr);
                // Click on Female
                waitWebElement(byCssGenderOpt, "ElementToBeSelected");
                clickAction(byCssGenderOpt, true);
                // Validate text is present
                myInteraction.validateText(driver.FindElement(textDisplayed).Text.ToString(), textExpected);

                closeAll();
            }
            catch (unitTestCustomException ex)
            {
                Console.WriteLine("Custom Exception Message. Error = {0}.", ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: {0}", ex.Message);
            }
        }

        // Element Interaction
        public void gotoWebSite(String webSite)
        {
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(webSite);
        }
        public void waitWebElement(By byElement, String condition)
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

        public String getWebSiteTitle()        
        {   
                return driver.Title;
        }

        public void clickAction(By ByElement)
        {
            driver.FindElement(ByElement).Click();  
        }
        public void clickAction(By ByElement, Boolean logAction)
        {
            driver.FindElement(ByElement).Click();
            Console.WriteLine("Female option was selected"); 
        }

        public void sendKeysAction(By ByElement, String strValue)
        {
            driver.FindElement(ByElement).SendKeys(strValue);

        }

        public void fillBirthday(By ByElement, String value)
        {
            var myDropDown = new SelectElement(driver.FindElement(ByElement));
            myDropDown.SelectByValue(value);
        }
        public void closeAll()
        {
            driver.Close();
        }
    }
}