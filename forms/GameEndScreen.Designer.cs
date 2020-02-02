namespace Breakout.forms
{
    partial class GameEndScreen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameEndScreen));
            this.lblHeader = new System.Windows.Forms.Label();
            this.lblText = new System.Windows.Forms.Label();
            this.pbxHome = new System.Windows.Forms.PictureBox();
            this.pbxReload = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbxHome)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxReload)).BeginInit();
            this.SuspendLayout();
            // 
            // lblHeader
            // 
            resources.ApplyResources(this.lblHeader, "lblHeader");
            this.lblHeader.BackColor = System.Drawing.Color.Black;
            this.lblHeader.ForeColor = System.Drawing.Color.White;
            this.lblHeader.Name = "lblHeader";
            // 
            // lblText
            // 
            resources.ApplyResources(this.lblText, "lblText");
            this.lblText.ForeColor = System.Drawing.Color.White;
            this.lblText.Name = "lblText";
            // 
            // pbxHome
            // 
            this.pbxHome.Image = global::Breakout.Properties.Resources.home;
            resources.ApplyResources(this.pbxHome, "pbxHome");
            this.pbxHome.Name = "pbxHome";
            this.pbxHome.TabStop = false;
            this.pbxHome.Click += new System.EventHandler(this.PbxHome_Click);
            // 
            // pbxReload
            // 
            this.pbxReload.Image = global::Breakout.Properties.Resources.replay;
            resources.ApplyResources(this.pbxReload, "pbxReload");
            this.pbxReload.Name = "pbxReload";
            this.pbxReload.TabStop = false;
            this.pbxReload.Click += new System.EventHandler(this.PbxReload_Click);
            // 
            // GameEndScreen
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.Controls.Add(this.lblText);
            this.Controls.Add(this.lblHeader);
            this.Controls.Add(this.pbxHome);
            this.Controls.Add(this.pbxReload);
            this.Name = "GameEndScreen";
            ((System.ComponentModel.ISupportInitialize)(this.pbxHome)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxReload)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pbxReload;
        private System.Windows.Forms.PictureBox pbxHome;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Label lblText;
    }
}