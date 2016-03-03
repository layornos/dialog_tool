namespace DownWithTheSickness_Dialog_Tool
{
    partial class FrmInputSceneName
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
            this.txtInputSceneName = new System.Windows.Forms.TextBox();
            this.lblInputSceneName = new System.Windows.Forms.Label();
            this.btnAccept = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtInputSceneName
            // 
            this.txtInputSceneName.Location = new System.Drawing.Point(52, 62);
            this.txtInputSceneName.Name = "txtInputSceneName";
            this.txtInputSceneName.Size = new System.Drawing.Size(178, 20);
            this.txtInputSceneName.TabIndex = 0;
            this.txtInputSceneName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtInputSceneName_KeyPress);
            // 
            // lblInputSceneName
            // 
            this.lblInputSceneName.AutoSize = true;
            this.lblInputSceneName.Location = new System.Drawing.Point(52, 31);
            this.lblInputSceneName.Name = "lblInputSceneName";
            this.lblInputSceneName.Size = new System.Drawing.Size(96, 13);
            this.lblInputSceneName.TabIndex = 1;
            this.lblInputSceneName.Text = "Input Scene Name";
            // 
            // btnAccept
            // 
            this.btnAccept.Location = new System.Drawing.Point(52, 109);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(75, 23);
            this.btnAccept.TabIndex = 2;
            this.btnAccept.Text = "Accept";
            this.btnAccept.UseVisualStyleBackColor = true;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(154, 109);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // FrmInputSceneName
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 156);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.lblInputSceneName);
            this.Controls.Add(this.txtInputSceneName);
            this.Name = "FrmInputSceneName";
            this.Text = "Input Scene Name";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtInputSceneName;
        private System.Windows.Forms.Label lblInputSceneName;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.Button btnCancel;
    }
}