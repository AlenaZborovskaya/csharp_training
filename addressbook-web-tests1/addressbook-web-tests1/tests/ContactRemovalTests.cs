using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    class ContactRemovaltests : TestBase
    {
        [Test]
        public void ContactRemovaltest()
        {
            app.Contacts.RemoveContact();

        }
    }
}
      
