namespace FTPKlijent
{
    partial class FormFTPSpajanje
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormFTPSpajanje));
            this.listview_konekcije = new System.Windows.Forms.ListView();
            this.ImeVeze = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.VrstaVeze = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Modificirano = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.imageList_ListViewKonekcije = new System.Windows.Forms.ImageList(this.components);
            this.btn_obrisi = new System.Windows.Forms.Button();
            this.btn_spajanje = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btn_azuriraj = new System.Windows.Forms.Button();
            this.textBox_Naziv = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btn_odustani = new System.Windows.Forms.Button();
            this.btn_spremi = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.richTextBox_Napomena = new System.Windows.Forms.RichTextBox();
            this.textBox_lozinka = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox_username = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_port = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_host = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox_vrstaKonekcije = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.opcijeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.učitajSpremljeneVezeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.spremiVezuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zatvoriProzorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listview_konekcije
            // 
            this.listview_konekcije.BackColor = System.Drawing.SystemColors.Info;
            this.listview_konekcije.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ImeVeze,
            this.VrstaVeze,
            this.Modificirano});
            this.listview_konekcije.FullRowSelect = true;
            this.listview_konekcije.GridLines = true;
            this.listview_konekcije.HideSelection = false;
            this.listview_konekcije.Location = new System.Drawing.Point(15, 19);
            this.listview_konekcije.MultiSelect = false;
            this.listview_konekcije.Name = "listview_konekcije";
            this.listview_konekcije.Size = new System.Drawing.Size(561, 305);
            this.listview_konekcije.SmallImageList = this.imageList_ListViewKonekcije;
            this.listview_konekcije.TabIndex = 0;
            this.listview_konekcije.UseCompatibleStateImageBehavior = false;
            this.listview_konekcije.View = System.Windows.Forms.View.Details;
            this.listview_konekcije.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listview_konekcije_ColumnClick);
            this.listview_konekcije.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.listview_konekcije_ItemSelectionChanged);
            this.listview_konekcije.MouseDown += new System.Windows.Forms.MouseEventHandler(this.listview_konekcije_MouseDown);
            // 
            // ImeVeze
            // 
            this.ImeVeze.Text = "Ime veze";
            this.ImeVeze.Width = 180;
            // 
            // VrstaVeze
            // 
            this.VrstaVeze.Text = "VrstaVeze";
            this.VrstaVeze.Width = 197;
            // 
            // Modificirano
            // 
            this.Modificirano.Text = "Modificirano";
            this.Modificirano.Width = 180;
            // 
            // imageList_ListViewKonekcije
            // 
            this.imageList_ListViewKonekcije.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList_ListViewKonekcije.ImageStream")));
            this.imageList_ListViewKonekcije.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList_ListViewKonekcije.Images.SetKeyName(0, "connection_ico.ico");
            // 
            // btn_obrisi
            // 
            this.btn_obrisi.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_obrisi.Location = new System.Drawing.Point(173, 358);
            this.btn_obrisi.Name = "btn_obrisi";
            this.btn_obrisi.Size = new System.Drawing.Size(82, 35);
            this.btn_obrisi.TabIndex = 1;
            this.btn_obrisi.Text = "Obriši vezu";
            this.btn_obrisi.UseVisualStyleBackColor = true;
            this.btn_obrisi.Click += new System.EventHandler(this.btn_obrisi_Click);
            // 
            // btn_spajanje
            // 
            this.btn_spajanje.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.btn_spajanje.Location = new System.Drawing.Point(340, 358);
            this.btn_spajanje.Name = "btn_spajanje";
            this.btn_spajanje.Size = new System.Drawing.Size(82, 35);
            this.btn_spajanje.TabIndex = 2;
            this.btn_spajanje.Text = "Spoji se";
            this.btn_spajanje.UseVisualStyleBackColor = true;
            this.btn_spajanje.Click += new System.EventHandler(this.btn_spajanje_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.listview_konekcije);
            this.groupBox1.Controls.Add(this.btn_spajanje);
            this.groupBox1.Controls.Add(this.btn_obrisi);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.groupBox1.Location = new System.Drawing.Point(20, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(595, 416);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Spremljene veze";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btn_azuriraj);
            this.groupBox2.Controls.Add(this.textBox_Naziv);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.btn_odustani);
            this.groupBox2.Controls.Add(this.btn_spremi);
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Controls.Add(this.textBox_lozinka);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.textBox_username);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.textBox_port);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.textBox_host);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.comboBox_vrstaKonekcije);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(644, 27);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(450, 416);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            // 
            // btn_azuriraj
            // 
            this.btn_azuriraj.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_azuriraj.Location = new System.Drawing.Point(300, 365);
            this.btn_azuriraj.Name = "btn_azuriraj";
            this.btn_azuriraj.Size = new System.Drawing.Size(91, 35);
            this.btn_azuriraj.TabIndex = 15;
            this.btn_azuriraj.Text = "Ažuriraj vezu";
            this.btn_azuriraj.UseVisualStyleBackColor = true;
            this.btn_azuriraj.Click += new System.EventHandler(this.btn_azuriraj_Click);
            // 
            // textBox_Naziv
            // 
            this.textBox_Naziv.Location = new System.Drawing.Point(119, 15);
            this.textBox_Naziv.Name = "textBox_Naziv";
            this.textBox_Naziv.Size = new System.Drawing.Size(306, 20);
            this.textBox_Naziv.TabIndex = 14;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label6.Location = new System.Drawing.Point(17, 15);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 17);
            this.label6.TabIndex = 13;
            this.label6.Text = "Naziv";
            // 
            // btn_odustani
            // 
            this.btn_odustani.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_odustani.Location = new System.Drawing.Point(189, 365);
            this.btn_odustani.Name = "btn_odustani";
            this.btn_odustani.Size = new System.Drawing.Size(82, 35);
            this.btn_odustani.TabIndex = 12;
            this.btn_odustani.Text = "Odustani";
            this.btn_odustani.UseVisualStyleBackColor = true;
            this.btn_odustani.Click += new System.EventHandler(this.btn_odustani_Click);
            // 
            // btn_spremi
            // 
            this.btn_spremi.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_spremi.Location = new System.Drawing.Point(78, 365);
            this.btn_spremi.Name = "btn_spremi";
            this.btn_spremi.Size = new System.Drawing.Size(82, 35);
            this.btn_spremi.TabIndex = 3;
            this.btn_spremi.Text = "Unesi";
            this.btn_spremi.UseVisualStyleBackColor = true;
            this.btn_spremi.Click += new System.EventHandler(this.btn_unesi_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.richTextBox_Napomena);
            this.groupBox3.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(11, 195);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(428, 150);
            this.groupBox3.TabIndex = 11;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Napomena";
            // 
            // richTextBox_Napomena
            // 
            this.richTextBox_Napomena.Location = new System.Drawing.Point(9, 19);
            this.richTextBox_Napomena.Name = "richTextBox_Napomena";
            this.richTextBox_Napomena.Size = new System.Drawing.Size(413, 120);
            this.richTextBox_Napomena.TabIndex = 10;
            this.richTextBox_Napomena.Text = "";
            // 
            // textBox_lozinka
            // 
            this.textBox_lozinka.Location = new System.Drawing.Point(119, 151);
            this.textBox_lozinka.Name = "textBox_lozinka";
            this.textBox_lozinka.Size = new System.Drawing.Size(306, 20);
            this.textBox_lozinka.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label5.Location = new System.Drawing.Point(17, 151);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 17);
            this.label5.TabIndex = 8;
            this.label5.Text = "Lozinka";
            // 
            // textBox_username
            // 
            this.textBox_username.Location = new System.Drawing.Point(119, 115);
            this.textBox_username.Name = "textBox_username";
            this.textBox_username.Size = new System.Drawing.Size(306, 20);
            this.textBox_username.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.Location = new System.Drawing.Point(17, 115);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 17);
            this.label4.TabIndex = 6;
            this.label4.Text = "Korisničko ime";
            // 
            // textBox_port
            // 
            this.textBox_port.Location = new System.Drawing.Point(362, 81);
            this.textBox_port.Name = "textBox_port";
            this.textBox_port.Size = new System.Drawing.Size(64, 20);
            this.textBox_port.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(326, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Port";
            // 
            // textBox_host
            // 
            this.textBox_host.Location = new System.Drawing.Point(119, 80);
            this.textBox_host.Name = "textBox_host";
            this.textBox_host.Size = new System.Drawing.Size(201, 20);
            this.textBox_host.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(17, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Poslužitelj";
            // 
            // comboBox_vrstaKonekcije
            // 
            this.comboBox_vrstaKonekcije.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_vrstaKonekcije.FormattingEnabled = true;
            this.comboBox_vrstaKonekcije.Items.AddRange(new object[] {
            "FTP - File Transfer Protocol",
            "SFTP - SSH File Transfer Protocol",
            "S3 - Amazon Simple Storage Service",
            "SCP - Secure copy",
            "WebDAV - Web Distributed Authoring and Versioning"});
            this.comboBox_vrstaKonekcije.Location = new System.Drawing.Point(119, 45);
            this.comboBox_vrstaKonekcije.Name = "comboBox_vrstaKonekcije";
            this.comboBox_vrstaKonekcije.Size = new System.Drawing.Size(306, 21);
            this.comboBox_vrstaKonekcije.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(17, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Protokol";
            // 
            // menuStrip1
            // 
            this.menuStrip1.AutoSize = false;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.opcijeToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1114, 24);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // opcijeToolStripMenuItem
            // 
            this.opcijeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.učitajSpremljeneVezeToolStripMenuItem,
            this.spremiVezuToolStripMenuItem,
            this.zatvoriProzorToolStripMenuItem});
            this.opcijeToolStripMenuItem.Name = "opcijeToolStripMenuItem";
            this.opcijeToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
            this.opcijeToolStripMenuItem.Text = "Datoteka";
            // 
            // učitajSpremljeneVezeToolStripMenuItem
            // 
            this.učitajSpremljeneVezeToolStripMenuItem.Name = "učitajSpremljeneVezeToolStripMenuItem";
            this.učitajSpremljeneVezeToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.učitajSpremljeneVezeToolStripMenuItem.Text = "Učitaj listu veza";
            this.učitajSpremljeneVezeToolStripMenuItem.Click += new System.EventHandler(this.ucitajListuVezaToolStripMenuItem_Click);
            // 
            // spremiVezuToolStripMenuItem
            // 
            this.spremiVezuToolStripMenuItem.Name = "spremiVezuToolStripMenuItem";
            this.spremiVezuToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.spremiVezuToolStripMenuItem.Text = "Spremi listu veza";
            this.spremiVezuToolStripMenuItem.Click += new System.EventHandler(this.spremiVezuToolStripMenuItem_Click);
            // 
            // zatvoriProzorToolStripMenuItem
            // 
            this.zatvoriProzorToolStripMenuItem.Name = "zatvoriProzorToolStripMenuItem";
            this.zatvoriProzorToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.zatvoriProzorToolStripMenuItem.Text = "Zatvori prozor";
            this.zatvoriProzorToolStripMenuItem.Click += new System.EventHandler(this.zatvoriProzorToolStripMenuItem_Click);
            // 
            // FormFTPSpajanje
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1114, 455);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "FormFTPSpajanje";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = " Veze";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormFTPSpajanje_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btn_obrisi;
        private System.Windows.Forms.Button btn_spajanje;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btn_odustani;
        private System.Windows.Forms.Button btn_spremi;
        private System.Windows.Forms.ImageList imageList_ListViewKonekcije;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ColumnHeader ImeVeze;
        private System.Windows.Forms.ColumnHeader VrstaVeze;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem opcijeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem učitajSpremljeneVezeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zatvoriProzorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem spremiVezuToolStripMenuItem;
        private System.Windows.Forms.Button btn_azuriraj;
        public System.Windows.Forms.ComboBox comboBox_vrstaKonekcije;
        public System.Windows.Forms.TextBox textBox_port;
        public System.Windows.Forms.TextBox textBox_host;
        public System.Windows.Forms.RichTextBox richTextBox_Napomena;
        public System.Windows.Forms.TextBox textBox_lozinka;
        public System.Windows.Forms.TextBox textBox_username;
        public System.Windows.Forms.TextBox textBox_Naziv;
        public System.Windows.Forms.ListView listview_konekcije;
        private System.Windows.Forms.ColumnHeader Modificirano;
    }
}