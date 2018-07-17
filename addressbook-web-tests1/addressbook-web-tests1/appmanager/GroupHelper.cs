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
    public class GroupHelper : HelperBase
    {



        public GroupHelper(ApplicationManager manager) // конструктор для driver, IWebDriver - параметр
         : base(manager)// обращаемся к конструктору base, в качестве параметра driver (когда создали HelperBase)

        {
        }

        public GroupHelper CheckGroupExistance(int p)
        {
            if (IsElementPresent())
            {
                SelectGroup(p);
            }
            else
            {
                GroupData newData = new GroupData("новая");
                newData.Footer = "новая"; 
                newData.Header = "новая";

                Create(newData);
                manager.Navigator.ReturnToGroupPage();

            }
        
            return this;
        }

        public List<GroupData> GetGroupList()
        {
            //готовим пустой список элементов типа GroupData

            List<GroupData> groups = new List<GroupData>();

            manager.Navigator.GoToGroupsPage();

            ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("span.group"));

            foreach (IWebElement element in elements)
            {
                groups.Add(new GroupData(element.Text));

            }
            return groups;
        }

        public GroupHelper Create(GroupData newData)
        {
            manager.Navigator.GoToGroupsPage();
            InitNewGroup(); //убрали app.Group так как можно не вызывать менеджер, так как методы в том же классе
            FillGroupForm(newData);
            SubmitGroupCreation();
            manager.Navigator.ReturnToGroupPage();
            return this;
        }


        public GroupHelper Modify(int p, GroupData newData)
        {
            manager.Navigator.GoToGroupsPage();
            SelectGroup(p);
            InitGroupModification();
            FillGroupForm(newData);
            SubmitGroupModification();
            manager.Navigator.ReturnToGroupPage();
            return this;
        }
        public GroupHelper Remove(int p)
        {
            manager.Navigator.GoToGroupsPage();

            SelectGroup(p);
            DeleteGroup();
            manager.Navigator.ReturnToGroupPage();
            return this;
        }


        public GroupHelper SubmitGroupModification()
        {
            driver.FindElement(By.Name("update")).Click();
            return this;
        }

        public GroupHelper InitGroupModification()
        {

            driver.FindElement(By.Name("edit")).Click();
            return this;
        }
        public GroupHelper DeleteGroup()
        {
            driver.FindElement(By.XPath("(//input[@name='delete'])[2]")).Click();
            return this;
        }



        public GroupHelper SelectGroup(int p)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + p + "]")).Click();
            return this;
        }

        public GroupHelper SubmitGroupCreation()
        {
            driver.FindElement(By.Name("submit")).Click();
            return this;
        }
        public GroupHelper FillGroupForm(GroupData group)
        {
            //driver.FindElement(By.Name("group_name")).Clear(); -заменяем на код ниже
            //driver.FindElement(By.Name("group_name")).SendKeys(group.Name); -заменяем на код ниже

            //By locator = By.Name("group_name"); - задаем локальные переменные,а затем подставляем их в метод Type
            // string text = group.Name;

            Type(By.Name("group_name"), group.Name); //поле которое определяется локатором group_name, и передает значение groupname
            Type(By.Name("group_header"), group.Header);
            Type(By.Name("group_footer"), group.Footer);
            return this;
        }


        public GroupHelper InitNewGroup() //заменили void на GroupHelper, добавили retutn this
        {

            driver.FindElement(By.XPath("(//input[@name='new'])[2]")).Click();
            return this;
        }
        public bool IsElementPresent()
        {
            return IsElementPresent(By.Name("selected[]"));
        }

    }
}


