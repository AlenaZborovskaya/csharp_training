using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupCreationTests : TestBase
    { 
        [Test]
        public void GroupCreationTest()
        {
            GroupData group = new GroupData("f");
            group.Footer = "f";
            group.Header = "f";
           
            app.Groups.Create(group);
            app.Auth.ReturnToGrupPage();
        }

        [Test]
        public void EmptyGroupCreationTest()//проверка создания группы с пустыми именами
        {
            GroupData group = new GroupData("");
            group.Footer = "";
            group.Header = "";
            app.Groups.Create(group);
            app.Auth.ReturnToGrupPage();
        }
    }
}

