using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using OpenQA.Selenium;

namespace UnitTestProject1
{
    [TestClass]
    public class Tests
    {
        private IWebDriver driver;
        [TestInitialize]
        public void Setup()
        {
            var MySetUp = new SetUp();
            driver = MySetUp.SetUpMethod();
            driver.Manage().Window.Maximize();
        }
        
        [TestMethod]
        public void TestMethod1()
        {
            try
            {
                var FBTest = new WebPageInteraction();
                // Go to facebook.com
                FBTest.gotoWebSite(driver);
                // Validate the title of the page 
                FBTest.validatePageTitle(driver);
                // Fill all Sign Up section and print the information that you are filling
                FBTest.FillInformation(driver);
                // Choose a different Birthday not the default one
                FBTest.ChooseDifferentBD(driver);
                // Click on Female. Create your custome click method that contains the logger 
                FBTest.ClickOnFemale(driver);
                // Validate text is present. Create a custom Assert Method to print a sucessful message
                FBTest.ValidateTextIsPresent(driver);
                
                closeAll();
            }
            catch (CustomException ex)
            {
                Console.WriteLine("Custom Exception Message. Error = {0}.", ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: {0}", ex.Message);
            }
        }

        [TestCleanup]
        public void closeAll()
        {
            try
            {
                driver.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: {0}", ex.Message);
            }
        }
    }
}