namespace FTPKlijent
{
    partial class Form_Glavna
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Glavna));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.datotekaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fTPSpajanjeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.izlazToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.oProgramuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.oProgramuToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.oAutoruToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList_lokalniDiskovi = new System.Windows.Forms.ImageList(this.components);
            this.contextMenuStrip_localTreeView = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.Osvjezi = new System.Windows.Forms.ToolStripMenuItem();
            this.izbrišiToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.Upload = new System.Windows.Forms.ToolStripMenuItem();
            this.treeView_Server = new System.Windows.Forms.TreeView();
            this.contextMenuStrip_ServerTreeView = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.osvježiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.preuzmiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.obrišiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.preimenujToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textBox_hostname = new System.Windows.Forms.TextBox();
            this.textBox_username = new System.Windows.Forms.TextBox();
            this.textBox_password = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button_connect = new System.Windows.Forms.Button();
            this.textBox_path = new System.Windows.Forms.TextBox();
            this.treeView_lokalniDiskovi = new System.Windows.Forms.TreeView();
            this.button_upload = new System.Windows.Forms.Button();
            this.button_download = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox_pathServer = new System.Windows.Forms.TextBox();
            this.textBox_port = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.richTextBox_FTPDisplay = new System.Windows.Forms.RichTextBox();
            this.ContextMenuStrip_FTPDisplay = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.clearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listviewContentLocal = new System.Windows.Forms.ListView();
            this.imeDatoteke1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.velicina1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.vrstaDatoteke1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.modificirano1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStrip_localListView = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.izbrišiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uploadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList_ListViewContent = new System.Windows.Forms.ImageList(this.components);
            this.listviewContentServer = new System.Windows.Forms.ListView();
            this.imeDatoteke2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.velicina2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.vrstaDatoteke2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.modificirano2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStrip_ServerListView = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.preuzmiToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.obrišiToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.noviFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.preimenujToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolTip_btnUpload = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip_btnDownload = new System.Windows.Forms.ToolTip(this.components);
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.label7 = new System.Windows.Forms.Label();
            this.comboBox_vrstaKonekcije = new System.Windows.Forms.ComboBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.menuStrip1.SuspendLayout();
            this.contextMenuStrip_localTreeView.SuspendLayout();
            this.contextMenuStrip_ServerTreeView.SuspendLayout();
            this.ContextMenuStrip_FTPDisplay.SuspendLayout();
            this.contextMenuStrip_localListView.SuspendLayout();
            this.contextMenuStrip_ServerListView.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.datotekaToolStripMenuItem,
            this.oProgramuToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.menuStrip1.Size = new System.Drawing.Size(1351, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // datotekaToolStripMenuItem
            // 
            this.datotekaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fTPSpajanjeToolStripMenuItem,
            this.izlazToolStripMenuItem});
            this.datotekaToolStripMenuItem.Name = "datotekaToolStripMenuItem";
            this.datotekaToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
            this.datotekaToolStripMenuItem.Text = "Datoteka";
            // 
            // fTPSpajanjeToolStripMenuItem
            // 
            this.fTPSpajanjeToolStripMenuItem.Name = "fTPSpajanjeToolStripMenuItem";
            this.fTPSpajanjeToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.fTPSpajanjeToolStripMenuItem.Text = "Veze/konekcije";
            this.fTPSpajanjeToolStripMenuItem.Click += new System.EventHandler(this.fTPSpajanjeToolStripMenuItem_Click);
            // 
            // izlazToolStripMenuItem
            // 
            this.izlazToolStripMenuItem.Name = "izlazToolStripMenuItem";
            this.izlazToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.izlazToolStripMenuItem.Text = "Izlaz";
            this.izlazToolStripMenuItem.Click += new System.EventHandler(this.izlazToolStripMenuItem_Click);
            // 
            // oProgramuToolStripMenuItem
            // 
            this.oProgramuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.oProgramuToolStripMenuItem1,
            this.oAutoruToolStripMenuItem});
            this.oProgramuToolStripMenuItem.Name = "oProgramuToolStripMenuItem";
            this.oProgramuToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.oProgramuToolStripMenuItem.Text = "Dodatno";
            // 
            // oProgramuToolStripMenuItem1
            // 
            this.oProgramuToolStripMenuItem1.Name = "oProgramuToolStripMenuItem1";
            this.oProgramuToolStripMenuItem1.Size = new System.Drawing.Size(139, 22);
            this.oProgramuToolStripMenuItem1.Text = "O programu";
            this.oProgramuToolStripMenuItem1.Click += new System.EventHandler(this.oProgramuToolStripMenuItem1_Click);
            // 
            // oAutoruToolStripMenuItem
            // 
            this.oAutoruToolStripMenuItem.Name = "oAutoruToolStripMenuItem";
            this.oAutoruToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.oAutoruToolStripMenuItem.Text = "O autoru";
            this.oAutoruToolStripMenuItem.Click += new System.EventHandler(this.oAutoruToolStripMenuItem_Click);
            // 
            // imageList_lokalniDiskovi
            // 
            this.imageList_lokalniDiskovi.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList_lokalniDiskovi.ImageStream")));
            this.imageList_lokalniDiskovi.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList_lokalniDiskovi.Images.SetKeyName(0, "PC.png");
            this.imageList_lokalniDiskovi.Images.SetKeyName(1, "Drive.png");
            this.imageList_lokalniDiskovi.Images.SetKeyName(2, "Folder.png");
            this.imageList_lokalniDiskovi.Images.SetKeyName(3, "File.png");
            // 
            // contextMenuStrip_localTreeView
            // 
            this.contextMenuStrip_localTreeView.AllowDrop = true;
            this.contextMenuStrip_localTreeView.BackColor = System.Drawing.Color.White;
            this.contextMenuStrip_localTreeView.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Osvjezi,
            this.izbrišiToolStripMenuItem1,
            this.Upload});
            this.contextMenuStrip_localTreeView.Name = "contextMenuStrip_lokalniDiskovi";
            this.contextMenuStrip_localTreeView.Size = new System.Drawing.Size(113, 70);
            // 
            // Osvjezi
            // 
            this.Osvjezi.Name = "Osvjezi";
            this.Osvjezi.Size = new System.Drawing.Size(112, 22);
            this.Osvjezi.Tag = "Osvjezi";
            this.Osvjezi.Text = "Osvježi";
            this.Osvjezi.Click += new System.EventHandler(this.refreshToolStripMenuItem_Click);
            // 
            // izbrišiToolStripMenuItem1
            // 
            this.izbrišiToolStripMenuItem1.Name = "izbrišiToolStripMenuItem1";
            this.izbrišiToolStripMenuItem1.Size = new System.Drawing.Size(112, 22);
            this.izbrišiToolStripMenuItem1.Text = "Izbriši";
            this.izbrišiToolStripMenuItem1.Click += new System.EventHandler(this.izbrišiToolStripMenuItem_LocalTreeView_Click);
            // 
            // Upload
            // 
            this.Upload.Name = "Upload";
            this.Upload.Size = new System.Drawing.Size(112, 22);
            this.Upload.Tag = "Upload";
            this.Upload.Text = "Upload";
            this.Upload.Click += new System.EventHandler(this.uploadToolStripMenuItemLocalTreeView_Click);
            // 
            // treeView_Server
            // 
            this.treeView_Server.AllowDrop = true;
            this.treeView_Server.BackColor = System.Drawing.SystemColors.Info;
            this.treeView_Server.ContextMenuStrip = this.contextMenuStrip_ServerTreeView;
            this.treeView_Server.HideSelection = false;
            this.treeView_Server.ImageIndex = 0;
            this.treeView_Server.ImageList = this.imageList_lokalniDiskovi;
            this.treeView_Server.LabelEdit = true;
            this.treeView_Server.Location = new System.Drawing.Point(711, 315);
            this.treeView_Server.Name = "treeView_Server";
            this.treeView_Server.SelectedImageIndex = 0;
            this.treeView_Server.Size = new System.Drawing.Size(620, 264);
            this.treeView_Server.TabIndex = 9;
            this.treeView_Server.AfterLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.treeView_Server_AfterLabelEdit);
            this.treeView_Server.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.treeView_Server_BeforeExpand);
            this.treeView_Server.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.treeView_Server_ItemDrag);
            this.treeView_Server.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView_Server_AfterSelect);
            this.treeView_Server.KeyDown += new System.Windows.Forms.KeyEventHandler(this.treeView_Server_KeyDown);
            this.treeView_Server.MouseDown += new System.Windows.Forms.MouseEventHandler(this.treeView_Server_MouseDown);
            // 
            // contextMenuStrip_ServerTreeView
            // 
            this.contextMenuStrip_ServerTreeView.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.osvježiToolStripMenuItem,
            this.preuzmiToolStripMenuItem,
            this.obrišiToolStripMenuItem,
            this.preimenujToolStripMenuItem});
            this.contextMenuStrip_ServerTreeView.Name = "contextMenuStrip_Server";
            this.contextMenuStrip_ServerTreeView.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.contextMenuStrip_ServerTreeView.ShowImageMargin = false;
            this.contextMenuStrip_ServerTreeView.Size = new System.Drawing.Size(104, 92);
            // 
            // osvježiToolStripMenuItem
            // 
            this.osvježiToolStripMenuItem.Name = "osvježiToolStripMenuItem";
            this.osvježiToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.osvježiToolStripMenuItem.Text = "Osvježi";
            this.osvježiToolStripMenuItem.Click += new System.EventHandler(this.osvježiToolStripMenuItemTreeViewServer_Click);
            // 
            // preuzmiToolStripMenuItem
            // 
            this.preuzmiToolStripMenuItem.Name = "preuzmiToolStripMenuItem";
            this.preuzmiToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.preuzmiToolStripMenuItem.Text = "Preuzmi";
            this.preuzmiToolStripMenuItem.Click += new System.EventHandler(this.preuzmiToolStripMenuItemTreeViewServer_Click);
            // 
            // obrišiToolStripMenuItem
            // 
            this.obrišiToolStripMenuItem.Name = "obrišiToolStripMenuItem";
            this.obrišiToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.obrišiToolStripMenuItem.Text = "Izbriši";
            this.obrišiToolStripMenuItem.Click += new System.EventHandler(this.obrišiToolStripMenuItemTreeViewServer_Click);
            // 
            // preimenujToolStripMenuItem
            // 
            this.preimenujToolStripMenuItem.Name = "preimenujToolStripMenuItem";
            this.preimenujToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.preimenujToolStripMenuItem.Text = "Preimenuj";
            this.preimenujToolStripMenuItem.Click += new System.EventHandler(this.preimenujToolStripMenuItem_Click);
            // 
            // textBox_hostname
            // 
            this.textBox_hostname.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBox_hostname.Location = new System.Drawing.Point(234, 50);
            this.textBox_hostname.Multiline = true;
            this.textBox_hostname.Name = "textBox_hostname";
            this.textBox_hostname.Size = new System.Drawing.Size(130, 21);
            this.textBox_hostname.TabIndex = 2;
            // 
            // textBox_username
            // 
            this.textBox_username.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBox_username.Location = new System.Drawing.Point(378, 50);
            this.textBox_username.Multiline = true;
            this.textBox_username.Name = "textBox_username";
            this.textBox_username.Size = new System.Drawing.Size(130, 21);
            this.textBox_username.TabIndex = 3;
            // 
            // textBox_password
            // 
            this.textBox_password.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBox_password.Location = new System.Drawing.Point(521, 50);
            this.textBox_password.Multiline = true;
            this.textBox_password.Name = "textBox_password";
            this.textBox_password.PasswordChar = '•';
            this.textBox_password.Size = new System.Drawing.Size(130, 21);
            this.textBox_password.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(262, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 17);
            this.label1.TabIndex = 7;
            this.label1.Text = "Poslužitelj";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(392, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 17);
            this.label2.TabIndex = 8;
            this.label2.Text = "Korisničko ime";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(555, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 17);
            this.label3.TabIndex = 9;
            this.label3.Text = "Lozinka";
            // 
            // button_connect
            // 
            this.button_connect.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button_connect.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button_connect.Location = new System.Drawing.Point(760, 48);
            this.button_connect.Margin = new System.Windows.Forms.Padding(1);
            this.button_connect.Name = "button_connect";
            this.button_connect.Size = new System.Drawing.Size(85, 24);
            this.button_connect.TabIndex = 6;
            this.button_connect.Text = "Spoji se";
            this.button_connect.UseVisualStyleBackColor = true;
            this.button_connect.Click += new System.EventHandler(this.button_connect_Click);
            // 
            // textBox_path
            // 
            this.textBox_path.BackColor = System.Drawing.SystemColors.Window;
            this.textBox_path.Location = new System.Drawing.Point(59, 3);
            this.textBox_path.Name = "textBox_path";
            this.textBox_path.ReadOnly = true;
            this.textBox_path.Size = new System.Drawing.Size(565, 20);
            this.textBox_path.TabIndex = 12;
            // 
            // treeView_lokalniDiskovi
            // 
            this.treeView_lokalniDiskovi.AllowDrop = true;
            this.treeView_lokalniDiskovi.BackColor = System.Drawing.SystemColors.Info;
            this.treeView_lokalniDiskovi.ContextMenuStrip = this.contextMenuStrip_localTreeView;
            this.treeView_lokalniDiskovi.HideSelection = false;
            this.treeView_lokalniDiskovi.ImageIndex = 0;
            this.treeView_lokalniDiskovi.ImageList = this.imageList_lokalniDiskovi;
            this.treeView_lokalniDiskovi.Location = new System.Drawing.Point(22, 315);
            this.treeView_lokalniDiskovi.Name = "treeView_lokalniDiskovi";
            this.treeView_lokalniDiskovi.SelectedImageIndex = 0;
            this.treeView_lokalniDiskovi.Size = new System.Drawing.Size(620, 264);
            this.treeView_lokalniDiskovi.TabIndex = 7;
            this.treeView_lokalniDiskovi.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.treeView_lokalniDiskovi_BeforeExpand);
            this.treeView_lokalniDiskovi.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.treeView_lokalniDiskovi_ItemDrag);
            this.treeView_lokalniDiskovi.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView_lokalniDiskovi_AfterSelect);
            this.treeView_lokalniDiskovi.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView_lokalniDiskovi_NodeMouseClick);
            this.treeView_lokalniDiskovi.KeyDown += new System.Windows.Forms.KeyEventHandler(this.treeView_lokalniDiskovi_KeyDown);
            this.treeView_lokalniDiskovi.MouseDown += new System.Windows.Forms.MouseEventHandler(this.treeView_lokalniDiskovi_MouseDown);
            // 
            // button_upload
            // 
            this.button_upload.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button_upload.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_upload.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button_upload.Location = new System.Drawing.Point(5, 8);
            this.button_upload.Name = "button_upload";
            this.button_upload.Size = new System.Drawing.Size(55, 30);
            this.button_upload.TabIndex = 11;
            this.button_upload.Text = "> > >";
            this.toolTip_btnDownload.SetToolTip(this.button_upload, "Upload na server");
            this.button_upload.UseVisualStyleBackColor = true;
            this.button_upload.Click += new System.EventHandler(this.button_upload_Click);
            // 
            // button_download
            // 
            this.button_download.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button_download.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_download.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button_download.Location = new System.Drawing.Point(5, 56);
            this.button_download.Name = "button_download";
            this.button_download.Size = new System.Drawing.Size(55, 30);
            this.button_download.TabIndex = 12;
            this.button_download.Text = "< < <";
            this.toolTip_btnUpload.SetToolTip(this.button_download, "Preuzimanje sa servera");
            this.button_download.UseVisualStyleBackColor = true;
            this.button_download.Click += new System.EventHandler(this.button_download_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.Location = new System.Drawing.Point(2, 3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 17);
            this.label4.TabIndex = 18;
            this.label4.Text = "Putanja";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label5.Location = new System.Drawing.Point(12, 4);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 17);
            this.label5.TabIndex = 20;
            this.label5.Text = "Putanja";
            // 
            // textBox_pathServer
            // 
            this.textBox_pathServer.BackColor = System.Drawing.SystemColors.Window;
            this.textBox_pathServer.Location = new System.Drawing.Point(66, 4);
            this.textBox_pathServer.Name = "textBox_pathServer";
            this.textBox_pathServer.ReadOnly = true;
            this.textBox_pathServer.Size = new System.Drawing.Size(567, 20);
            this.textBox_pathServer.TabIndex = 19;
            // 
            // textBox_port
            // 
            this.textBox_port.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBox_port.Location = new System.Drawing.Point(662, 50);
            this.textBox_port.Multiline = true;
            this.textBox_port.Name = "textBox_port";
            this.textBox_port.Size = new System.Drawing.Size(70, 21);
            this.textBox_port.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label6.Location = new System.Drawing.Point(663, 29);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 17);
            this.label6.TabIndex = 22;
            this.label6.Text = "Ulaz/Port";
            // 
            // richTextBox_FTPDisplay
            // 
            this.richTextBox_FTPDisplay.BackColor = System.Drawing.SystemColors.Info;
            this.richTextBox_FTPDisplay.ContextMenuStrip = this.ContextMenuStrip_FTPDisplay;
            this.richTextBox_FTPDisplay.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.richTextBox_FTPDisplay.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.richTextBox_FTPDisplay.Location = new System.Drawing.Point(22, 78);
            this.richTextBox_FTPDisplay.Name = "richTextBox_FTPDisplay";
            this.richTextBox_FTPDisplay.ReadOnly = true;
            this.richTextBox_FTPDisplay.Size = new System.Drawing.Size(1309, 201);
            this.richTextBox_FTPDisplay.TabIndex = 23;
            this.richTextBox_FTPDisplay.Text = "";
            this.richTextBox_FTPDisplay.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.richTextBox_FTPDisplay_LinkClicked);
            // 
            // ContextMenuStrip_FTPDisplay
            // 
            this.ContextMenuStrip_FTPDisplay.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clearToolStripMenuItem});
            this.ContextMenuStrip_FTPDisplay.Name = "ContextMenuStrip_FTPDisplay";
            this.ContextMenuStrip_FTPDisplay.Size = new System.Drawing.Size(106, 26);
            // 
            // clearToolStripMenuItem
            // 
            this.clearToolStripMenuItem.Name = "clearToolStripMenuItem";
            this.clearToolStripMenuItem.Size = new System.Drawing.Size(105, 22);
            this.clearToolStripMenuItem.Text = "Obriši";
            this.clearToolStripMenuItem.Click += new System.EventHandler(this.clearToolStripMenuItem_Click);
            // 
            // listviewContentLocal
            // 
            this.listviewContentLocal.AllowColumnReorder = true;
            this.listviewContentLocal.AllowDrop = true;
            this.listviewContentLocal.BackColor = System.Drawing.SystemColors.Info;
            this.listviewContentLocal.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.imeDatoteke1,
            this.velicina1,
            this.vrstaDatoteke1,
            this.modificirano1});
            this.listviewContentLocal.ContextMenuStrip = this.contextMenuStrip_localListView;
            this.listviewContentLocal.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listviewContentLocal.FullRowSelect = true;
            this.listviewContentLocal.GridLines = true;
            this.listviewContentLocal.HideSelection = false;
            this.listviewContentLocal.Location = new System.Drawing.Point(22, 594);
            this.listviewContentLocal.Name = "listviewContentLocal";
            this.listviewContentLocal.Size = new System.Drawing.Size(620, 290);
            this.listviewContentLocal.SmallImageList = this.imageList_ListViewContent;
            this.listviewContentLocal.TabIndex = 8;
            this.listviewContentLocal.UseCompatibleStateImageBehavior = false;
            this.listviewContentLocal.View = System.Windows.Forms.View.Details;
            this.listviewContentLocal.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listviewContentLocal_ColumnClick);
            this.listviewContentLocal.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.listviewContentLocal_ItemDrag);
            this.listviewContentLocal.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.listviewContentLocal_ItemSelectionChanged);
            this.listviewContentLocal.DragDrop += new System.Windows.Forms.DragEventHandler(this.listviewContentLocal_DragDrop);
            this.listviewContentLocal.DragEnter += new System.Windows.Forms.DragEventHandler(this.listviewContentLocal_DragEnter);
            this.listviewContentLocal.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listviewContentLocal_KeyDown);
            this.listviewContentLocal.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listviewContentLocal_MouseDoubleClick);
            this.listviewContentLocal.MouseDown += new System.Windows.Forms.MouseEventHandler(this.listviewContentLocal_MouseDown);
            // 
            // imeDatoteke1
            // 
            this.imeDatoteke1.Text = "Ime datoteke";
            this.imeDatoteke1.Width = 224;
            // 
            // velicina1
            // 
            this.velicina1.Text = "Veličina [KB]";
            this.velicina1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.velicina1.Width = 120;
            // 
            // vrstaDatoteke1
            // 
            this.vrstaDatoteke1.Text = "Vrsta datoteke";
            this.vrstaDatoteke1.Width = 150;
            // 
            // modificirano1
            // 
            this.modificirano1.Text = "Modificirano";
            this.modificirano1.Width = 122;
            // 
            // contextMenuStrip_localListView
            // 
            this.contextMenuStrip_localListView.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.izbrišiToolStripMenuItem,
            this.uploadToolStripMenuItem});
            this.contextMenuStrip_localListView.Name = "contextMenuStrip_localListView";
            this.contextMenuStrip_localListView.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.contextMenuStrip_localListView.ShowImageMargin = false;
            this.contextMenuStrip_localListView.Size = new System.Drawing.Size(88, 48);
            // 
            // izbrišiToolStripMenuItem
            // 
            this.izbrišiToolStripMenuItem.Name = "izbrišiToolStripMenuItem";
            this.izbrišiToolStripMenuItem.Size = new System.Drawing.Size(87, 22);
            this.izbrišiToolStripMenuItem.Text = "Izbriši";
            this.izbrišiToolStripMenuItem.Click += new System.EventHandler(this.izbrišiToolStripMenuItem_LocalListView_Click);
            // 
            // uploadToolStripMenuItem
            // 
            this.uploadToolStripMenuItem.Name = "uploadToolStripMenuItem";
            this.uploadToolStripMenuItem.Size = new System.Drawing.Size(87, 22);
            this.uploadToolStripMenuItem.Text = "Upload";
            this.uploadToolStripMenuItem.Click += new System.EventHandler(this.uploadToolStripMenuItemLocalListView_Click);
            // 
            // imageList_ListViewContent
            // 
            this.imageList_ListViewContent.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList_ListViewContent.ImageStream")));
            this.imageList_ListViewContent.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList_ListViewContent.Images.SetKeyName(0, "Drive.png");
            this.imageList_ListViewContent.Images.SetKeyName(1, "Folder.png");
            this.imageList_ListViewContent.Images.SetKeyName(2, "File.png");
            // 
            // listviewContentServer
            // 
            this.listviewContentServer.AllowDrop = true;
            this.listviewContentServer.BackColor = System.Drawing.SystemColors.Info;
            this.listviewContentServer.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.imeDatoteke2,
            this.velicina2,
            this.vrstaDatoteke2,
            this.modificirano2});
            this.listviewContentServer.ContextMenuStrip = this.contextMenuStrip_ServerListView;
            this.listviewContentServer.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listviewContentServer.FullRowSelect = true;
            this.listviewContentServer.GridLines = true;
            this.listviewContentServer.HideSelection = false;
            this.listviewContentServer.LabelEdit = true;
            this.listviewContentServer.Location = new System.Drawing.Point(711, 594);
            this.listviewContentServer.Name = "listviewContentServer";
            this.listviewContentServer.Size = new System.Drawing.Size(620, 290);
            this.listviewContentServer.SmallImageList = this.imageList_ListViewContent;
            this.listviewContentServer.TabIndex = 10;
            this.listviewContentServer.UseCompatibleStateImageBehavior = false;
            this.listviewContentServer.View = System.Windows.Forms.View.Details;
            this.listviewContentServer.AfterLabelEdit += new System.Windows.Forms.LabelEditEventHandler(this.listviewContentServer_AfterLabelEdit);
            this.listviewContentServer.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listviewContentServer_ColumnClick);
            this.listviewContentServer.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.listviewContentServer_ItemDrag);
            this.listviewContentServer.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.listviewContentServer_ItemSelectionChanged);
            this.listviewContentServer.DragDrop += new System.Windows.Forms.DragEventHandler(this.listviewContentServer_DragDrop);
            this.listviewContentServer.DragEnter += new System.Windows.Forms.DragEventHandler(this.listviewContentServer_DragEnter);
            this.listviewContentServer.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listviewContentServer_KeyDown);
            this.listviewContentServer.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listviewContentServer_MouseDoubleClick);
            this.listviewContentServer.MouseDown += new System.Windows.Forms.MouseEventHandler(this.listviewContentServer_MouseDown);
            // 
            // imeDatoteke2
            // 
            this.imeDatoteke2.Text = "Ime datoteke";
            this.imeDatoteke2.Width = 224;
            // 
            // velicina2
            // 
            this.velicina2.Text = "Veličina [KB]";
            this.velicina2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.velicina2.Width = 120;
            // 
            // vrstaDatoteke2
            // 
            this.vrstaDatoteke2.Text = "Vrsta datoteke";
            this.vrstaDatoteke2.Width = 150;
            // 
            // modificirano2
            // 
            this.modificirano2.Text = "Modificirano";
            this.modificirano2.Width = 122;
            // 
            // contextMenuStrip_ServerListView
            // 
            this.contextMenuStrip_ServerListView.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.preuzmiToolStripMenuItem1,
            this.obrišiToolStripMenuItem1,
            this.noviFolderToolStripMenuItem,
            this.preimenujToolStripMenuItem1});
            this.contextMenuStrip_ServerListView.Name = "contextMenuStrip_ServerListView";
            this.contextMenuStrip_ServerListView.ShowImageMargin = false;
            this.contextMenuStrip_ServerListView.Size = new System.Drawing.Size(109, 92);
            // 
            // preuzmiToolStripMenuItem1
            // 
            this.preuzmiToolStripMenuItem1.Name = "preuzmiToolStripMenuItem1";
            this.preuzmiToolStripMenuItem1.Size = new System.Drawing.Size(108, 22);
            this.preuzmiToolStripMenuItem1.Text = "Preuzmi";
            this.preuzmiToolStripMenuItem1.Click += new System.EventHandler(this.preuzmiToolStripMenuItemListViewServer_Click);
            // 
            // obrišiToolStripMenuItem1
            // 
            this.obrišiToolStripMenuItem1.Name = "obrišiToolStripMenuItem1";
            this.obrišiToolStripMenuItem1.Size = new System.Drawing.Size(108, 22);
            this.obrišiToolStripMenuItem1.Text = "Izbriši";
            this.obrišiToolStripMenuItem1.Click += new System.EventHandler(this.obrišiToolStripMenuItemListViewServer_Click);
            // 
            // noviFolderToolStripMenuItem
            // 
            this.noviFolderToolStripMenuItem.Name = "noviFolderToolStripMenuItem";
            this.noviFolderToolStripMenuItem.Size = new System.Drawing.Size(108, 22);
            this.noviFolderToolStripMenuItem.Text = "Novi folder";
            this.noviFolderToolStripMenuItem.Click += new System.EventHandler(this.noviFolderToolStripMenuItemListViewServer_Click);
            // 
            // preimenujToolStripMenuItem1
            // 
            this.preimenujToolStripMenuItem1.Name = "preimenujToolStripMenuItem1";
            this.preimenujToolStripMenuItem1.Size = new System.Drawing.Size(108, 22);
            this.preimenujToolStripMenuItem1.Text = "Preimenuj";
            this.preimenujToolStripMenuItem1.Click += new System.EventHandler(this.preimenujToolStripMenuItem1_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label7.Location = new System.Drawing.Point(100, 29);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(60, 17);
            this.label7.TabIndex = 28;
            this.label7.Text = "Protokol";
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
            this.comboBox_vrstaKonekcije.Location = new System.Drawing.Point(24, 50);
            this.comboBox_vrstaKonekcije.Name = "comboBox_vrstaKonekcije";
            this.comboBox_vrstaKonekcije.Size = new System.Drawing.Size(204, 21);
            this.comboBox_vrstaKonekcije.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.textBox_path);
            this.panel1.Location = new System.Drawing.Point(22, 286);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(627, 29);
            this.panel1.TabIndex = 30;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.textBox_pathServer);
            this.panel2.Location = new System.Drawing.Point(698, 285);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(642, 29);
            this.panel2.TabIndex = 31;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.button_download);
            this.panel3.Controls.Add(this.button_upload);
            this.panel3.Location = new System.Drawing.Point(644, 671);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(65, 95);
            this.panel3.TabIndex = 32;
            // 
            // Form_Glavna
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1351, 899);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.comboBox_vrstaKonekcije);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.listviewContentServer);
            this.Controls.Add(this.listviewContentLocal);
            this.Controls.Add(this.richTextBox_FTPDisplay);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBox_port);
            this.Controls.Add(this.button_connect);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_password);
            this.Controls.Add(this.textBox_username);
            this.Controls.Add(this.textBox_hostname);
            this.Controls.Add(this.treeView_Server);
            this.Controls.Add(this.treeView_lokalniDiskovi);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(1367, 938);
            this.Name = "Form_Glavna";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FTP Klijent";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Glavna_FormClosing);
            this.Resize += new System.EventHandler(this.Form_Glavna_Resize);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.contextMenuStrip_localTreeView.ResumeLayout(false);
            this.contextMenuStrip_ServerTreeView.ResumeLayout(false);
            this.ContextMenuStrip_FTPDisplay.ResumeLayout(false);
            this.contextMenuStrip_localListView.ResumeLayout(false);
            this.contextMenuStrip_ServerListView.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem datotekaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fTPSpajanjeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem izlazToolStripMenuItem;
        private System.Windows.Forms.ImageList imageList_lokalniDiskovi;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip_localTreeView;
        private System.Windows.Forms.ToolStripMenuItem Osvjezi;
        public System.Windows.Forms.TextBox textBox_hostname;
        public System.Windows.Forms.TextBox textBox_username;
        public System.Windows.Forms.TextBox textBox_password;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button_connect;
        private System.Windows.Forms.TextBox textBox_path;

        public System.Windows.Forms.TreeView treeView_lokalniDiskovi;

        private System.Windows.Forms.Button button_upload;
        private System.Windows.Forms.Button button_download;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox_pathServer;
        public System.Windows.Forms.TextBox textBox_port;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ContextMenuStrip ContextMenuStrip_FTPDisplay;
        private System.Windows.Forms.ToolStripMenuItem clearToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip_ServerTreeView;
        private System.Windows.Forms.ToolStripMenuItem osvježiToolStripMenuItem;
        private System.Windows.Forms.ColumnHeader imeDatoteke1;
        private System.Windows.Forms.ColumnHeader velicina1;
        private System.Windows.Forms.ColumnHeader vrstaDatoteke1;
        private System.Windows.Forms.ColumnHeader imeDatoteke2;
        private System.Windows.Forms.ColumnHeader velicina2;
        private System.Windows.Forms.ColumnHeader vrstaDatoteke2;
        private System.Windows.Forms.ColumnHeader modificirano1;
        private System.Windows.Forms.ColumnHeader modificirano2;
        private System.Windows.Forms.ToolTip toolTip_btnDownload;
        private System.Windows.Forms.ToolTip toolTip_btnUpload;
        public System.Windows.Forms.ImageList imageList_ListViewContent;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem Upload;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip_localListView;
        private System.Windows.Forms.ToolStripMenuItem uploadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem preuzmiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem obrišiToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip_ServerListView;
        private System.Windows.Forms.ToolStripMenuItem preuzmiToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem obrišiToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem noviFolderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem preimenujToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem preimenujToolStripMenuItem1;
        private System.Windows.Forms.Label label7;
        public System.Windows.Forms.ComboBox comboBox_vrstaKonekcije;
        private System.Windows.Forms.ToolStripMenuItem oProgramuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem oProgramuToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem oAutoruToolStripMenuItem;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.ToolStripMenuItem izbrišiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem izbrišiToolStripMenuItem1;
        public System.Windows.Forms.RichTextBox richTextBox_FTPDisplay;
        public System.Windows.Forms.TreeView treeView_Server;
        public System.Windows.Forms.ListView listviewContentLocal;
        public System.Windows.Forms.ListView listviewContentServer;
        public System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.Panel panel2;
        public System.Windows.Forms.Panel panel3;
    }
}

