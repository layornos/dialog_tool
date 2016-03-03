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
    public partial class FrmInputSceneName : Form
    {
        private MainForm mf;
        public FrmInputSceneName(MainForm mf)
        {
            InitializeComponent();
            this.mf = mf;
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            createScene();
        }

        private void createScene()
        {
            if (txtInputSceneName.Text != "")
            {
                Scene scene = new Scene(txtInputSceneName.Text);
                mf.addNewSceneTab(scene);
                this.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtInputSceneName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                createScene();
            } 
            else if (e.KeyChar == (char)Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
