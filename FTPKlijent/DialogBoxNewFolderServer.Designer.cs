namespace FTPKlijent
{
    partial class DialogBoxNewFolderServer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DialogBoxNewFolderServer));
            this.textBox_imeNovogFoldera = new System.Windows.Forms.TextBox();
            this.button_noviFolder_OK = new System.Windows.Forms.Button();
            this.button_noviFolder_Odustani = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.SuspendLayout();
            // 
            // textBox_imeNovogFoldera
            // 
            this.textBox_imeNovogFoldera.Location = new System.Drawing.Point(15, 48);
            this.textBox_imeNovogFoldera.Name = "textBox_imeNovogFoldera";
            this.textBox_imeNovogFoldera.Size = new System.Drawing.Size(196, 20);
            this.textBox_imeNovogFoldera.TabIndex = 0;
            // 
            // button_noviFolder_OK
            // 
            this.button_noviFolder_OK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button_noviFolder_OK.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.button_noviFolder_OK.Location = new System.Drawing.Point(15, 94);
            this.button_noviFolder_OK.Name = "button_noviFolder_OK";
            this.button_noviFolder_OK.Size = new System.Drawing.Size(75, 23);
            this.button_noviFolder_OK.TabIndex = 1;
            this.button_noviFolder_OK.Text = "OK";
            this.button_noviFolder_OK.UseVisualStyleBackColor = true;
            // 
            // button_noviFolder_Odustani
            // 
            this.button_noviFolder_Odustani.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button_noviFolder_Odustani.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.button_noviFolder_Odustani.Location = new System.Drawing.Point(136, 94);
            this.button_noviFolder_Odustani.Name = "button_noviFolder_Odustani";
            this.button_noviFolder_Odustani.Size = new System.Drawing.Size(75, 23);
            this.button_noviFolder_Odustani.TabIndex = 2;
            this.button_noviFolder_Odustani.Text = "ODUSTANI";
            this.button_noviFolder_Odustani.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(12, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(167, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Upišite ime novog foldera.";
            // 
            // DialogBoxNewFolderServer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(230, 127);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_noviFolder_Odustani);
            this.Controls.Add(this.button_noviFolder_OK);
            this.Controls.Add(this.textBox_imeNovogFoldera);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "DialogBoxNewFolderServer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Novi folder";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox textBox_imeNovogFoldera;
        private System.Windows.Forms.Button button_noviFolder_OK;
        private System.Windows.Forms.Button button_noviFolder_Odustani;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ColorDialog colorDialog1;
    }
}