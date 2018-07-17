﻿using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections.Generic;
using NUnit.Framework;


namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupRemovalTests : AuthTestBase
    {
        [Test]
        public void GroupRemovalTest()
        {
            app.Navigator.GoToGroupPage();
            app.Groups.CheckGroupExistance(1);

            //List<GroupData> oldGroups = app.Groups.GetGroupList();

            app.Groups.Remove(1);

            //List<GroupData> newGroups = app.Groups.GetGroupList();
            //oldGroups.RemoveAt(0);
            //Assert.AreEqual(oldGroups, newGroups);

        }
    }
}



