using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DownWithTheSickness_Dialog_Tool;
using System.Collections.Generic;

namespace DWTS_Dialog_Test
{
    [TestClass]
    public class Dialog_Database_Handler_test
    {
        private static string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        private static string dbDirPath = Path.Combine(appDataPath, "DownWithTheSickness");
        private static string dbName = "DownWithTheSickness.accdb";
        private static string dbPath = Path.Combine(dbDirPath, dbName);


        [TestMethod]
        public void TestCreateDatabase()
        {
            Dialog_Database_Handler ddh = new Dialog_Database_Handler();
            Assert.IsTrue(File.Exists(dbPath));
        }

        [TestMethod]
        public void TestDDHAddScene()
        {
            Dialog_Database_Handler ddh = new Dialog_Database_Handler();
            Scene s1 = new Scene();
            s1.name = "At Home";
            s1.dialogs = new List<Dialog>();
            Dialog d = new Dialog
            {
                speaker = new Character { name = "Müller", forename = "Blah" },
                addressed_to = new List<Character> { new Character() { name = "Doe", forename = "Felix" },
                                                     new Character() { name = "Doe", forename = "Chappy" }},
                dialog_text = "Wuff Wuff",
                dialog_number = 1 
            };
            s1.dialogs.Add(d);

            ddh.addScene(s1);
            //ddh.deleteScene(s1);

            s1.name = "At Granny";
            s1.dialogs = new List<Dialog>();
            d = new Dialog
            {
                speaker = new Character { name = "Skinner", forename = "Walter" },
                addressed_to = new List<Character> { new Character() { name = "Mulder", forename = "Fox" },
                                                     new Character() { name = "Scully", forename = "Dana" }},
                dialog_text = "I want to believe.",
                dialog_number = 1

            };
            s1.dialogs.Add(d);
            ddh.addScene(s1);
            //ddh.deleteScene(s1);
        }

        [TestMethod]
        public void TestGetAllScenes()
        {
            Dialog_Database_Handler ddh = new Dialog_Database_Handler();
            List<Scene> scenes = ddh.getAllScenes();
        }

    }
}
