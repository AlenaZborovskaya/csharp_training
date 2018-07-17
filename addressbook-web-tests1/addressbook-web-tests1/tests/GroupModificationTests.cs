using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
   public  class GroupModificationTests : AuthTestBase
    {
        [Test]
        public void GroupModificationTest()
        {
            app.Navigator.GoToGroupPage();
            app.Groups.CheckGroupExistance(0);

            List<GroupData> oldGroups = app.Groups.GetGroupList();

            GroupData newData = new GroupData("zzz");
            newData.Footer = null; //если укажем null то с полем не выполняется никаких действий: не очистки ни заполнения
            newData.Header = null;

            app.Groups.Modify(0, newData);
            app.Navigator.ReturnToGroupPage();

           List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups[0].Name = newData.Name;
            oldGroups.Sort();
            newGroups.Sort();
           Assert.AreEqual(oldGroups, newGroups);

        }

    }
}
