﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

// 1. объявляем все классы public
// 2. так как код не компилируется: первое, добавляем конструкции using (испортируем классы из другого пространства имен -селениум)
// второе, исправляем ссылку на driver, создаем для него конструктор
// далее в TestBase используем место перенеенного метода помощник

namespace WebAddressbookTests
{
    public class LoginHelper : HelperBase
    {
        public LoginHelper(ApplicationManager manager) // конструктор для driver, IWebDriver - параметр
        : base(manager)// обращаемся к конструктору base, в качестве параметра driver (когда создали HelperBase)

        {
        }    
        public void Login(AccountData account)
        {
            driver.FindElement(By.Name("user")).Clear();
            driver.FindElement(By.Name("user")).SendKeys(account.Username);
            driver.FindElement(By.Name("pass")).Clear();
            driver.FindElement(By.Name("pass")).SendKeys(account.Password);
            driver.FindElement(By.CssSelector("input[type=\"submit\"]")).Click();
        }
        public void ReturnToGrupPage()
        {
            driver.FindElement(By.LinkText("Logout")).Click();
        }
        public void Logout()
        {
            driver.FindElement(By.LinkText("Logout")).Click();
        }

    }
}
