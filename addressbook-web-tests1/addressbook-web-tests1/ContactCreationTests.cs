using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;


namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactCreationTests : TestBase
    {
        [Test]
        public void ContactCretion()
        {
            OpenHomePage();
            Login(new AccountData("admin","secret"));
            CreationContact();
            ContactData contact = new ContactData ("1");
            contact.Middlename ="f1";
            contact.Lastname ="f1";
            contact.Nickname ="f1";
            InputContactForm(contact);
            SubmitContactCreation(); 
            Logout();
        }
    }
}
