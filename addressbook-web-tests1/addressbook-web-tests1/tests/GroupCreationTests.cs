using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupCreationTests : AuthTestBase
    { 
        [Test]
        public void GroupCreationTest()
        {
            GroupData newData = new GroupData("f");
            newData.Footer = "f";
            newData.Header = "f";
           
            app.Groups.Create(newData);
            //app.Navigator.ReturnToGroupPage();
            
        }

        [Test]
        public void EmptyGroupCreationTest()//проверка создания группы с пустыми именами
        {
            GroupData newData = new GroupData("");
            newData.Footer = "";
            newData.Header = "";

            app.Groups.Create(newData);
            //app.Navigator.ReturnToGroupPage();
           

        }
    }
}

