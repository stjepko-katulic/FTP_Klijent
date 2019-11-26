namespace FTPKlijent
{
    partial class DialogFileFolderOverwrite
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DialogFileFolderOverwrite));
            this.label1 = new System.Windows.Forms.Label();
            this.button_noviFolder_Odustani = new System.Windows.Forms.Button();
            this.button_noviFolder_OK = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(42, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(231, 17);
            this.label1.TabIndex = 6;
            this.label1.Text = "Želite li prebrisati potojeći file/folder?";
            // 
            // button_noviFolder_Odustani
            // 
            this.button_noviFolder_Odustani.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button_noviFolder_Odustani.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.button_noviFolder_Odustani.Location = new System.Drawing.Point(169, 87);
            this.button_noviFolder_Odustani.Name = "button_noviFolder_Odustani";
            this.button_noviFolder_Odustani.Size = new System.Drawing.Size(75, 23);
            this.button_noviFolder_Odustani.TabIndex = 5;
            this.button_noviFolder_Odustani.Text = "NE";
            this.button_noviFolder_Odustani.UseVisualStyleBackColor = true;
            // 
            // button_noviFolder_OK
            // 
            this.button_noviFolder_OK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button_noviFolder_OK.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.button_noviFolder_OK.Location = new System.Drawing.Point(48, 87);
            this.button_noviFolder_OK.Name = "button_noviFolder_OK";
            this.button_noviFolder_OK.Size = new System.Drawing.Size(75, 23);
            this.button_noviFolder_OK.TabIndex = 4;
            this.button_noviFolder_OK.Text = "DA";
            this.button_noviFolder_OK.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(44, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(14, 15);
            this.label2.TabIndex = 7;
            this.label2.Text = "h";
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Location = new System.Drawing.Point(4, 13);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(34, 32);
            this.panel1.TabIndex = 8;
            // 
            // DialogFileFolderOverwrite
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 135);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_noviFolder_Odustani);
            this.Controls.Add(this.button_noviFolder_OK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DialogFileFolderOverwrite";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Prebrisavanje";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_noviFolder_Odustani;
        private System.Windows.Forms.Button button_noviFolder_OK;
        public System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
    }
}