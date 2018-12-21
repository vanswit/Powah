using Microsoft.VisualStudio.TestTools.UnitTesting;
using Powah.BO;
using Powah.Data;
using System;
using System.IO;

namespace Powah.Test
{
    [TestClass]
    public class PowahTest
    {
        [TestMethod]
        public void TestSaveUserSettings()
        {
            //arrange
            PowahUser user = new PowahUser("tom", 36, 90, 200, 135, 160);
            //act
            PowahUserDA.SaveToSettings(user);
            //assert
            string userName = Plugin.Settings.CrossSettings.Current.GetValueOrDefault("UserName", "", "PowahSettings");
            int age = Plugin.Settings.CrossSettings.Current.GetValueOrDefault("Age", 0, "PowahSettings");
            int weigth = Plugin.Settings.CrossSettings.Current.GetValueOrDefault("Weigth", 0, "PowahSettings");
            int maxDeadlift = Plugin.Settings.CrossSettings.Current.GetValueOrDefault("DeadliftMax", 0, "PowahSettings");
            int maxBench = Plugin.Settings.CrossSettings.Current.GetValueOrDefault("FlatBenchMax", 0, "PowahSettings");
            int maxSquat = Plugin.Settings.CrossSettings.Current.GetValueOrDefault("SquatMax", 0, "PowahSettings");

            PowahUser userFromSettings = new PowahUser(userName,age,weigth,maxDeadlift,maxBench,maxSquat);

            Assert.AreEqual(user.UserName,userFromSettings.UserName);
            Assert.AreEqual(user.FlatBenchMax,userFromSettings.FlatBenchMax);
        }
        [TestMethod]
        public void TestResourceAccess()
        {
            

            OneRepMaxes oneRM = new OneRepMaxes()
            {
                Excercise = "Squat",
                Weight = 160
            };

            var connection = new SQLite.SQLiteConnection(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "PowahDB.db"));

            var id = connection.Insert(oneRM);
        }
    }
}
