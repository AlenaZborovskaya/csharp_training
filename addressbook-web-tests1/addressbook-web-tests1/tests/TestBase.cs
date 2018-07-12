using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;


//Создает ApplicationManager и останавливает  его - перенесли в TestSuiteFixture

//после создания loginHelper добавляем в метод SetUp, где создается driver, добавляем код который будет создавать помощников
// после этого, Login подчеркнут красным - поля Login еще нет, его необходимо сделать
// далее в тестах меняем login на loginHelper
namespace WebAddressbookTests
{
    public class TestBase
    {
        protected ApplicationManager app;
        

        [SetUp]
        public void SetupApplicationManager() //метод для инициализации: драйвера, помощников
        {
            //app = new ApplicationManager();//конструируем менеджер, создается ссылка на applicationmanager

            app = ApplicationManager.GetInstance(); // будет инициализироваться заранее тестовым фрейморком, а 
           
        }
    }
}

