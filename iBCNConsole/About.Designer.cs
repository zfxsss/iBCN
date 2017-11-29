namespace iBCNConsole
{
    partial class About
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label_AppName = new System.Windows.Forms.Label();
            this.label_Company = new System.Windows.Forms.Label();
            this.label_Version = new System.Windows.Forms.Label();
            this.button_OK = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::iBCNConsole.Properties.Resources.console;
            this.pictureBox1.Location = new System.Drawing.Point(144, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(171, 177);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label_AppName
            // 
            this.label_AppName.AutoSize = true;
            this.label_AppName.Location = new System.Drawing.Point(193, 202);
            this.label_AppName.Name = "label_AppName";
            this.label_AppName.Size = new System.Drawing.Size(72, 13);
            this.label_AppName.TabIndex = 1;
            this.label_AppName.Text = "iBCN Console";
            // 
            // label_Company
            // 
            this.label_Company.AutoSize = true;
            this.label_Company.Location = new System.Drawing.Point(199, 252);
            this.label_Company.Name = "label_Company";
            this.label_Company.Size = new System.Drawing.Size(55, 13);
            this.label_Company.TabIndex = 2;
            this.label_Company.Text = "Metocean";
            // 
            // label_Version
            // 
            this.label_Version.AutoSize = true;
            this.label_Version.Location = new System.Drawing.Point(191, 226);
            this.label_Version.Name = "label_Version";
            this.label_Version.Size = new System.Drawing.Size(45, 13);
            this.label_Version.TabIndex = 3;
            this.label_Version.Text = "Version ";
            // 
            // button_OK
            // 
            this.button_OK.Location = new System.Drawing.Point(190, 282);
            this.button_OK.Name = "button_OK";
            this.button_OK.Size = new System.Drawing.Size(75, 23);
            this.button_OK.TabIndex = 4;
            this.button_OK.Text = "OK";
            this.button_OK.UseVisualStyleBackColor = true;
            this.button_OK.Click += new System.EventHandler(this.button_OK_Click);
            // 
            // About
            // 
            this.AcceptButton = this.button_OK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(461, 326);
            this.Controls.Add(this.button_OK);
            this.Controls.Add(this.label_Version);
            this.Controls.Add(this.label_Company);
            this.Controls.Add(this.label_AppName);
            this.Controls.Add(this.pictureBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "About";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "About";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label_AppName;
        private System.Windows.Forms.Label label_Company;
        private System.Windows.Forms.Label label_Version;
        private System.Windows.Forms.Button button_OK;
    }
}