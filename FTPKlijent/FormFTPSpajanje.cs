using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;





namespace FTPKlijent
{
    public partial class FormFTPSpajanje : Form
    {
        ConnectionsContainer myConnectionsContainer = new ConnectionsContainer();
        Form_Glavna mainForm;
        public string pathLastSavedFile=null;
        public string pathLastLoaded=null;        

        public FormFTPSpajanje(Form ownerForm)
        {
            InitializeComponent();
            this.comboBox_vrstaKonekcije.SelectedIndex = 0;
            mainForm=(Form_Glavna)ownerForm;
            pathLastSavedFile = Properties.Settings.Default.pathLastSavedFile;
            pathLastLoaded = pathLastSavedFile;

            ConnectionsContainer container= ReadSavedConnections(pathLastSavedFile);

            if (container != null)
            {
                myConnectionsContainer = container;
                LoadSavedConnections();  
            } 
        }




        private ConnectionsContainer ReadSavedConnections(string pathToLoad)
        {
            if (pathToLoad != null)
            {
                ConnectionsContainer container = BinarySerialization.ReadFromBinaryFile<ConnectionsContainer>(pathToLoad);
                return container; 
            }
            else
            {
                return null;
            }         
        }



        private void LoadSavedConnections()
        {
            listview_konekcije.Items.Clear();           


            foreach (KeyValuePair<string, Connection> item in myConnectionsContainer.myConnections)
            {
                ListViewItem lvi = new ListViewItem(item.Value.ConnectionName);
                lvi.Tag = item.Value;
                lvi.ImageIndex = 0;
                lvi.SubItems.Add(ConnectionType(item.Value.Protocol));
                lvi.SubItems.Add(item.Value.Modificirano);

                listview_konekcije.Items.Add(lvi);
            }
        }


        //------------------------------------------------------------------------------------------------------------------------------------


        private void btn_unesi_Click(object sender, EventArgs e)
        {
            bool answer=isEveryInputCorrect();

            if (answer==true)
            {
                SpremiKonekciju();
            }

        }


        //------------------------------------------------------------------------------------------------------------------------------------

        private bool isEveryInputCorrect()
        {           

            bool answer = true;

            if (textBox_Naziv.Text.Equals(""))
            {                
                MyMessageBox msg = new MyMessageBox("Polje 'Naziv' je prazno!");
                msg.ShowDialog(this);

                textBox_Naziv.Focus();
                return false;
            }

            if (textBox_host.Text.Equals(""))
            {                
                MyMessageBox msg = new MyMessageBox("Polje 'Poslužitelj' je prazno!");
                msg.ShowDialog(this);

                textBox_host.Focus();
                return false;
            }

            if (textBox_lozinka.Text.Equals(""))
            {
                MyMessageBox msg = new MyMessageBox("Polje 'Lozinka' je prazno!");
                msg.ShowDialog(this);

                textBox_lozinka.Focus();
                return false;
            }

            if (textBox_port.Text.Equals(""))
            {
                textBox_port.Text = "0";
            }

            if (textBox_username.Text.Equals(""))
            {                
                MyMessageBox msg = new MyMessageBox("Polje 'Korisničko ime' je prazno!");
                msg.ShowDialog(this);

                textBox_username.Focus();
                return false;
            }

            return answer;
        }






