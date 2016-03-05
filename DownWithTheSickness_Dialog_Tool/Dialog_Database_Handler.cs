using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Diagnostics;
using System.IO;

namespace DownWithTheSickness_Dialog_Tool
{
    public class Dialog_Database_Handler
    {
        private static string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        private static string dbDirPath = Path.Combine(appDataPath, "DownWithTheSickness");
        private static string dbName = "DownWithTheSickness.accdb";
        private static string dbPath = Path.Combine(dbDirPath, dbName);
        private string conParam = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + dbPath;
        private OleDbConnection dbConn;

        public Dialog_Database_Handler()
        {
            createDatabase();
            connectToDb();
        }

        private void connectToDb()
        {
            dbConn = new OleDbConnection(conParam);
        }

        public void addScene(Scene scene)
        {

            addSceneName(scene);

            foreach (Dialog d in scene.dialogs)
            {
                addCharacter(d.speaker);
                foreach (Character c in d.addressed_to)
                {
                    addCharacter(c);
                }
                addDialog(scene, d);
            }
        }
        public void deleteScene(Scene scene)
        {
            foreach (Dialog d in scene.dialogs)
            {
                deleteDialog(scene, d);
            }
            deleteSceneName(scene);
        }

        private void addDialog(Scene s, Dialog d)
        {
            dbConn.Open();

            int speakerID = getSpeakerID(d);
            int dialogID = getDialogID(d, speakerID);

            AddSpeakerTextAndNumber(d, dialogID);
            AddAdressedToInformation(d, speakerID, dialogID);
            AddDialogsInScene(s, d, speakerID, dialogID);
            dbConn.Close();
        }
        private void deleteDialog(Scene s, Dialog d)
        {
            dbConn.Open();

            int speakerID = getSpeakerID(d);
            int dialogID = getDialogID(d, speakerID);

            DeleteDialogsInScene(s, d, speakerID, dialogID);
            DeleteAdressedToInformation(d, speakerID, dialogID);
            DeleteSpeakerAndText(d, dialogID);
            dbConn.Close();
        }

        private void addSceneName(Scene scene)
        {
            dbConn.Open();
            int sceneID = getSceneID(scene);
            if (sceneID == 0)
            {
                string insertScene = "INSERT INTO SCENES(scene_name) VALUES (?);";
                using (OleDbCommand cmd = new OleDbCommand(insertScene, dbConn))
                {
                    cmd.Parameters.AddWithValue("?", scene.name);
                    cmd.ExecuteNonQuery();
                }
            }
            dbConn.Close();
        }
        private void deleteSceneName(Scene scene)
        {
            dbConn.Open();
            int sceneID = getSceneID(scene);
            if (sceneID != 0)
            {
                string deleteScene = "DELETE * FROM SCENES WHERE scene_name=?;";
                using (OleDbCommand cmd = new OleDbCommand(deleteScene, dbConn))
                {
                    cmd.Parameters.AddWithValue("?", scene.name);
                    cmd.ExecuteNonQuery();
                }
            }
            dbConn.Close();
        }

        private int getSceneID(Scene scene)
        {
            int sceneID = 0;
            string existsScene = "SELECT ID FROM SCENES WHERE scene_name=?;";
            using (OleDbCommand cmd = new OleDbCommand(existsScene, dbConn))
            {
                cmd.Parameters.AddWithValue("?", scene.name);
                OleDbDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    sceneID = reader.GetInt32(0);
                }
            }

            return sceneID;
        }



