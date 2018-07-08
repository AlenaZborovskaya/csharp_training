using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactModificationTests : TestBase
    {
        [Test]
        public void ContactModificationTest()
        {
            ContactData newContact = new ContactData("1");
            newContact.Middlename = "f1";
            newContact.Lastname = "f1";
            newContact.Nickname = "f1";

            app.Contacts.Modifycontact(1, newContact);

        }
    }
}
