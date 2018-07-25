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
        public static IEnumerable<GroupData> RandomGroupDataProvider()
        {
            List<GroupData> groups = new List<GroupData>();
            for (int i =0; i<5; i++)
            {
                groups.Add(new GroupData(GenerateRandomString(30))
                {
                    Header = GenerateRandomString(100), Footer = GenerateRandomString(100)
                });
                    
            }
            return groups;
        }

        public static IEnumerable<GroupData> GroupDataFromFile()
        {
            List<GroupData> groups = new List<GroupData>();
            return groups;
        }



        [Test, TestCaseSource("RandomGroupDataProvider")]

        public void GroupCreationTest(GroupData newData)
        {
            

           
            List<GroupData> oldGroups = app.Groups.GetGroupList();
            

            app.Groups.Create(newData);

            //метод который быстро возвращает количество групп перед сравнением списков
            
            Assert.AreEqual(oldGroups.Count + 1, app.Groups.GetGroupCount());

            //метод для проверки того, что добавились группы. List<GroupData> - список объектов типа GroupData
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

            Assert.AreEqual(oldGroups.Count + 1, app.Groups.GetGroupCount());

            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups.Add(newData);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
        }
    }
}

