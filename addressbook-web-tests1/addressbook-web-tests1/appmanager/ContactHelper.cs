using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;


namespace WebAddressbookTests
{
    public class ContactHelper : HelperBase
    {
        private bool acceptNextAlert;

        public ContactHelper(ApplicationManager manager) // конструктор для driver, IWebDriver - параметр
 : base(manager)// обращаемся к конструктору base, в качестве параметра driver (когда создали HelperBase)

        {
        }


        public ContactHelper Create(ContactData contact)
        {
            CreationContact();
            InputContactForm(contact);
            SubmitContactCreation();
            manager.Navigator.ReturnToHomePage();
            return this;
        }

        public ContactHelper Modifycontact(int p, ContactData newContact)
        {
            SelectContact(p);
            InitContactModification(p);     
            InputContactForm(newContact);
            SubmitContactModification();
            manager.Navigator.ReturnToHomePage();
            return this;
        }

        public ContactHelper SubmitContactModification()
        {
            driver.FindElement(By.Name("update")).Click();
            return this;
        }

        public ContactHelper InitContactModification(int p)
        {
           
         driver.FindElement(By.XPath("(//img[@alt='Edit'])[" + p + "]")).Click();
            
         //driver.FindElement(By.XPath("(//img[@alt='Edit'])[3]")).Click();
            return this;
        }

        public bool IsContactPresent()
        {
            
            return IsContactPresent(By.Name("selected[]"));
        }

        public ContactHelper RemoveContact(int p)
        {
            SelectContact(p);
            DeleteContact();
            CloseAlert();
            return this;
        }
        public ContactHelper DeleteContact()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            //Assert.IsTrue(System.Text.RegularExpressions.Regex.IsMatch(CloseAlertAndGetItsText(), "^Delete 1 addresses[\\s\\S]$"));
            return this;
        }
        public ContactHelper SelectContact(int p)
        {
        if (IsContactPresent())
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + p + "]")).Click();
        }
            else
            {
                ContactData contact = new ContactData("2");
                contact.Middlename = "new";
                contact.Lastname = "new";
                contact.Nickname = "new";

                manager.Contacts.Create(contact);
                if (IsContactPresent())
                {
                    driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + p + "]")).Click();
                }
            }

            return this;
        }

        

        public ContactHelper SubmitContactCreation()
        {
            driver.FindElement(By.XPath("//*[@id='content']//*[@name='submit'][2]")).Click();
            return this;

        }
        public ContactHelper InputContactForm(ContactData contact)
        {
            Type(By.Name("firstname"), contact.Firstname);
            Type(By.Name("middlename"), contact.Middlename);
            Type(By.Name("lastname"), contact.Lastname);
            Type(By.Name("nickname"), contact.Nickname);
            return this;
        }
        public ContactHelper CreationContact()
        {
            driver.FindElement(By.LinkText("add new")).Click();
            return this;
        }

        public ContactHelper CloseAlert()
        {
            driver.SwitchTo().Alert().Accept();
            return this;
        }
    }
}

