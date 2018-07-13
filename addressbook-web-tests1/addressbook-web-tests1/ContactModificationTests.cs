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
            ContactData newContact = new ContactData("2");
            newContact.Middlename = "new3";
            newContact.Lastname = "new3";
            newContact.Nickname = "new3";

            app.Contacts.Modifycontact(1, newContact);

        }
    }
}
