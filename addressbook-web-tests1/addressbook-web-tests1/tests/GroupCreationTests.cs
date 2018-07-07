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
        app.Navigator.OpenHomePage();
        app.Auth.Login(new AccountData("admin", "secret"));
        app.Navigator.GoToGroupsPage();
        app.Groups.InitNewGroup();
        GroupData group = new GroupData("f");
        group.Footer = "f";
        group.Header = "f";
        app.Groups.FillGroupForm(group);
        app.Groups.SubmitGroupCreation();
        app.Auth.ReturnToGrupPage();
        }
    }
}

