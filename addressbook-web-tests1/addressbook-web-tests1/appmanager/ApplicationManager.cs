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
    public class ApplicationManager
    {
        //перенесли также из TestBase, так как в тестах не используется, драйвер только запускает и выключает браузер
        protected IWebDriver driver;
        private StringBuilder verificationErrors;
        protected string baseURL;

        //скопировали ссылки на помощников из TestBase
        protected LoginHelper loginHelper; //первое, делаем LoginHelper, первая l маленькая
        protected NavigationHelper navigationHelper;
        protected GroupHelper groupHelper;
        protected ContactHelper contactHelper;

        //иницилизируем помощников в конструкторе
        public ApplicationManager()
        {
        FirefoxOptions options = new FirefoxOptions();
        options.BrowserExecutableLocation = @"c:\Program Files\Mozilla Firefox\firefox.exe";
        options.UseLegacyImplementation = true;
        driver = new FirefoxDriver(options);

        baseURL = "http://localhost/";
       


        loginHelper = new LoginHelper(driver); //добавляем код который будет создавать помощников, в качестве параметра - driver, первая l маленькая
        navigationHelper = new NavigationHelper(driver, baseURL);
        groupHelper = new GroupHelper(driver);
        contactHelper = new ContactHelper(driver);
        }

        //Создаем метод для стопа драйвера (который мы перенесем из TestBase) чтобы остановить все в менеджере

            public void Stop()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
        }

        public LoginHelper Auth
        {
            get
            {
                return loginHelper;
            }
        }
        public NavigationHelper Navigator
        {
            get
            {
                return navigationHelper;
            }
        }
        public GroupHelper Groups
        {
            get
            {
                return groupHelper;
            }
        }
        public ContactHelper Contacts
        {
            get
            {
                return contactHelper;
            }
        }
    }
}
