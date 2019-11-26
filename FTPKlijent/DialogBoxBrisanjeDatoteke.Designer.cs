namespace FTPKlijent
{
    partial class DialogBoxBrisanjeDatoteke
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DialogBoxBrisanjeDatoteke));
            this.button_Da = new System.Windows.Forms.Button();
            this.button_Odustani = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // button_Da
            // 
            this.button_Da.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button_Da.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.button_Da.Location = new System.Drawing.Point(49, 85);
            this.button_Da.Name = "button_Da";
            this.button_Da.Size = new System.Drawing.Size(75, 23);
            this.button_Da.TabIndex = 0;
            this.button_Da.Text = "DA";
            this.button_Da.UseVisualStyleBackColor = true;
            // 
            // button_Odustani
            // 
            this.button_Odustani.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button_Odustani.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.button_Odustani.Location = new System.Drawing.Point(169, 85);
            this.button_Odustani.Name = "button_Odustani";
            this.button_Odustani.Size = new System.Drawing.Size(75, 23);
            this.button_Odustani.TabIndex = 1;
            this.button_Odustani.Text = "ODUSTANI";
            this.button_Odustani.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(56, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(225, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Želite li obrisati označene datoteke?";
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Location = new System.Drawing.Point(13, 20);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(34, 32);
            this.panel1.TabIndex = 3;
            // 
            // DialogBoxBrisanjeDatotekeServer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(295, 135);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_Odustani);
            this.Controls.Add(this.button_Da);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "DialogBoxBrisanjeDatotekeServer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Brisanje datoteke";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_Da;
        private System.Windows.Forms.Button button_Odustani;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
    }
}