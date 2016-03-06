namespace DownWithTheSickness_Dialog_Tool
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sceneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dialogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabScenes = new System.Windows.Forms.TabControl();
            this.tblLayout = new System.Windows.Forms.TableLayoutPanel();
            this.pnlControl = new System.Windows.Forms.Panel();
            this.btnSaveAll = new System.Windows.Forms.Button();
            this.btnSaveActiveScene = new System.Windows.Forms.Button();
            this.btnNewScene = new System.Windows.Forms.Button();
            this.btnCreateUser = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.tblLayout.SuspendLayout();
            this.pnlControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.addToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1013, 28);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(44, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(142, 26);
            this.newToolStripMenuItem.Text = "New";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(142, 26);
            this.openToolStripMenuItem.Text = "Open";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(142, 26);
            this.saveToolStripMenuItem.Text = "Save";
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(142, 26);
            this.saveAsToolStripMenuItem.Text = "Save as...";
            // 
            // addToolStripMenuItem
            // 
            this.addToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sceneToolStripMenuItem,
            this.dialogToolStripMenuItem});
            this.addToolStripMenuItem.Name = "addToolStripMenuItem";
            this.addToolStripMenuItem.Size = new System.Drawing.Size(49, 24);
            this.addToolStripMenuItem.Text = "Add";
            // 
            // sceneToolStripMenuItem
            // 
            this.sceneToolStripMenuItem.Name = "sceneToolStripMenuItem";
            this.sceneToolStripMenuItem.Size = new System.Drawing.Size(129, 26);
            this.sceneToolStripMenuItem.Text = "Scene";
            this.sceneToolStripMenuItem.Click += new System.EventHandler(this.sceneToolStripMenuItem_Click);
            // 
            // dialogToolStripMenuItem
            // 
            this.dialogToolStripMenuItem.Name = "dialogToolStripMenuItem";
            this.dialogToolStripMenuItem.Size = new System.Drawing.Size(129, 26);
            this.dialogToolStripMenuItem.Text = "Dialog";
            // 
            // tabScenes
            // 
            this.tabScenes.Location = new System.Drawing.Point(4, 4);
            this.tabScenes.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabScenes.Name = "tabScenes";
            this.tabScenes.SelectedIndex = 0;
            this.tabScenes.Size = new System.Drawing.Size(299, 297);
            this.tabScenes.TabIndex = 0;
            // 
            // tblLayout
            // 
            this.tblLayout.ColumnCount = 2;
            this.tblLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 267F));
            this.tblLayout.Controls.Add(this.tabScenes, 0, 0);
            this.tblLayout.Controls.Add(this.pnlControl, 1, 0);
            this.tblLayout.Location = new System.Drawing.Point(65, 118);
            this.tblLayout.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tblLayout.Name = "tblLayout";
            this.tblLayout.RowCount = 1;
            this.tblLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblLayout.Size = new System.Drawing.Size(888, 560);
            this.tblLayout.TabIndex = 2;
            // 
            // pnlControl
            // 
            this.pnlControl.Controls.Add(this.btnCreateUser);
            this.pnlControl.Controls.Add(this.btnSaveAll);
            this.pnlControl.Controls.Add(this.btnSaveActiveScene);
            this.pnlControl.Controls.Add(this.btnNewScene);
            this.pnlControl.Location = new System.Drawing.Point(625, 4);
            this.pnlControl.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnlControl.Name = "pnlControl";
            this.pnlControl.Size = new System.Drawing.Size(259, 551);
            this.pnlControl.TabIndex = 1;
            // 
            // btnSaveAll
            // 
            this.btnSaveAll.Location = new System.Drawing.Point(19, 96);
            this.btnSaveAll.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSaveAll.Name = "btnSaveAll";
            this.btnSaveAll.Size = new System.Drawing.Size(155, 28);
            this.btnSaveAll.TabIndex = 2;
            this.btnSaveAll.Text = "Save All";
            this.btnSaveAll.UseVisualStyleBackColor = true;
            // 
            // btnSaveActiveScene
            // 
            this.btnSaveActiveScene.Location = new System.Drawing.Point(19, 59);
            this.btnSaveActiveScene.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSaveActiveScene.Name = "btnSaveActiveScene";
            this.btnSaveActiveScene.Size = new System.Drawing.Size(155, 28);
            this.btnSaveActiveScene.TabIndex = 1;
            this.btnSaveActiveScene.Text = "Save Active Scene";
            this.btnSaveActiveScene.UseVisualStyleBackColor = true;
            this.btnSaveActiveScene.Click += new System.EventHandler(this.btnSaveActiveScene_Click);
            // 
            // btnNewScene
            // 
            this.btnNewScene.Location = new System.Drawing.Point(19, 23);
            this.btnNewScene.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnNewScene.Name = "btnNewScene";
            this.btnNewScene.Size = new System.Drawing.Size(155, 28);
            this.btnNewScene.TabIndex = 0;
            this.btnNewScene.Text = "New Scene";
            this.btnNewScene.UseVisualStyleBackColor = true;
            this.btnNewScene.Click += new System.EventHandler(this.btnNewScene_Click);
            // 
            // btnCreateUser
            // 
            this.btnCreateUser.Location = new System.Drawing.Point(19, 134);
            this.btnCreateUser.Margin = new System.Windows.Forms.Padding(4);
            this.btnCreateUser.Name = "btnCreateUser";
            this.btnCreateUser.Size = new System.Drawing.Size(155, 28);
            this.btnCreateUser.TabIndex = 3;
            this.btnCreateUser.Text = "Create User";
            this.btnCreateUser.UseVisualStyleBackColor = true;
            this.btnCreateUser.Click += new System.EventHandler(this.btnCreateUser_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1013, 730);
            this.Controls.Add(this.tblLayout);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tblLayout.ResumeLayout(false);
            this.pnlControl.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sceneToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dialogToolStripMenuItem;
        private System.Windows.Forms.TabControl tabScenes;
        private System.Windows.Forms.TableLayoutPanel tblLayout;
        private System.Windows.Forms.Panel pnlControl;
        private System.Windows.Forms.Button btnNewScene;
        private System.Windows.Forms.Button btnSaveAll;
        private System.Windows.Forms.Button btnSaveActiveScene;
        private System.Windows.Forms.Button btnCreateUser;
    }
}