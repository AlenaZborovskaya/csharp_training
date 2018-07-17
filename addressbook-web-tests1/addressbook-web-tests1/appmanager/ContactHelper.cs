using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System.Collections.ObjectModel;

namespace WebAddressbookTests
{
    public class ContactHelper : HelperBase
    {
        //private bool acceptNextAlert;

        public ContactHelper(ApplicationManager manager) // конструктор для driver, IWebDriver - параметр
 : base(manager)// обращаемся к конструктору base, в качестве параметра driver (когда создали HelperBase)

        {
        }
        public ContactHelper CheckContactExistance(int p)
        {
            if (IsElementPresent())
            {
                SelectContact(p);
            }
            else
            {
                ContactData contact = new ContactData("2");
                contact.Middlename = "new";
                contact.Lastname = "new";
                contact.Nickname = "new";

                Create(contact);
                
            }
            return this;
        }

        public List<ContactData> GetContactList()
        {
            List<ContactData> contacts = new List<ContactData>();
            List<ContactData> contacts1 = new List<ContactData>();

            //manager.Navigator.OpenHomePage();
            ReadOnlyCollection <IWebElement> lastName = driver.FindElements(By.XPath("//*[@id='content']//*[contains(@name, 'entry')]/td[2]"));
            int lastNames = lastName.Count;
            ReadOnlyCollection <IWebElement> firstName = driver.FindElements(By.XPath("//*[@id='content']//*[contains(@name, 'entry')]/td[3]"));

            for (int i=0; i <= lastNames - 1; i++)
            {

                ContactData contact = new ContactData(firstName[i].Text);
                contact.Lastname = lastName[i].Text;
                contacts.Add(contact);

            }
            return contacts;
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
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + p + "]")).Click();
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
        public bool IsElementPresent()
        {
            return IsElementPresent(By.Name("selected[]"));
        }
    }
}

