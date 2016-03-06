using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DownWithTheSickness_Dialog_Tool
{
    public partial class MainForm : Form
    {
        private Dialog_Database_Handler ddh;
        public MainForm()
        {
            InitializeComponent();
            ddh = new Dialog_Database_Handler();
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            tabScenes.Dock = DockStyle.Fill;
            tabScenes.SizeMode = TabSizeMode.Fixed;
            tabScenes.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Right );
            tblLayout.Dock = DockStyle.Fill;
            List<Scene> scenes = ddh.getAllScenes();
            foreach (Scene s in scenes)
            {
                addNewSceneTab(s);
            }
        }

        public void addNewSceneTab(Scene scene)
        {
            TabPage newTabPage = new TabPage(scene.name);
            newTabPage.DoubleClick += new EventHandler(changeSceneName_Click);
            newTabPage.BackColor = Color.Transparent;
            newTabPage.Size = tabScenes.Size;

            DataGridView dgv = new DataGridView();
            //dgv.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Right);
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.Columns.Add("Number", "Number");
            dgv.Columns.Add("Speaker", "Speaker");
            dgv.Columns.Add("Listener(s)", "Listener(s)");
            dgv.Columns.Add("Text", "Text");
            dgv.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            foreach (Dialog d in scene.dialogs)
            {
                DataGridViewRow row = (DataGridViewRow)dgv.Rows[0].Clone();
                row.Cells[0].Value = d.dialog_number;
                row.Cells[1].Value = d.speaker.forename + " " + d.speaker.name;

                int i = 1;
                foreach (Character c in d.addressed_to)
                {
                    string nl = Environment.NewLine;
                    if (i == d.addressed_to.Count)
                    {
                        row.Cells[2].Value += c.forename + " " + c.name;
                    }
                    else
                    {
                        row.Cells[2].Value += c.forename + " " + c.name + nl;
                        i++;
                    }
                }
                row.Cells[3].Value = d.dialog_text;
                dgv.Rows.Add(row);
            }

            dgv.Dock = DockStyle.Fill;
            dgv.AutoResizeColumns();
            dgv.AutoResizeRows();

            dgv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            newTabPage.Controls.Add(dgv);
            tabScenes.TabPages.Add(newTabPage);

            pnlControl.Dock = DockStyle.Fill;
        }

        private void sceneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TabPage newTabpage = new TabPage("New Scene");
            tabScenes.TabPages.Add(newTabpage);
        }

        private void changeSceneName_Click(object sender, EventArgs e)
        {
            FrmInputSceneName input = new FrmInputSceneName(this);
            input.Visible = true;
        }

        private List<Scene> getLastOpenedScenes()
        {
            List<Scene> scenes = new List<Scene>();
            return scenes;
        }

        private void btnNewScene_Click(object sender, EventArgs e)
        {
            FrmInputSceneName input = new FrmInputSceneName(this);
            input.Visible = true;
        }

        private void btnSaveActiveScene_Click(object sender, EventArgs e)
        {
            //Create Stringlist
            List<List<string>> rows = new List<List<string>>();

            DataGridView dgv = tabScenes.SelectedTab.Controls[0] as DataGridView;
            foreach (DataGridViewRow row in dgv.Rows)
            {
                List<string> values = new List<string>();
                foreach (DataGridViewCell cell in row.Cells)
                {
                    //Add value to Stringlist
                    if (cell.Value != null)
                    {
                        values.Add(cell.Value.ToString());
                    }
                }
                if (values.Count > 0)
                    rows.Add(values);
            }
            //Write Stringlist to Database
            Scene s = new Scene(tabScenes.SelectedTab.Text);
            s.dialogs = new List<Dialog>();
            fillDialogIntoScene(rows, s);
            ddh.writeSceneToDatabase(s);
        }

        private void fillDialogIntoScene(List<List<string>> rows, Scene s)
        {
            foreach (List<string> row in rows)
            {
                string[] speakerSplit = row[1].Split(' ');
                string[] listenersFirstSplit = splitString(row[2]);
                List<string[]> listenersSecondSplit = new List<string[]>();
                foreach (string name in listenersFirstSplit)
                {
                    string[] split = name.Split(' ');
                    listenersSecondSplit.Add(split);
                }


                List<Character> addressed_to = new List<Character>();
                foreach (string[] character in listenersSecondSplit)
                {
                    addressed_to.Add(new Character() { name = character[1], forename = character[0] });
                }

                Dialog d = new Dialog
                {
                    speaker = new Character { name = speakerSplit[1], forename = speakerSplit[0] },
                    addressed_to = addressed_to,
                    dialog_text = row[3],
                    dialog_number = Int32.Parse(row[0]) 
                };
                s.dialogs.Add(d);
            }
        }

        private string[] splitString(String s)
        {
            string[] lines = s.Split('\n');
            for (int i = 0; i < lines.Length; i += 1)
                lines[i] = lines[i].Trim();
            return lines;
        }

        private void btnCreateUser_Click(object sender, EventArgs e)
        {
            FrmCreateUser createUser = new FrmCreateUser();
            createUser.Visible = true;
        }
    }
}
