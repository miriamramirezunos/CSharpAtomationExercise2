using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;


namespace UnitTestProject1
{
    class unitTestWebPageInteraction
    {
        public void validatePageTitle(IWebDriver driver, String strExpected)
        {
            Assert.AreEqual(driver.Title.ToString(), strExpected); 
        }

        public void filledInformation(String strValue, String whatElement)
        {
            Console.WriteLine("Filled Field: {0} with value: \"{1}\"", whatElement, strValue);
        }

        public void validateText(String actualStr, String expectedStr)
        {
            if (actualStr.Trim() == expectedStr.Trim())
            {
                Console.WriteLine($"Custom Assert. Successful Assert! The text \"{actualStr}\" is equal to \"{expectedStr}\"");
            }
            else
            {
                throw new unitTestCustomException($"Custom Exception Message. Custom Assert. Failed Assert: The text \"{actualStr}\" is different compared with \"{expectedStr}\"");
            }
        }

}
}