        public bool SpremiKonekciju()
        {
            bool wasConnectionSaved = true;

            try
            {
                Connection connection = new Connection(textBox_Naziv.Text, comboBox_vrstaKonekcije.SelectedIndex, textBox_host.Text, textBox_port.Text, textBox_username.Text, textBox_lozinka.Text, richTextBox_Napomena.Text, DateTime.Now.ToString());


                if (!myConnectionsContainer.myConnections.ContainsKey(textBox_Naziv.Text))
                {
                    myConnectionsContainer.myConnections.Add(textBox_Naziv.Text, connection); 
                }
                else
                {                    
                    MyMessageBox msg = new MyMessageBox("Već postoji veza s istim imenom!");
                    msg.ShowDialog(this);

                    wasConnectionSaved = false;
                    return wasConnectionSaved;
                }

                ListViewItem item = new ListViewItem(textBox_Naziv.Text);
                item.Tag = connection;
                item.ImageIndex = 0;
                item.SubItems.Add(ConnectionType(comboBox_vrstaKonekcije.SelectedIndex));
                item.SubItems.Add(DateTime.Now.ToString());

                listview_konekcije.Items.Add(item);

                btnOdustani(); // ovo koristim samo zato sto brise sva polja potrebna za kreaciju konekcije 
                return wasConnectionSaved;
            }
            catch (Exception)
            {                
                MyMessageBox msg = new MyMessageBox("Port nije dobro upisan!");
                msg.ShowDialog(this);

                wasConnectionSaved = false;
                return wasConnectionSaved;
            }
        }




        //------------------------------------------------------------------------------------------------------------------------------------


        public string ConnectionType(int connectionType)
        {
            switch (connectionType)
            {
                case 0:
                    return "FTP - File Transfer Protocol";
                case 1:
                    return "SFTP - SSH File Transfer Protocol";
                case 2:
                    return "S3 - Amazon Simple Storage Service";
                case 3:
                    return "SCP - Secure copy";
                case 4:
                    return "WebDAV - Web Distributed Authoring and Versioning";
            }

            return null;

        }

        //------------------------------------------------------------------------------------------------------------------------------------



        private void FormFTPSpajanje_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
            mainForm.Enabled = true;
        }



        //------------------------------------------------------------------------------------------------------------------------------------


        private void btn_odustani_Click(object sender, EventArgs e)
        {
            btnOdustani();
            this.Hide();
            mainForm.Enabled = true;
        }



        private void btnOdustani()
        {
            textBox_Naziv.Clear();
            textBox_host.Clear();
            textBox_lozinka.Clear();
            textBox_port.Clear();
            textBox_username.Clear();
            richTextBox_Napomena.Clear();
            comboBox_vrstaKonekcije.SelectedIndex = 0;
        }


        //------------------------------------------------------------------------------------------------------------------------------------




        private void listview_konekcije_MouseDown(object sender, MouseEventArgs e)
        {
            ListViewHitTestInfo info = listview_konekcije.HitTest(e.X, e.Y);
            ListViewItem selectedItem = info.Item;

            if (selectedItem!=null)
            {
                Selection_listview(selectedItem);

                textBox_Naziv.ReadOnly = true;
                textBox_host.ReadOnly = true;
                textBox_lozinka.ReadOnly = true;
                textBox_port.ReadOnly = true;
                textBox_username.ReadOnly = true;
                richTextBox_Napomena.ReadOnly = true;
                comboBox_vrstaKonekcije.Enabled = false;
            }
            else
            {
                btnOdustani();

                textBox_Naziv.ReadOnly = false;
                textBox_host.ReadOnly = false;
                textBox_lozinka.ReadOnly = false;
                textBox_port.ReadOnly = false;
                textBox_username.ReadOnly = false;
                richTextBox_Napomena.ReadOnly = false;
                comboBox_vrstaKonekcije.Enabled = true;
            }
        }




        private void Selection_listview(ListViewItem selectedItem)
        {
            if (selectedItem != null)
            {
                textBox_Naziv.Text = ((Connection)selectedItem.Tag).ConnectionName;
                textBox_host.Text = ((Connection)selectedItem.Tag).Host;
                textBox_lozinka.Text = ((Connection)selectedItem.Tag).Password;
                textBox_port.Text = ((Connection)selectedItem.Tag).Port.ToString();
                textBox_username.Text = ((Connection)selectedItem.Tag).Username;
                richTextBox_Napomena.Text = ((Connection)selectedItem.Tag).Napomena;
                comboBox_vrstaKonekcije.SelectedIndex = ((Connection)selectedItem.Tag).Protocol;
            }
        }



        //------------------------------------------------------------------------------------------------------------------------------------





