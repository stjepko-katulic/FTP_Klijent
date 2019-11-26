using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FTPKlijent
{
    public partial class FormAzuriranjeVeze : Form
    {
        FormFTPSpajanje parentForm;
        ConnectionsContainer myConnectionsContainer;

        public FormAzuriranjeVeze(Form ownerForm, ConnectionsContainer connectionsContainer)
        {
            InitializeComponent();
            parentForm = (FormFTPSpajanje)ownerForm;
            this.myConnectionsContainer = connectionsContainer;
            this.Owner = parentForm;           

            textBox_Naziv.Text = parentForm.textBox_Naziv.Text;
            textBox_host.Text = parentForm.textBox_host.Text;
            textBox_port.Text = parentForm.textBox_port.Text;
            textBox_username.Text = parentForm.textBox_username.Text;
            textBox_lozinka.Text = parentForm.textBox_lozinka.Text;
            richTextBox_Napomena.Text = parentForm.richTextBox_Napomena.Text;
            comboBox_vrstaKonekcije.SelectedIndex = parentForm.comboBox_vrstaKonekcije.SelectedIndex;
        }


        //------------------------------------------------------------------------------------------------------------------------




        private void btn_prihvati_Click(object sender, EventArgs e)
        {
            bool answer = isEveryInputCorrect();

            if (answer == true)
            {
                Connection bufferedConnection = myConnectionsContainer.myConnections[parentForm.textBox_Naziv.Text];
                int bufferedSelectedListViewItemIndex = parentForm.listview_konekcije.SelectedIndices[0];
                myConnectionsContainer.myConnections.Remove(parentForm.textBox_Naziv.Text);

                if (myConnectionsContainer.myConnections.ContainsKey(textBox_Naziv.Text))
                {                    
                    MyMessageBox msg = new MyMessageBox("Već postoji veza s istim imenom!");
                    msg.ShowDialog(this);

                    myConnectionsContainer.myConnections.Add(parentForm.textBox_Naziv.Text, bufferedConnection);
                    return;
                }


                ListViewItem bufferedItem = parentForm.listview_konekcije.SelectedItems[0];
                parentForm.listview_konekcije.SelectedItems[0].Remove();
                bool wasConnectionSaved = SpremiKonekciju(bufferedSelectedListViewItemIndex);

                if (wasConnectionSaved==true)
                {
                    Connection newConnection = new Connection(textBox_Naziv.Text, comboBox_vrstaKonekcije.SelectedIndex, textBox_host.Text, textBox_port.Text, textBox_username.Text, textBox_lozinka.Text, richTextBox_Napomena.Text, DateTime.Now.ToString());
                    myConnectionsContainer.myConnections.Add(textBox_Naziv.Text, newConnection);

                    parentForm.listview_konekcije.Select();
                    parentForm.listview_konekcije.Items[bufferedSelectedListViewItemIndex].Selected = true;      

                    this.Close();
                    parentForm.Enabled = true;
                }
                else
                {
                    myConnectionsContainer.myConnections.Add(parentForm.textBox_Naziv.Text, bufferedConnection);
                    parentForm.listview_konekcije.Items.Insert(bufferedSelectedListViewItemIndex, bufferedItem);
                }
            }
            else
            {
                return;
            }            
        }


        //------------------------------------------------------------------------------------------------------------------------




        private void btn_odustani_Click(object sender, EventArgs e)
        {

            this.Close();
            parentForm.Enabled = true;
        }


        //------------------------------------------------------------------------------------------------------------------------



        private void FormAzuriranjeVeze_FormClosing(object sender, FormClosingEventArgs e)
        {
            parentForm.Enabled = true;
        }







        //------------------------------------------------------------------------------------------------------------------------


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
            else
            {
                int num;
                bool isConvertibleToInt32=Int32.TryParse(textBox_port.Text, out num);

                if (isConvertibleToInt32==false)
                {
                    MyMessageBox msg = new MyMessageBox("Port nije dobro upisan!");
                    msg.ShowDialog(this);

                    return false;
                }
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






        public bool SpremiKonekciju(int itemInsertionIndex)
        {
            bool wasConnectionSaved = true;

            try
            {
                Connection connection = new Connection(textBox_Naziv.Text, comboBox_vrstaKonekcije.SelectedIndex, textBox_host.Text, textBox_port.Text, textBox_username.Text, textBox_lozinka.Text, richTextBox_Napomena.Text, DateTime.Now.ToString());

                ListViewItem item = new ListViewItem(textBox_Naziv.Text);
                item.Tag = connection;
                item.ImageIndex = 0;
                item.SubItems.Add(ConnectionType(comboBox_vrstaKonekcije.SelectedIndex));
                item.SubItems.Add(DateTime.Now.ToString());

                parentForm.listview_konekcije.Items.Insert(itemInsertionIndex, item);            
                               
                return wasConnectionSaved;
            }
            catch (Exception)
            {                
                wasConnectionSaved = false;
                return wasConnectionSaved;
            }
        }







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










    }
}
