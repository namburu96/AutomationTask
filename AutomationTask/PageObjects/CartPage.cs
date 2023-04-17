using OpenQA.Selenium;

namespace AutomationTask.PageObjects
{
    public class CartPage
    {
        private readonly IWebDriver _driver;

        public CartPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public void ViewMycart()
        {
            Thread.Sleep(3000);
            _driver.FindElement(By.XPath("//a[normalize-space()='Cart']")).Click();
            
        }

        public int GetItemCount()
        {
            var itemCount = _driver.FindElements(By.CssSelector(".woocommerce-cart-form__cart-item.cart_item")).Count;
            return itemCount;
        }


        public IWebElement SearchLowestPricedItem()
        {
            var items = _driver.FindElements(By.CssSelector(".woocommerce-cart-form__cart-item.cart_item"));
            var LowestPrice = double.MaxValue;
            IWebElement LowestPricedItem = null;

            foreach (var item in items)
            {
                var price = double.Parse(item
                    .FindElement(By.CssSelector(".product-price .woocommerce-Price-amount.amount")).Text
                    .Replace("$", ""));
                if (price < LowestPrice)
                {
                    LowestPrice = price;
                    LowestPricedItem = item;
                }
            }

            return LowestPricedItem;

        }

        public void RemoveLowestPricedItem(IWebElement LowestPriced)
        {
            IWebElement LowestPricedItem = LowestPriced;

            if (LowestPricedItem != null)
            {
                LowestPricedItem.FindElement(By.CssSelector(".product-remove .remove")).Click();
            }
        }
    }
}