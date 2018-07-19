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
        public ContactHelper CheckContactExistance()
        {
            if (IsElementPresent())
            {

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

        public int GetContactCount()
        {
            return driver.FindElements(By.XPath("//table/tbody/tr[contains(@name, 'entry')]")).Count;
        }

        private List<ContactData> contactsCashe = null;


        public List<ContactData> GetContactList()
        {
            if (contactsCashe == null) //если кэш еще не заполнен то заполняем его
            {
                contactsCashe = new List<ContactData>();



                ICollection<IWebElement> elements = driver.FindElements(By.XPath("//table/tbody/tr[contains(@name, 'entry')]"));
                
                foreach (IWebElement element in elements)
                {
                    contactsCashe.Add(new ContactData(element.Text) 
                    {
                        Id = element.FindElement(By.TagName("input")).GetAttribute("value"),
                        Firstname = element.FindElement(By.XPath("//*[@id='content']//*[contains(@name, 'entry')]/td[2]")).GetAttribute("innerHTML"),
                        Lastname = element.FindElement(By.XPath("//*[@id='content']//*[contains(@name, 'entry')]/td[3]")).GetAttribute("innerHTML")
                    });
                    
                } 
        }
            return new List<ContactData>(contactsCashe);

            }


            //List<ContactData> contacts = new List<ContactData>();
            
            //ReadOnlyCollection <IWebElement> lastName = driver.FindElements(By.XPath("//*[@id='content']//*[contains(@name, 'entry')]/td[2]"));
            //int lastNames = lastName.Count;
            //ReadOnlyCollection <IWebElement> firstName = driver.FindElements(By.XPath("//*[@id='content']//*[contains(@name, 'entry')]/td[3]"));

           // for (int i=0; i <= lastNames - 1; i++)
            //{

            //    ContactData contact = new ContactData(firstName[i].Text);
            //    contact.Lastname = lastName[i].Text;
            //    contacts.Add(contact);

           // }
          //  return contacts;
           //  


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
            contactsCashe = null;
            return this;
        }

        public ContactHelper InitContactModification(int p)
        {
           
         driver.FindElement(By.XPath("(//img[@alt='Edit'])[" + (p+1) + "]")).Click();
            
         
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
            contactsCashe = null;
            return this;
        }
        public ContactHelper SelectContact(int p)
        { 
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + (p+1) + "]")).Click();
            return this;
        }

        

        public ContactHelper SubmitContactCreation()
        {
            driver.FindElement(By.XPath("//*[@id='content']//*[@name='submit'][2]")).Click();
            contactsCashe = null;
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

