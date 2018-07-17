using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections.Generic;
using NUnit.Framework;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;



namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupCreationTests : AuthTestBase

    { 
        [Test]
        public void GroupCreationTest()
        {
            

            GroupData newData = new GroupData("f");
            newData.Footer = "f";
            newData.Header = "f";
           
            List<GroupData> oldGroups = app.Groups.GetGroupList();
            

            app.Groups.Create(newData);
            //app.Navigator.ReturnToGroupPage();

            //метод для проверки того, что добавились группы. List<GroupData> - список объектов типа GroupData
            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups.Add(newData);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
        }
        

        [Test]
        public void EmptyGroupCreationTest()//проверка создания группы с пустыми именами
        {
            GroupData newData = new GroupData("");
            newData.Footer = "";
            newData.Header = "";

            List<GroupData> oldGroups = app.Groups.GetGroupList();

            app.Groups.Create(newData);
            //app.Navigator.ReturnToGroupPage();

            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups.Add(newData);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
        }
        [Test]
        public void BadNameGroupCreationTest()//проверка создания группы с пустыми именами
        {
            GroupData newData = new GroupData("a'a");
            newData.Footer = "";
            newData.Header = "";

            List<GroupData> oldGroups = app.Groups.GetGroupList();

            app.Groups.Create(newData);
            //app.Navigator.ReturnToGroupPage();

            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups.Add(newData);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
        }
    }
}