        private void AddDialogsInScene(Scene s, Dialog d, int speakerID, int dialogID)
        {
            int sceneID = getSceneID(s);
            int existsDialogToScene = doesDialogToSceneExist(dialogID, sceneID);
            if (existsDialogToScene == 0)
            {
                string addDialogToScene = @"INSERT INTO DIALOGS_IN_SCENE (scene,dialog)
                                          SELECT Min(ID) as scene,(
                                            SELECT Min(ID)
                                            FROM DIALOG
                                            WHERE speaker=[p1] AND dialog_text = [p2]
                                          ) AS dialog
                                          FROM SCENES
                                          WHERE SCENES.scene_name = [p3];";

                using (OleDbCommand cmd = new OleDbCommand(addDialogToScene, dbConn))
                {
                    cmd.Parameters.AddWithValue("[p1]", speakerID);
                    cmd.Parameters.AddWithValue("[p2]", d.dialog_text);
                    cmd.Parameters.AddWithValue("[p3]", s.name);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        internal void writeRowsToDatabase(List<List<string>> rows)
        {
            throw new NotImplementedException();
        }

        private void DeleteDialogsInScene(Scene s, Dialog d, int speakerID, int dialogID)
        {
            int sceneID = getSceneID(s);
            int existsDialogToScene = doesDialogToSceneExist(dialogID, sceneID);
            if (existsDialogToScene != 0)
            {
                string addDialogToScene = @"DELETE DIALOGS_IN_SCENE.*, DIALOGS_IN_SCENE.scene, DIALOGS_IN_SCENE.dialog
                                            FROM DIALOGS_IN_SCENE
                                            WHERE (((DIALOGS_IN_SCENE.scene)=?) AND ((DIALOGS_IN_SCENE.dialog)=?));";

                using (OleDbCommand cmd = new OleDbCommand(addDialogToScene, dbConn))
                {
                    cmd.Parameters.AddWithValue("?", sceneID);
                    cmd.Parameters.AddWithValue("?", dialogID);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private int doesDialogToSceneExist(int dialogID, int sceneID)
        {
            int existsDialogToScene = 0;
            string existsDialogToSceneQuery = "SELECT ID FROM DIALOGS_IN_SCENE WHERE scene=? AND dialog=?";
            using (OleDbCommand cmd = new OleDbCommand(existsDialogToSceneQuery, dbConn))
            {
                cmd.Parameters.AddWithValue("?", sceneID);
                cmd.Parameters.AddWithValue("?", dialogID);
                OleDbDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    existsDialogToScene = reader.GetInt32(0);
                };
            }

            return existsDialogToScene;
        }

        private void AddAdressedToInformation(Dialog d, int speakerID, int dialogID)
        {
            foreach (Character listener in d.addressed_to)
            {
                int listenerID = getListenerID(listener);

                int exsistsAdressedTo = 0;
                string existsAdressedToQuery = "SELECT ID FROM ADRESSED_TO WHERE dialog = ? AND listener = ?;";
                using (OleDbCommand cmd = new OleDbCommand(existsAdressedToQuery, dbConn))
                {
                    cmd.Parameters.AddWithValue("?", dialogID);
                    cmd.Parameters.AddWithValue("?", listenerID);
                    OleDbDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        exsistsAdressedTo = reader.GetInt32(0);
                    };
                }


                if (exsistsAdressedTo == 0)
                {
                    string addListeners = @"INSERT INTO adressed_to (dialog,listener)
                                VALUES (
                                    DMin('id', 'DIALOG', 'speaker=' & @speaker & ' AND dialog_text=""' & @dialogText & '""'),
                                    DMin('id', 'FIGURE', 'char_name=""' & @name & '"" AND forename=""' & @forename & '""')
                                ); ";
                    using (OleDbCommand cmd = new OleDbCommand(addListeners, dbConn))
                    {
                        cmd.Parameters.AddWithValue("@speaker", speakerID);
                        cmd.Parameters.AddWithValue("@dialogText", d.dialog_text);
                        cmd.Parameters.AddWithValue("@name", listener.name);
                        cmd.Parameters.AddWithValue("@forename", listener.forename);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }
        private void DeleteAdressedToInformation(Dialog d, int speakerID, int dialogID)
        {
            foreach (Character listener in d.addressed_to)
            {
                int listenerID = getListenerID(listener);

                int exsistsAdressedTo = 0;
                string existsAdressedToQuery = "SELECT ID FROM ADRESSED_TO WHERE dialog = ? AND listener = ?;";
                using (OleDbCommand cmd = new OleDbCommand(existsAdressedToQuery, dbConn))
                {
                    cmd.Parameters.AddWithValue("?", dialogID);
                    cmd.Parameters.AddWithValue("?", listenerID);
                    OleDbDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        exsistsAdressedTo = reader.GetInt32(0);
                    };
                }


                if (exsistsAdressedTo != 0)
                {
                    string addListeners = @"DELETE ADRESSED_TO.*, ADRESSED_TO.dialog, ADRESSED_TO.listener
                                            FROM ADRESSED_TO
                                            WHERE (((ADRESSED_TO.dialog)=?) AND ((ADRESSED_TO.listener)=?)); ";
                    using (OleDbCommand cmd = new OleDbCommand(addListeners, dbConn))
                    {
                        cmd.Parameters.AddWithValue("?", getDialogID(d, getSpeakerID(d)));
                        cmd.Parameters.AddWithValue("?", listenerID);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }

        private int getListenerID(Character listener)
        {
            int listenerID = 0;
            string getListenerID = "SELECT ID FROM FIGURE WHERE char_name=? AND forename=?;";
            using (OleDbCommand cmd = new OleDbCommand(getListenerID, dbConn))
            {
                cmd.Parameters.AddWithValue("@name", listener.name);
                cmd.Parameters.AddWithValue("@forename", listener.forename);
                OleDbDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    listenerID = reader.GetInt32(0);
                };
            }

            return listenerID;
        }

        private void AddSpeakerTextAndNumber(Dialog d, int dialogID)
        {
            if (dialogID == 0)
            {
                string addSpeakerAndText = @"INSERT INTO DIALOG (speaker, dialog_text, dialog_number) SELECT FIRST(id), ?, ?
                                        FROM FIGURE
                                        WHERE char_name = ? AND forename = ?";
                using (OleDbCommand cmd = new OleDbCommand(addSpeakerAndText, dbConn))
                {
                    cmd.Parameters.AddWithValue("?", d.dialog_text);
                    cmd.Parameters.AddWithValue("?", d.dialog_number);
                    cmd.Parameters.AddWithValue("?", d.speaker.name);
                    cmd.Parameters.AddWithValue("?", d.speaker.forename);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        private void DeleteSpeakerAndText(Dialog d, int dialogID)
        {
            if (dialogID != 0)
            {
                string deleteSpeakerAndText = @"DELETE DIALOG.*, DIALOG.speaker, DIALOG.dialog_text
                                                FROM DIALOG
                                                WHERE (((DIALOG.speaker)=?) AND ((DIALOG.dialog_text)=?));";
                using (OleDbCommand cmd = new OleDbCommand(deleteSpeakerAndText, dbConn))
                {
                    cmd.Parameters.AddWithValue("?", getSpeakerID(d));
                    cmd.Parameters.AddWithValue("?", d.dialog_text);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private int getDialogID(Dialog d, int speakerID)
        {
            int dialogID = 0;
            string existsDialog = @"SELECT ID FROM DIALOG WHERE dialog_text = ? and speaker = ?;";
            using (OleDbCommand cmd = new OleDbCommand(existsDialog, dbConn))
            {
                cmd.Parameters.AddWithValue("?", d.dialog_text);
                cmd.Parameters.AddWithValue("?", speakerID);
                OleDbDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    dialogID = reader.GetInt32(0);
                }
            }

            return dialogID;
        }

        private int getSpeakerID(Dialog d)
        {
            string getSpeakerID = "SELECT ID FROM FIGURE WHERE char_name=? AND forename=?";
            int speakerID = 0;
            using (OleDbCommand cmd = new OleDbCommand(getSpeakerID, dbConn))
            {
                cmd.Parameters.AddWithValue("?", d.speaker.name);
                cmd.Parameters.AddWithValue("?", d.speaker.forename);
                OleDbDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    speakerID = reader.GetInt32(0);
                }
            }

            return speakerID;
        }

        private void addCharacter(Character character)
        {
            dbConn.Open();
            bool exists = false;
            string checkQuery = "SELECT COUNT(*) FROM FIGURE WHERE char_name=? AND forename=?;";
            using (OleDbCommand cmd = new OleDbCommand(checkQuery, dbConn))
            {
                cmd.Parameters.AddWithValue("?", character.name);
                cmd.Parameters.AddWithValue("?", character.forename);
                OleDbDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    if (reader.GetInt32(0) == 1)
                    {
                        exists = true;
                    }
                }
            }

            if (!exists)
            {
                string addQuery = "INSERT INTO FIGURE([char_name],[forename]) values (?,?);";
                using (OleDbCommand cmd = new OleDbCommand(addQuery, dbConn))
                {
                    cmd.Parameters.AddWithValue("?", character.name);
                    cmd.Parameters.AddWithValue("?", character.forename);
                    cmd.ExecuteNonQuery();
                }
            }
            dbConn.Close();
        }
        private void deleteCharacter(Character character)
        {
            dbConn.Open();
            bool exists = false;
            string checkQuery = "SELECT COUNT(*) FROM FIGURE WHERE char_name=? AND forename=?;";
            using (OleDbCommand cmd = new OleDbCommand(checkQuery, dbConn))
            {
                cmd.Parameters.AddWithValue("?", character.name);
                cmd.Parameters.AddWithValue("?", character.forename);
                OleDbDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    if (reader.GetInt32(0) == 1)
                    {
                        exists = true;
                    }
                }
            }


            if (exists)
            {
                string addQuery = "DELETE FROM FIGURE WHERE [char_name]=? AND [forename]=?;";
                using (OleDbCommand cmd = new OleDbCommand(addQuery, dbConn))
                {
                    cmd.Parameters.AddWithValue("?", character.name);
                    cmd.Parameters.AddWithValue("?", character.forename);
                    cmd.ExecuteNonQuery();
                }
            }
            dbConn.Close();
        }

        private void createDatabase()
        {
            if (!File.Exists(dbPath))
            {
                string dbPath = Path.Combine(dbDirPath, dbName);
                createDatabaseDirectory(dbDirPath);
                File.Copy("empty.accdb", dbPath);
            }
        }

        private void createDatabaseDirectory(string dbDirPath)
        {
            bool dirExists = Directory.Exists(dbDirPath);
            if (!dirExists)
            {
                Directory.CreateDirectory(dbDirPath);
            }
        }

        public List<Scene> getAllScenes()
        {
            Dictionary<String, List<Dialog>> dict = new Dictionary<string, List<Dialog>>();
            List<String> sceneNames = getAllSceneNames();
            foreach (String sceneName in sceneNames)
            {
                dict.Add(sceneName, getSpeakerTextAndNumber(sceneName));
            }

            foreach (String sceneName in dict.Keys)
            {
                setListeners(dict[sceneName], sceneName);
            }

            List<Scene> scenes = new List<Scene>();
            foreach(var item in dict)
            {
                Scene s = new Scene();
                s.name = item.Key;
                s.dialogs = item.Value;
                scenes.Add(s);
            }

            return scenes;
        }

        private void setListeners(List<Dialog> list, String sceneName)
        {
            foreach (Dialog d in list)
            {
                string checkQuery = @"SELECT FIGURE.char_name, FIGURE.forename, ADRESSED_TO.listener, DIALOG.ID
                                      FROM SCENES INNER JOIN ((FIGURE INNER JOIN (DIALOG INNER JOIN ADRESSED_TO ON DIALOG.ID = ADRESSED_TO.dialog) ON FIGURE.ID = ADRESSED_TO.listener) INNER JOIN DIALOGS_IN_SCENE ON DIALOG.ID = DIALOGS_IN_SCENE.dialog) ON SCENES.ID = DIALOGS_IN_SCENE.scene
                                      WHERE (((ADRESSED_TO.dialog)=[DIALOG].[ID]) AND ((DIALOG.dialog_number)=?) AND ((DIALOGS_IN_SCENE.dialog)=[DIALOG].[id]) AND ((DIALOGS_IN_SCENE.scene)=[SCENES].[ID] AND [SCENES].[scene_name]=?));";
                using (OleDbCommand cmd = new OleDbCommand(checkQuery, dbConn))
                {
                    cmd.Parameters.AddWithValue("?", d.dialog_number);
                    cmd.Parameters.AddWithValue("?", sceneName);
                    OleDbDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Character c = new Character();
                        c.forename = (String)reader["forename"];
                        c.name = (String)reader["char_name"];
                        d.addressed_to.Add(c);
                    }
                }
            }
        }
        private List<String> getAllSceneNames()
        {
            dbConn.Open();
            List<String> sceneNames = new List<String>();
            string checkQuery = "SELECT scene_name FROM SCENES;";
            using (OleDbCommand cmd = new OleDbCommand(checkQuery, dbConn))
            {
                OleDbDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    sceneNames.Add(reader.GetString(0));
                }
            }
            return sceneNames;
        }

        private List<Dialog> getSpeakerTextAndNumber(String sceneName)
        {
            List<Dialog> dialogs = new List<Dialog>();
            string checkQuery = @"SELECT FIGURE.char_name, FIGURE.forename, DIALOG.dialog_text, DIALOG.dialog_number
                                  FROM SCENES INNER JOIN (FIGURE INNER JOIN(DIALOG INNER JOIN DIALOGS_IN_SCENE ON DIALOG.ID = DIALOGS_IN_SCENE.dialog) ON FIGURE.ID = DIALOG.speaker) ON SCENES.ID = DIALOGS_IN_SCENE.scene
                                  WHERE(((DIALOGS_IN_SCENE.scene) =[SCENES].[ID]) AND((SCENES.scene_name) = ?) AND((DIALOG.speaker) =[FIGURE].[ID]) AND((DIALOG.ID) =[DIALOGS_IN_SCENE].[dialog])); ";
            using (OleDbCommand cmd = new OleDbCommand(checkQuery, dbConn))
            {
                cmd.Parameters.AddWithValue("?", sceneName);
                OleDbDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Dialog d = new Dialog();
                    d.speaker.name = (String)reader["char_name"];
                    d.speaker.forename = (String)reader["forename"];
                    d.dialog_text = (String)reader["dialog_text"];
                    d.dialog_number = (int)reader["dialog_number"];
                    dialogs.Add(d);
                }
            }
            return dialogs;
        }
    }
}


