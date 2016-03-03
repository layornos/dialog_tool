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
    }
}
