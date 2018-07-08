﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;


namespace WebAddressbookTests
{
    public class ContactHelper : HelperBase
    {
        public ContactHelper(ApplicationManager manager) // конструктор для driver, IWebDriver - параметр
 : base(manager)// обращаемся к конструктору base, в качестве параметра driver (когда создали HelperBase)

        {
        }

        public ContactHelper Create(ContactData contact)
        {
            CreationContact();
            InputContactForm(contact);
            SubmitContactCreation();
            return this;
        }

        public ContactHelper SubmitContactCreation()
        {
            driver.FindElement(By.XPath("//*[@id='content']//*[@name='submit'][2]")).Click();
            return this;

        }
        public ContactHelper InputContactForm(ContactData contact)
        {
            driver.FindElement(By.Name("firstname")).Clear();
            driver.FindElement(By.Name("firstname")).SendKeys(contact.Firstname);
            driver.FindElement(By.Name("middlename")).Clear();
            driver.FindElement(By.Name("middlename")).SendKeys(contact.Middlename);
            driver.FindElement(By.Name("lastname")).Clear();
            driver.FindElement(By.Name("lastname")).SendKeys(contact.Lastname);
            driver.FindElement(By.Name("nickname")).Clear();
            driver.FindElement(By.Name("nickname")).SendKeys(contact.Nickname);
            return this;
        }
        public ContactHelper CreationContact()
        {
            driver.FindElement(By.LinkText("add new")).Click();
            return this;
        }
 
    }
}
