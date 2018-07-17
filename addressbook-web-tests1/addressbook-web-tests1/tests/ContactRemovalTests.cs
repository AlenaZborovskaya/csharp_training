using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    class ContactRemovaltests : AuthTestBase
    {
        [Test]
        public void ContactRemovaltest()
        {
            app.Navigator.OpenHomePage();
            app.Contacts.CheckContactExistance(1);

            //List<ContactData> oldContacts = app.Contacts.GetContactList();

            //app.Contacts.RemoveContact(0);

            //List<ContactData> newContacts = app.Contacts.GetContactList();
            //oldContacts.RemoveAt(0);
            //Assert.AreEqual(oldContacts, newContacts);

        }
    }
}
      
