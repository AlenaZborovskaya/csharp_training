using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;


//Создает ApplicationManager и сотанавливает его

//после создания loginHelper добавляем в метод SetUp, где создается driver, добавляем код который будет создавать помощников
// после этого, Login подчеркнут красным - поля Login еще нет, его необходимо сделать
// далее в тестах меняем login на loginHelper
namespace WebAddressbookTests
{
    public class TestBase
    {
        protected ApplicationManager app;

        [SetUp]
        public void SetupTest() //метод для инициализации: драйвера, помощников
        {
            app = new ApplicationManager();//инициализируем application manager
        }

        [TearDown]
        public void TeardownTest() //метод, который останавливает драйверы в конце
        {
            app.Stop(); //вызываем метод стоп из ApplicationManager
        }



      
        
    }
}

