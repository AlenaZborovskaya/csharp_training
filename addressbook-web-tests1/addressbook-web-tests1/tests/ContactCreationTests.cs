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
            app.Navigator.OpenHomePage();
            app.Auth.Login(new AccountData("admin","secret"));
            app.Contacts.CreationContact();
            ContactData contact = new ContactData ("1");
            contact.Middlename ="f1";
            contact.Lastname ="f1";
            contact.Nickname ="f1";
            app.Contacts.InputContactForm(contact);
            app.Contacts.SubmitContactCreation(); 
            app.Auth.Logout();
        }
    }
}
