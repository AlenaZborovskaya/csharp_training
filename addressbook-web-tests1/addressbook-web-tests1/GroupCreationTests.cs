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
        OpenHomePage();
        Login(new AccountData("admin", "secret"));
        GoToGroupCreationAndInitNewGroup();
        GroupData group = new GroupData("f");
        group.Footer = "f";
        group.Header = "f";
        FillGroupForm(group);
        SubmitGroupCreation();
        ReturnToGrupPage();
        }
    }

}

