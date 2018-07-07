using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;


namespace WebAddressbookTests
{
    public class HelperBase
    {
        protected IWebDriver driver; //перенесли ссылку на драйвер, сделали ее protected

        public HelperBase (IWebDriver driver) //делаем конструктор 
        {
            this.driver = driver; //на вход принимает ссылку на браузер которым мы управляем драйвером и присваивает ее поле
            
        }

    } 
}