        private void btn_obrisi_Click(object sender, EventArgs e)
        {
            if (listview_konekcije.SelectedItems.Count>0)
            {
                DialogBoxBrisanjeVeze dialog = new DialogBoxBrisanjeVeze();
                DialogResult result = dialog.ShowDialog(this);

                if (result==DialogResult.OK)
                {
                    ListViewItem selectedItem = listview_konekcije.SelectedItems[0];
                    myConnectionsContainer.myConnections.Remove(selectedItem.Text);
                    selectedItem.Remove();
                    btnOdustani();  // ovo koristim samo zato sto brise sva polja potrebna za kreaciju konekcije
                }                
            }
            else
            {
                MyMessageBox msg = new MyMessageBox("Odaberite vezu koju želite obrisati!");
                msg.ShowDialog(this);
            }
        }


        //------------------------------------------------------------------------------------------------------------------------------------

        private void btn_spajanje_Click(object sender, EventArgs e)
        {
            if (listview_konekcije.SelectedItems.Count > 0)
            {
                mainForm.textBox_hostname.Text = ((Connection)listview_konekcije.SelectedItems[0].Tag).Host;
                mainForm.textBox_username.Text = ((Connection)listview_konekcije.SelectedItems[0].Tag).Username;
                mainForm.textBox_password.Text = ((Connection)listview_konekcije.SelectedItems[0].Tag).Password;
                mainForm.textBox_port.Text = ((Connection)listview_konekcije.SelectedItems[0].Tag).Port.ToString();
                mainForm.comboBox_vrstaKonekcije.SelectedIndex = ((Connection)listview_konekcije.SelectedItems[0].Tag).Protocol;

                mainForm.Connect();

                this.Hide();
                mainForm.Enabled = true;
            }
            else
            {
                MyMessageBox msg = new MyMessageBox("Potrebno je odabrati vezu!");
                msg.ShowDialog();
            }
        }



        //------------------------------------------------------------------------------------------------------------------------------------



        private void ucitajListuVezaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.Filter = "Binary File | *.bin";
            DialogResult result = openDialog.ShowDialog(this);

            if (result == DialogResult.OK)
            {
                string pathToLoad = openDialog.FileName;

                ConnectionsContainer container = ReadSavedConnections(pathToLoad);

                if (container != null)
                {
                    myConnectionsContainer = container;
                    LoadSavedConnections();
                    pathLastLoaded = pathToLoad;
                    pathLastSavedFile = pathToLoad;                    
                }
            }

        }


        //------------------------------------------------------------------------------------------------------------------------------------



        private void zatvoriProzorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            mainForm.Enabled = true;
        }

        //------------------------------------------------------------------------------------------------------------------------------------

        private void spremiVezuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Spremi();
        }



        private void Spremi()
        {
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Filter = "Binary File | *.bin";
            DialogResult result = saveDialog.ShowDialog(this);
            string savePath = saveDialog.FileName;

            if (result == DialogResult.OK)
            {
                BinarySerialization.WriteToBinaryFile<ConnectionsContainer>(savePath, myConnectionsContainer);
                pathLastSavedFile = savePath;
            }
        }


        //------------------------------------------------------------------------------------------------------------------------------------

        private void btn_azuriraj_Click(object sender, EventArgs e)
        {
            if (listview_konekcije.SelectedItems.Count>0)
            {
                this.Enabled = false;
                FormAzuriranjeVeze formAzuriranje = new FormAzuriranjeVeze(this, myConnectionsContainer);
                formAzuriranje.Show(this);
                formAzuriranje.Location = this.Location;


            }
            else
            {
                MyMessageBox msg = new MyMessageBox("Potrebno je odabrati vezu koju želite ažurirati!");
                msg.ShowDialog(this);
            }
        }



        //------------------------------------------------------------------------------------------------------------------------------------



        private void listview_konekcije_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            Selection_listview(e.Item);
        }








        private void listview_konekcije_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            SortingListView_Konekcije.SortListByColumn((ListView)sender, e.Column);
        }
    }
}