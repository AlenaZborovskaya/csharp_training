using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;


namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactCreationTests : AuthTestBase
    {
        [Test]
        public void ContactCretion()
        {
           
            ContactData contact = new ContactData ("1");
            contact.Middlename ="f1";
            contact.Lastname ="f1";
            contact.Nickname ="f1";
            app.Contacts.Create(contact);
            app.Auth.Logout();
        }
    }
}
