using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactModificationTests : AuthTestBase
    {
        [Test]
        public void ContactModificationTest()
        {
            app.Navigator.OpenHomePage();
            app.Contacts.CheckContactExistance(0);

            ContactData newContact = new ContactData("2");
            newContact.Middlename = "new3";
            newContact.Lastname = "new3";
            newContact.Nickname = "new3";

            List<ContactData> oldContacts = app.Contacts.GetContactList();

            app.Contacts.Modifycontact(0, newContact);

            List<ContactData> newContacts = app.Contacts.GetContactList();
            oldContacts[0].Firstname = newContact.Firstname;
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}
