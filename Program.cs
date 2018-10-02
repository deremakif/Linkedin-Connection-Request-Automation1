using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace Linkedin
{
    class Program
    {
        static void Main(string[] args)
        {
            IWebDriver driver = new FirefoxDriver();
            driver.Navigate().GoToUrl("https://www.linkedin.com/");
            // Waiting user to logging in.
            System.Threading.Thread.Sleep(100000);

            // Finds user's network page.
            IWebElement me = driver.FindElement(By.XPath("//*[@id='mynetwork-tab-icon']"));
            me.Click();

            System.Threading.Thread.Sleep(5000);

            IJavaScriptExecutor js = driver as IJavaScriptExecutor;

            //In free LinkedIn network, users have just 30 thousand connections.
            for (int j = 0; j < 30000; j++)
            {
                //Please check xpaths before running this program! LinkedIn may have changed.
                IWebElement connect = driver.FindElement(By.XPath("/html/body/div[5]/div[5]/div[2]/div/div/div/div/div/div/div/section/artdeco-tabs/artdeco-tabpanel[1]/ul/li[1]/div/section/footer"));
                connect.Click();
                
                // To load more suggestions, page should be scrolled down.
                js.ExecuteScript("window.scrollBy(0,500000);");
                System.Threading.Thread.Sleep(2000);
                js.ExecuteScript("window.scrollBy(0,50);");
                System.Threading.Thread.Sleep(1000);
            }
        }
    }
}
