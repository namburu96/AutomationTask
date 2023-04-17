using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using AutomationTask.PageObjects;
using TechTalk.SpecFlow;

namespace AutomationTask.StepDefinitions
{
    [Binding]
    public class Steps
    {
        private readonly IWebDriver driver;
        private readonly HomePage homePage;
        private readonly CartPage cartPage;
     
        public Steps()
        {
            driver = new ChromeDriver();
            homePage = new HomePage(driver);
            cartPage = new CartPage(driver);
        }

        [Given(@"I am on the home page")]
        public void GivenIAmOnTheHomePage()
        {
            homePage.NavigateToHomePage();
        }

        [When(@"I add four random items to my cart")]
        public void WhenIAddFourRandomItemsToMyCart()
        {
            homePage.AddRandomItemsToCart(4);
        }

        [Then(@"I see four items listed in my cart")]
        public void ThenISeeFourItemsListedInMyCart()
        {
            cartPage.ViewMycart();
        }

    
        [When(@"I search for the lowest priced item")]
        public IWebElement WhenISearchForTheLowestPricedItem()
        {
            IWebElement lowestPricedItem=cartPage.SearchLowestPricedItem();
            return lowestPricedItem;
        }

        [When(@"I remove the lowest priced item from my cart")]
        public void WhenIRemoveTheLowestPricedItemFromMyCart()
        {
            IWebElement lowestPricedItem = WhenISearchForTheLowestPricedItem();
            cartPage.RemoveLowestPricedItem(lowestPricedItem);
        }

        [Then(@"I see three items listed in my cart")]
        public void ThenISeeThreeItemsListedInMyCart()
        {
            cartPage.ViewMycart();
            driver.Close();
        }
    }
}