using System.Collections;
using System.Collections.ObjectModel;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace AutomationTask.PageObjects
{
    public class HomePage
    {
        private readonly IWebDriver _driver;

        public HomePage(IWebDriver driver)
        {
            _driver = driver;
        }

        public void NavigateToHomePage()
        {
            _driver.Navigate().GoToUrl("https://cms.demo.katalon.com/");
            _driver.Manage().Window.Maximize();
            Thread.Sleep(3000);
        }

        public void AddRandomItemsToCart(int count)
        {
            
            
            ReadOnlyCollection<IWebElement> ele = _driver.FindElements(By.XPath("//ul[contains(@class,'products columns-3')]//li//div//a[2]"));

            foreach (IWebElement i in ele)
            {
                
                Actions action = new Actions(_driver);
                action.MoveToElement(i).Perform();
                Thread.Sleep(3000);
                i.Click();
                count = count - 1;
                if (count == 0) break;
                
            }
            
        }
    }
}