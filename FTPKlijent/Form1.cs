using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using System.Diagnostics;

namespace FTPKlijent
{
    public partial class Form_Glavna : Form
    {
        /******************************************************************************************************************************************
                                                        L O C A L    D I S K    S I D E
        //*****************************************************************************************************************************************/
        

        DirectoryTreeViewLocalDisk dtv;
        public Form_Glavna()
        {
            InitializeComponent();
            formFTPSpajanje = new FormFTPSpajanje(this);
            dtv = new DirectoryTreeViewLocalDisk(treeView_lokalniDiskovi, Environment.MachineName.ToString(), this);
            treeView_lokalniDiskovi.SelectedNode = treeView_lokalniDiskovi.Nodes[0];

            button_download.Enabled = false;
            button_upload.Enabled = false;

            comboBox_vrstaKonekcije.SelectedIndex = 0;
            CheckForIllegalCrossThreadCalls = false;

            FormResizing.Dimenzije(this);
        }

        
        //-----------------------------------------------------------------------------------------------------------------------------------------


        private void treeView_lokalniDiskovi_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            try
            {
                dtv.Expand((ExtendedTreeNode)e.Node);                
            }
            catch (Exception ex)
            {
                IspisPoruka(ex.Message, VrstaPoruke.Pogreska);
            }
        }


        //-----------------------------------------------------------------------------------------------------------------------------------------


        private void refreshToolStripMenuItem_Click(object sender, EventArgs e) // REFRESH za LocalDisk treeview
        {
            treeView_lokalniDiskovi.Nodes.Clear();
            dtv = null;
            dtv = new DirectoryTreeViewLocalDisk(treeView_lokalniDiskovi, Environment.MachineName.ToString(), this);
            listviewContentLocal.Items.Clear();
            treeView_lokalniDiskovi.SelectedNode = treeView_lokalniDiskovi.Nodes[0];
        }


        //-----------------------------------------------------------------------------------------------------------------------------------------

        private void treeView_lokalniDiskovi_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                ListView_Content.ShowContentLocal(listviewContentLocal, e.Node.Name, this);
                textBox_path.Text = (string)e.Node.Name;

                if (listviewContentLocal.Items.Count == 0)
                {
                    listviewContentLocal.Items.Clear();
                }
            }
            catch (Exception ex)
            {
                IspisPoruka(ex.Message, VrstaPoruke.Pogreska);
            }
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------

        private void listviewContentLocal_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            textBox_path.Text = Convert.ToString(e.Item.Tag);
        }


        //-----------------------------------------------------------------------------------------------------------------------------------------

        private void listviewContentLocal_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            SortingListView_GlavnaForma.SortListByColumn((ListView)sender, e.Column);
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------

        private void listviewContentLocal_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                ListViewHitTestInfo info = listviewContentLocal.HitTest(e.X, e.Y);

                if (info.Item != null)
                {
                    FileAttributes dirInfo = File.GetAttributes((string)info.Item.Tag);

                    if (dirInfo.HasFlag(FileAttributes.Directory))
                    {
                        ListView_Content.ShowContentLocal(listviewContentLocal, (string)info.Item.Tag, this);

                        string itemName = (string)info.Item.Tag;

                        treeView_lokalniDiskovi.SelectedNode.Expand();
                        TreeNode node = treeView_lokalniDiskovi.Nodes.Find(itemName, true)[0];
                        node.Expand();
                        treeView_lokalniDiskovi.SelectedNode = node;
                    }
                }
            }
            catch (Exception ex)
            {
                IspisPoruka(ex.Message, VrstaPoruke.Pogreska);
            }
        }


        //-----------------------------------------------------------------------------------------------------------------------------------------

        private void listviewContentLocal_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    var items = listviewContentLocal.SelectedItems;
                    string itemName = (string)items[0].Tag;

                    if (items.Count > 0) // ako je vise selektiranih foldera onda otvara samo prvi selektirani
                    {
                        FileAttributes dirInfo = File.GetAttributes((string)items[0].Tag);

                        if ((dirInfo.HasFlag(FileAttributes.Directory)))  // provjeravamo da li je doubleklikan folder ili file; ako je file onda ne prikazuje content jer ga ni nema (radi se o fileu)
                        {
                            ListView_Content.ShowContentLocal(listviewContentLocal, (string)items[0].Tag, this);

                            if (!treeView_lokalniDiskovi.SelectedNode.IsExpanded)
                            {
                                treeView_lokalniDiskovi.SelectedNode.Expand();
                            }

                            treeView_lokalniDiskovi.SelectedNode = treeView_lokalniDiskovi.SelectedNode.Nodes[itemName];

                        }
                    }
                }
                else if (e.KeyCode == Keys.Back)
                {
                    if (treeView_lokalniDiskovi.SelectedNode.Parent != null)
                    {
                        treeView_lokalniDiskovi.SelectedNode = treeView_lokalniDiskovi.SelectedNode.Parent;
                    }
                }
                else if (e.KeyCode==Keys.Delete)
                {
                    IzbrisiLocalListView();
                }
            }
            catch (Exception ex)
            {
                IspisPoruka(ex.Message, VrstaPoruke.Pogreska);
            }
        }




        //-----------------------------------------------------------------------------------------------------------------------------------------

        private void treeView_lokalniDiskovi_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (!treeView_lokalniDiskovi.SelectedNode.IsExpanded)
                {
                    treeView_lokalniDiskovi.SelectedNode.Expand();
                }
                else
                {
                    treeView_lokalniDiskovi.SelectedNode.Collapse();
                }
            }
            else if (e.KeyCode == Keys.Delete)
            {
                IzbrisiLocalTreeView();
            }
        }
        

        //-----------------------------------------------------------------------------------------------------------------------------------------

        private void uploadToolStripMenuItemLocalListView_Click(object sender, EventArgs e)
        {
            button_upload_Click(sender, e);
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------

        private void uploadToolStripMenuItemLocalTreeView_Click(object sender, EventArgs e)
        {
            button_upload_Click(sender, e);
        }


        //-----------------------------------------------------------------------------------------------------------------------------------------


        private void treeView_lokalniDiskovi_MouseDown(object sender, MouseEventArgs e)
        {
            TreeViewHitTestInfo info = treeView_lokalniDiskovi.HitTest(e.X, e.Y);

            if (info.Location == TreeViewHitTestLocations.Label || info.Location == TreeViewHitTestLocations.Image)
            {
                if (FTPConnection2.ConnectionEstablished == true)
                {
                    contextMenuStrip_localTreeView.Items["Upload"].Enabled = true;
                    contextMenuStrip_localTreeView.Items["izbrišiToolStripMenuItem1"].Enabled = true;
                    contextMenuStrip_localTreeView.Items["Osvjezi"].Enabled = true;
                }
                else
                {
                    contextMenuStrip_localTreeView.Items["Upload"].Enabled = false;
                    contextMenuStrip_localTreeView.Items["izbrišiToolStripMenuItem1"].Enabled = true;
                    contextMenuStrip_localTreeView.Items["Osvjezi"].Enabled = true;
                }
                
                treeView_lokalniDiskovi.SelectedNode = info.Node;
            }
            else
            {
                contextMenuStrip_localTreeView.Items["Upload"].Enabled = false;
                contextMenuStrip_localTreeView.Items["izbrišiToolStripMenuItem1"].Enabled = false;
                contextMenuStrip_localTreeView.Items["Osvjezi"].Enabled = true;
            }
        }


        //-----------------------------------------------------------------------------------------------------------------------------------------


        private void listviewContentLocal_MouseDown(object sender, MouseEventArgs e)
        {
            ListViewHitTestInfo infoLV = listviewContentLocal.HitTest(e.X, e.Y);

            if (infoLV.Location == ListViewHitTestLocations.Label || infoLV.Location == ListViewHitTestLocations.Image)
            {
                if (FTPConnection2.ConnectionEstablished == true)
                {
                    contextMenuStrip_localListView.Items["izbrišiToolStripMenuItem"].Enabled = true;
                    contextMenuStrip_localListView.Items["uploadToolStripMenuItem"].Enabled = true;
                }
                else
                {
                    contextMenuStrip_localListView.Items["izbrišiToolStripMenuItem"].Enabled = true;
                    contextMenuStrip_localListView.Items["uploadToolStripMenuItem"].Enabled = false;
                }
            }
            else
            {
                contextMenuStrip_localListView.Items["izbrišiToolStripMenuItem"].Enabled = false;
                contextMenuStrip_localListView.Items["uploadToolStripMenuItem"].Enabled = false;
            }
        }


        //-----------------------------------------------------------------------------------------------------------------------------------------

        private void treeView_lokalniDiskovi_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            TreeViewHitTestInfo info = treeView_lokalniDiskovi.HitTest(e.X, e.Y);

            if (info.Location == TreeViewHitTestLocations.Label)
            {
                treeView_lokalniDiskovi.SelectedNode = null;
                treeView_lokalniDiskovi.SelectedNode = e.Node;
                listviewContentLocal.SelectedIndices.Clear();
            }
        }


        //-----------------------------------------------------------------------------------------------------------------------------------------

        private void izbrišiToolStripMenuItem_LocalListView_Click(object sender, EventArgs e)
        {
            IzbrisiLocalListView();
        }




        private void IzbrisiLocalListView()
        {
            ListView.SelectedListViewItemCollection itemsToDelete = listviewContentLocal.SelectedItems;

            DialogBoxBrisanjeDatoteke dialog = new DialogBoxBrisanjeDatoteke();
            DialogResult result = dialog.ShowDialog(this);

            if (result == DialogResult.OK)
            {
                try
                {
                    foreach (ListViewItem item in itemsToDelete)
                    {
                        if (item.Name.Equals("True"))
                        {
                            Directory.Delete((string)item.Tag, true);
                            IspisPoruka("Obrisan je folder ---> " + (string)item.Tag, VrstaPoruke.OK);
                        }
                        else
                        {
                            File.Delete((string)item.Tag);
                            IspisPoruka("Obrisana je datoteka ---> " + (string)item.Tag, VrstaPoruke.OK);
                        }
                    }


                    foreach (ListViewItem item in itemsToDelete)
                    {
                        if (item.Name.Equals("True"))
                        {
                            TreeNode nodeToDelete = treeView_lokalniDiskovi.Nodes.Find((string)item.Tag, true)[0];
                            treeView_lokalniDiskovi.Nodes.Remove(nodeToDelete);
                            listviewContentLocal.Items.Remove(item);
                        }
                        else
                        {
                            listviewContentLocal.Items.Remove(item);
                        }
                    }
                }
                catch (Exception ex)
                {
                    IspisPoruka(ex.Message, VrstaPoruke.Pogreska);
                }
            }
        }


        //-----------------------------------------------------------------------------------------------------------------------------------------


        private void izbrišiToolStripMenuItem_LocalTreeView_Click(object sender, EventArgs e)
        {
            IzbrisiLocalTreeView();
        }





        private void IzbrisiLocalTreeView()
        {
            DialogBoxBrisanjeDatoteke dialog = new DialogBoxBrisanjeDatoteke();
            DialogResult result = dialog.ShowDialog(this);

            if (result == DialogResult.OK)
            {
                try
                {
                    Directory.Delete(treeView_lokalniDiskovi.SelectedNode.Name, true);
                    IspisPoruka("Obrisan je folder ---> " + treeView_lokalniDiskovi.SelectedNode.Name, VrstaPoruke.OK);
                    treeView_lokalniDiskovi.SelectedNode.Remove();
                }
                catch (Exception ex)
                {
                    IspisPoruka(ex.Message, VrstaPoruke.Pogreska);
                }
            }
        }


        /************************************************************************************************************************************
                                                            S E R V E R     S I D E
        ************************************************************************************************************************************/



        //-----------------------------------------------------------------------------------------------------------------------------------------

        private async void treeView_Server_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            await ExpandTreeNode((ExtendedTreeNode)e.Node);            
        }






        private async Task ExpandTreeNode(ExtendedTreeNode nodeToExpand)
        {     
            try
            {        
                if (!nodeToExpand.WasNodeAlreadyExpanded)
                {
                    Task<List<TreeNode>> task1=new Task<List<TreeNode>>(new Func<List<TreeNode>>(()=> serverTree.ExpandTreeNode(nodeToExpand, myFTPConnection)));
                    task1.Start();
                    List<TreeNode> newNodes = await task1;
                     
                    nodeToExpand.Nodes.Clear();

                    foreach (TreeNode node in newNodes)
                    {
                        nodeToExpand.Nodes.Add(node);
                    }

                    nodeToExpand.WasNodeAlreadyExpanded = true;
                }
            }
            catch (Exception ex)
            {
                IspisPoruka(ex.Message, VrstaPoruke.Pogreska);
            }
        }




        //-----------------------------------------------------------------------------------------------------------------------------------------

        private async void treeView_Server_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                if (!ServerDictionary.ContentDictionary.ContainsKey(e.Node.Name))
                {
                    Task task1 = new Task(new Action(() => ListView_Content.ShowContentServer(listviewContentServer, e.Node.Name, myFTPConnection, this)));
                    task1.Start();
                    await task1;

                    textBox_pathServer.Text = (string)e.Node.Name;

                    List<ListViewItem> listOfItems = new List<ListViewItem>();

                    foreach (ListViewItem item in listviewContentServer.Items)
                    {
                        listOfItems.Add(item);
                    }

                    ServerDictionary.AddItem(e.Node.Name, listOfItems); 
                }
                else
                {
                    listviewContentServer.Items.Clear();
                    List<ListViewItem> listOfItems = new List<ListViewItem>();
                    listOfItems = ServerDictionary.ContentDictionary[e.Node.Name];

                    foreach (ListViewItem item in listOfItems)
                    {
                        listviewContentServer.Items.Add(item);
                    }
                } 
            }
            catch (Exception ex)
            {
                IspisPoruka(ex.Message, VrstaPoruke.Pogreska);
            }
        }


        //-----------------------------------------------------------------------------------------------------------------------------------------

        private void treeView_Server_MouseDown(object sender, MouseEventArgs e)
        {
            TreeViewHitTestInfo info = treeView_Server.HitTest(e.X, e.Y);
            
            if ((info.Location == TreeViewHitTestLocations.Label || info.Location == TreeViewHitTestLocations.Image) && FTPConnection2.ConnectionEstablished == true)
            {
                contextMenuStrip_ServerTreeView.Items["preuzmiToolStripMenuItem"].Enabled = true;
                contextMenuStrip_ServerTreeView.Items["obrišiToolStripMenuItem"].Enabled = true;
                contextMenuStrip_ServerTreeView.Items["osvježiToolStripMenuItem"].Enabled = true;
                contextMenuStrip_ServerTreeView.Items["preimenujToolStripMenuItem"].Enabled = true;
                listviewContentServer.SelectedIndices.Clear();
            }
            else if (FTPConnection2.ConnectionEstablished == true)
            {
                contextMenuStrip_ServerTreeView.Items["preuzmiToolStripMenuItem"].Enabled = false;
                contextMenuStrip_ServerTreeView.Items["obrišiToolStripMenuItem"].Enabled = false;
                contextMenuStrip_ServerTreeView.Items["preimenujToolStripMenuItem"].Enabled = false;
                contextMenuStrip_ServerTreeView.Items["osvježiToolStripMenuItem"].Enabled = true;
            }
            else
            {
                contextMenuStrip_ServerTreeView.Items["preuzmiToolStripMenuItem"].Enabled = false;
                contextMenuStrip_ServerTreeView.Items["obrišiToolStripMenuItem"].Enabled = false;
                contextMenuStrip_ServerTreeView.Items["preimenujToolStripMenuItem"].Enabled = false;
                contextMenuStrip_ServerTreeView.Items["osvježiToolStripMenuItem"].Enabled = false;
            }

            if (e.Button==MouseButtons.Right)
            {
                treeView_Server.SelectedNode = info.Node; 
            }
        }


        //-----------------------------------------------------------------------------------------------------------------------------------------

        private void preuzmiToolStripMenuItemTreeViewServer_Click(object sender, EventArgs e)
        {
            button_download_Click(sender, e);
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------

        private async void obrišiToolStripMenuItemTreeViewServer_Click(object sender, EventArgs e)
        {
            await IzbrisiSaServera();
        }


        //-----------------------------------------------------------------------------------------------------------------------------------------

        private void osvježiToolStripMenuItemTreeViewServer_Click(object sender, EventArgs e) // ovo je refresh za treeview_server
        {
            try
            {
                treeView_Server.Nodes.Clear();
                ServerDictionary.ContentDictionary.Clear();

                if (myFTPConnection != null)
                {
                    button_connect_Click(null, null); // kao da ponovo kliknemo gumb za spajanje
                }
                else
                {
                    throw new Exception("Pogreška: Potrebno se spojiti na server.");
                }
            }
            catch (Exception ex)
            {
                IspisPoruka(ex.Message, VrstaPoruke.Pogreska);
            }
        }



        //-----------------------------------------------------------------------------------------------------------------------------------------

        private void listviewContentServer_MouseDown(object sender, MouseEventArgs e)
        {

            ListViewHitTestInfo infoLV = listviewContentServer.HitTest(e.X, e.Y);

            if ((infoLV.Location == ListViewHitTestLocations.Label || infoLV.Location == ListViewHitTestLocations.Image) && FTPConnection2.ConnectionEstablished==true)
            {
                contextMenuStrip_ServerListView.Items["preuzmiToolStripMenuItem1"].Enabled = true;
                contextMenuStrip_ServerListView.Items["obrišiToolStripMenuItem1"].Enabled = true;
                contextMenuStrip_ServerListView.Items["preimenujToolStripMenuItem1"].Enabled = true;
                contextMenuStrip_ServerListView.Items["noviFolderToolStripMenuItem"].Enabled = true;                
            }
            else if (FTPConnection2.ConnectionEstablished == true)
            {
                contextMenuStrip_ServerListView.Items["preuzmiToolStripMenuItem1"].Enabled = false;
                contextMenuStrip_ServerListView.Items["obrišiToolStripMenuItem1"].Enabled = false;
                contextMenuStrip_ServerListView.Items["preimenujToolStripMenuItem1"].Enabled = false;
                contextMenuStrip_ServerListView.Items["noviFolderToolStripMenuItem"].Enabled = true;
            }
            else
            {
                contextMenuStrip_ServerListView.Items["preuzmiToolStripMenuItem1"].Enabled = false;
                contextMenuStrip_ServerListView.Items["obrišiToolStripMenuItem1"].Enabled = false;
                contextMenuStrip_ServerListView.Items["preimenujToolStripMenuItem1"].Enabled = false;
                contextMenuStrip_ServerListView.Items["noviFolderToolStripMenuItem"].Enabled = false;
            }
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------

        private void preuzmiToolStripMenuItemListViewServer_Click(object sender, EventArgs e)
        {
            button_download_Click(sender, e);
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------

        private async void obrišiToolStripMenuItemListViewServer_Click(object sender, EventArgs e)
        {
            await IzbrisiSaServera();
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------

        private async void noviFolderToolStripMenuItemListViewServer_Click(object sender, EventArgs e)
        {
            await NoviFolder();
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------


        private void listviewContentServer_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            textBox_pathServer.Text = (string)e.Item.Tag;
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------

        private void listviewContentServer_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            SortingListView_GlavnaForma.SortListByColumn((ListView)sender, e.Column);
        }


        //-----------------------------------------------------------------------------------------------------------------------------------------


        private async void listviewContentServer_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                ListViewHitTestInfo info = listviewContentServer.HitTest(e.X, e.Y);

                if (info.Item != null)
                {
                    string itemName = (string)info.Item.Text;                    

                    if (!treeView_Server.SelectedNode.IsExpanded)
                    {
                        await ExpandTreeNode((ExtendedTreeNode)treeView_Server.SelectedNode);
                    }                    

                    treeView_Server.SelectedNode = treeView_Server.Nodes.Find((string)info.Item.Tag, true)[0];
                    treeView_Server.SelectedNode.Expand();
                }
            }
            catch (Exception ex)
            {
                IspisPoruka(ex.Message, VrstaPoruke.Pogreska);
            }
        }



        //-----------------------------------------------------------------------------------------------------------------------------------------


        private async void listviewContentServer_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                // Otvara selektirani folder i prikazuje njegov sadrzaj u listviewu. Ako je selektiran file onda ga ne otvara (ne radi nista).
                // Ako je selektirano vise fileova i/ili foldera onda otvara samo onaj koji je prvi selektiran (prema prikazu u listviewu).
                if (e.KeyCode == Keys.Enter)
                {
                    var items = listviewContentServer.SelectedItems;
                    string itemName = (string)items[0].Tag;

                    if (items[0].Name.Equals("True")) // provjeravamo da li je selektiran folder ili file
                    {
                        if (!treeView_Server.SelectedNode.IsExpanded)
                        {
                            await ExpandTreeNode((ExtendedTreeNode)treeView_Server.SelectedNode);
                        }

                        treeView_Server.SelectedNode = treeView_Server.Nodes.Find(itemName, true)[0];
                    }
                }
                // pritiskom na tipku "backspace" u listvievu (content) prikazuje se sadrzaj parent foldera od trenutacnog prikaza u listviewu.
                else if (e.KeyCode == Keys.Back)
                {
                    if (treeView_Server.SelectedNode.Parent != null)
                    {
                        treeView_Server.SelectedNode = treeView_Server.SelectedNode.Parent;
                    }
                }
                else if (e.KeyCode==Keys.Delete)
                {
                    IzbrisiSaServera();

                }
            }
            catch (Exception ex)
            {
                IspisPoruka(ex.Message, VrstaPoruke.Pogreska);
            }
        }


        //-----------------------------------------------------------------------------------------------------------------------------------------

        private void treeView_Server_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Delete)
            {
                BrisanjeSTreeViewaServer((ExtendedTreeNode)treeView_Server.SelectedNode);
            }
        }


        //-----------------------------------------------------------------------------------------------------------------------------------------

        private void treeView_Server_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            ServerTreeNodeLabelEdith(e.Node, e.Label);
        }





        public void ServerTreeNodeLabelEdith(TreeNode node, string label)
        {
            string newName = label;
            string serverFilePath = node.Name;

            if (label != null)
            {
                string oldNodeName = node.Name;
                myFTPConnection.RenameOnServer(newName, serverFilePath);
                node.Name = node.Name.Substring(0, node.Name.LastIndexOf("/")) + "/" + label;
                ServerDictionary.RenameKey(oldNodeName, node.Name);

                ExtendedTreeNode parentNode = (ExtendedTreeNode)node.Parent;

                if (parentNode != null)
                {
                    ServerDictionary.RenameListViewItem(parentNode.Name, oldNodeName, node.Name);
                }
            }
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------

        private void preimenujToolStripMenuItem_Click(object sender, EventArgs e) // server treeview
        {
            treeView_Server.SelectedNode.BeginEdit();
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------

        private void listviewContentServer_AfterLabelEdit(object sender, LabelEditEventArgs e)
        {
            ServerListViewLabelEdith(((ListView)sender).Items[e.Item], e.Label);
        }






        public void ServerListViewLabelEdith(ListViewItem item, string label)
        {
            try
            {
                if (label != null)
                {
                    string oldPath = (string)item.Tag;
                    string newPath = oldPath.Substring(0, oldPath.LastIndexOf("/")) + "/" + label;

                    myFTPConnection.RenameOnServer(label, oldPath);

                    if (((string)item.Name).Equals("True"))
                    {
                        ServerDictionary.RenameKey(oldPath, newPath);
                        ServerDictionary.RenameListViewItem(treeView_Server.SelectedNode.Name, oldPath, newPath);

                        if (treeView_Server.SelectedNode.IsExpanded)
                        {
                            ExtendedTreeNode nodeToChange = (ExtendedTreeNode)treeView_Server.Nodes.Find(oldPath, true)[0];
                            nodeToChange.Text = label;
                            nodeToChange.Name = newPath;
                        }

                    }
                    else
                    {
                        ServerDictionary.RenameListViewItem(treeView_Server.SelectedNode.Name, oldPath, newPath);
                    }

                    item.Tag = newPath;
                    item.Text = label;
                }
            }
            catch (Exception ex)
            {
                IspisPoruka(ex.Message, VrstaPoruke.Pogreska);
            }
        }


        //-----------------------------------------------------------------------------------------------------------------------------------------

        private void preimenujToolStripMenuItem1_Click(object sender, EventArgs e) // server listview
        {
            listviewContentServer.SelectedItems[0].BeginEdit();
        }




        /*======================================================================================================================================
                                                            K O N E K C I J A
        ======================================================================================================================================*/


        FormFTPSpajanje formFTPSpajanje;
        private void fTPSpajanjeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.Enabled = false;                                
                formFTPSpajanje.Show(this);
                formFTPSpajanje.Location = this.Location;
            }
            catch (Exception)
            {
                this.Enabled = true;
            }
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------

        FTPConnection2 myFTPConnection;
        private async void button_connect_Click(object sender, EventArgs e)
        {
            await Connect();
        }



        public async Task Connect()
        {
            Stopwatch myStopwatch = new Stopwatch();
            myStopwatch.Start();

            try
            {
                button_connect.Enabled = false;

                treeView_Server.Nodes.Clear();
                listviewContentServer.Items.Clear();

                IspisPoruka("Spajam se ...", VrstaPoruke.Neutralno);

                Task myTask = new Task(() => Connecting());
                myTask.Start();
                await myTask;

                button_connect.Enabled = true;
                button_upload.Enabled = true;
                button_download.Enabled = true;

                treeView_Server.SelectedNode = treeView_Server.Nodes[0];

                IspisPoruka("Uspješno spajanje", VrstaPoruke.Neutralno);
            }
            catch (Exception ex)
            {
                button_connect.Enabled = true;
                IspisPoruka(ex.Message, VrstaPoruke.Pogreska);
            }

            myStopwatch.Stop();
        }


        //-----------------------------------------------------------------------------------------------------------------------------------------

        GeneriranjeServerTreeViewa serverTree;

        private void Connecting()
        {
            myFTPConnection = null;
            ServerDictionary.ContentDictionary.Clear();


            myFTPConnection = new FTPConnection2(textBox_hostname.Text, textBox_username.Text, textBox_password.Text, textBox_port.Text, richTextBox_FTPDisplay, comboBox_vrstaKonekcije.SelectedIndex);

            try
            {
                serverTree = new GeneriranjeServerTreeViewa("/");
                serverTree.GenerateTreeView(serverTree.superNode, "/", myFTPConnection);
                BeginInvoke(new Action(() => {treeView_Server.Nodes.Add(serverTree.superNode);}));
                FTPConnection2.ConnectionEstablished = true;
                
            }
            catch (Exception e)
            {
                BeginInvoke(new Action(() =>
                {
                    IspisPoruka(e.Message, VrstaPoruke.Pogreska);
                }));
            }
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------

        private void richTextBox_FTPDisplay_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(e.LinkText);
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------


        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox_FTPDisplay.Clear();
            
        }




        /*======================================================================================================================================
                                                                O S T A L O        
        ======================================================================================================================================*/

        private async void button_upload_Click(object sender, EventArgs e)
        {
            await UploadFilesAndFolders();
        }





        private async Task UploadFilesAndFolders(string pathWhereToUpload=null)
        {
            try
            {
                IspisPoruka("STATUS: Upload u tijeku ... ", VrstaPoruke.Neutralno);

                ListView.SelectedListViewItemCollection listviewContentLocalSelectedItems = listviewContentLocal.SelectedItems;
                ListView.SelectedListViewItemCollection listviewContentServerSelectedItems = listviewContentServer.SelectedItems;


                //********   ODREĐIVANJE UPLOAD PATHA *******************
                string serverPath;


                if (pathWhereToUpload == null)
                {
                    if (listviewContentServerSelectedItems.Count > 0)
                    {
                        // ako su selektirani itemi (ili item) u serverListViewu onda nam je upload path Tag prvog selektiranog itema;
                        // taj path dodatno provjeravamo u CheckUploadPath da vidimo da li je selektirani item file ili folder, ako je file onda je upload destinacija path foldera koji sadrzi selektirani file
                        serverPath = myFTPConnection.CheckUploadPath(listviewContentServerSelectedItems[0]);
                    }
                    else
                    {
                        // ako nema selektiranih itema u serverListViewu onda je upload destinacija path selektiranog noda u serverTreeViewu
                        serverPath = treeView_Server.SelectedNode.Name;
                    }
                }
                else
                {
                    serverPath = pathWhereToUpload;
                }


                //********   UPLOADANJE I GENERIRANJE SERVER TREEVIEWA *******************
                if (myFTPConnection != null)
                {
                    if (listviewContentLocalSelectedItems.Count > 0)
                    {
                        // ako su selektirani itemu u localListViewu onda se oni proslijedjuju metodi UploadFilesAndFolders na uplaod                       
                        ListView.SelectedListViewItemCollection nesto = new ListView.SelectedListViewItemCollection(null);
                        bool whasItSuccessful=await myFTPConnection.UploadFilesAndFolders(listviewContentLocalSelectedItems, serverPath);

                        if (!whasItSuccessful)
                        {
                            return;
                        }

                        foreach (ListViewItem item in listviewContentLocalSelectedItems) //generiranje novih nodova na server treeviewu 
                        {
                            string loacalPath = (string)item.Tag;
                            GeneriranjeServerTreeViewa.GeneriranjeNovihTreeNodovaPrilikomUploada(loacalPath, serverPath, myFTPConnection, treeView_Server);
                        }
                       
                    }
                    else
                    {
                        // ako nema selektiranih itema u localListViewu onda se uploada folder selektiran u localTreeViewu
                        string localPath = treeView_lokalniDiskovi.SelectedNode.Name;
                        bool whasItSuccessful = await myFTPConnection.UploadFilesAndFolders((ExtendedTreeNode)treeView_lokalniDiskovi.SelectedNode, serverPath);

                        if (!whasItSuccessful)
                        {
                            return;
                        }
                        
                        GeneriranjeServerTreeViewa.GeneriranjeNovihTreeNodovaPrilikomUploada(localPath, serverPath, myFTPConnection, treeView_Server); //generiranje novog/novih node/nodova na server treeviewu
                    }


                    //********   DODAVANJE UPLOADANIH ITEMA U SERVER LISTVIEW *******************

                    // ako je selektirani nod upravo upload path lokalnih fileova/foldera onda odmah prikazujemo uploadane fileove/foldere u serverListViewu
                    if (serverPath.Equals(treeView_Server.SelectedNode.Name))
                    {
                        if (listviewContentLocalSelectedItems.Count > 0) // ako su selektirani fileovi/folderi u localListViewu
                        {
                            foreach (ListViewItem item in listviewContentLocalSelectedItems)
                            {
                                ListViewItem newItem = ListView_Content.KreiranjeListViewItemaServer((string)item.Tag, serverPath, imageList_ListViewContent); // kreiramo novi ListViewItem za svaki oznaceni file u localListViewu
                                ServerDictionary.ServerUploadNewItem(serverPath, newItem); // dodajemo novi item u SeverDictionary

                                bool doesListContainsNewItem = false; //Nisam koristio ContainsKey jer od pocetka nisam dao dobru definiciju ListViewItem.Name-u

                                foreach (ListViewItem lvi in listviewContentServer.Items)
                                {
                                    if (lvi.Tag.Equals(newItem.Tag))
                                    {
                                        doesListContainsNewItem = true;
                                        break;
                                    }
                                }

                                if (doesListContainsNewItem == false)
                                {
                                    listviewContentServer.Items.Add(newItem);
                                }
                            }
                        }
                        else // ako je selektiran samo nod (folder) u localTreeViewu
                        {
                            ListViewItem newItem = ListView_Content.KreiranjeListViewItemaServer(treeView_lokalniDiskovi.SelectedNode.Name, serverPath, imageList_ListViewContent);
                            ServerDictionary.ServerUploadNewItem(serverPath, newItem);

                            bool doesListContainsNewItem = false;

                            foreach (ListViewItem lvi in listviewContentServer.Items)
                            {
                                if (lvi.Tag.Equals(newItem.Tag))
                                {
                                    doesListContainsNewItem = true;
                                    break;
                                }
                            }

                            if (doesListContainsNewItem == false)
                            {
                                listviewContentServer.Items.Add(newItem);
                            }
                        }
                    }
                    else
                    {
                        if (listviewContentLocalSelectedItems.Count > 0)
                        {
                            foreach (ListViewItem item in listviewContentLocalSelectedItems)
                            {
                                ListViewItem newItem = ListView_Content.KreiranjeListViewItemaServer((string)item.Tag, serverPath, imageList_ListViewContent);
                                ServerDictionary.ServerUploadNewItem(serverPath, newItem);
                            }
                        }
                        else
                        {
                            ListViewItem newItem = ListView_Content.KreiranjeListViewItemaServer(treeView_lokalniDiskovi.SelectedNode.Name, serverPath, imageList_ListViewContent);
                            ServerDictionary.ServerUploadNewItem(serverPath, newItem);
                        }
                    }

                    IspisPoruka("Upload je završen ... ", VrstaPoruke.Neutralno);
                }
            }
            catch (Exception ex)
            {
                IspisPoruka(ex.Message, VrstaPoruke.Pogreska);
            }
        }














        public async Task UploadFromOtherSourceToServerListView(string[] dataSource, string serverPath)
        {
            try
            {
                IspisPoruka("STATUS: Upload u tijeku ... ", VrstaPoruke.Neutralno);
                List<ListViewItem> list = new List<ListViewItem>();

                foreach (string pathLocal in dataSource)
                {
                    ListViewItem newItem = ListView_Content.KreiranjeListViewItemaLocal(pathLocal, this);
                    list.Add(newItem);
                }

                await myFTPConnection.UploadFilesAndFolders(list, serverPath);

                int counter = 0;

                foreach (ListViewItem item in list)
                {
                    string loacalPath = dataSource[counter];
                    counter++;
                    GeneriranjeServerTreeViewa.GeneriranjeNovihTreeNodovaPrilikomUploada(loacalPath, serverPath, myFTPConnection, treeView_Server);

                    if (serverPath.Equals(treeView_Server.SelectedNode.Name))
                    {
                        ListViewItem newItem = ListView_Content.KreiranjeListViewItemaServer((string)item.Tag, serverPath, imageList_ListViewContent); // kreiramo novi ListViewItem za svaki oznaceni file u localListViewu
                        ServerDictionary.ServerUploadNewItem(serverPath, newItem); // dodajemo novi item u SeverDictionary

                        bool doesListContainsNewItem = false; //Nisam koristio ContainsKey jer od pocetka nisam dao dobru definiciju ListViewItem.Name-u

                        foreach (ListViewItem lvi in listviewContentServer.Items)
                        {
                            if (lvi.Tag.Equals(newItem.Tag))
                            {
                                doesListContainsNewItem = true;
                                break;
                            }
                        }

                        if (doesListContainsNewItem == false)
                        {
                            listviewContentServer.Items.Add(newItem);
                        }
                    }
                }            
                IspisPoruka("Upload je završen ... ", VrstaPoruke.Neutralno);
            }
            catch (Exception ex)
            {
                IspisPoruka(ex.Message, VrstaPoruke.Pogreska);
            }
        }


        //-----------------------------------------------------------------------------------------------------------------------------------------


        private async void button_IzbrisiSaServera_Click(object sender, EventArgs e)
        {
            await IzbrisiSaServera();
        }




        public async Task IzbrisiSaServera()
        {
            try
            {
                if (myFTPConnection != null)
                {    
                    ListView.SelectedListViewItemCollection selectedItems = listviewContentServer.SelectedItems;

                    if (selectedItems.Count > 0) // ako su selektirani folderi/fileovi u serverListViewu
                    {
                        Task task1 = new Task(() => BrisanjeSListViewaServer(selectedItems));
                        task1.Start();
                        await task1;
                    }
                    else    //ako je selektiran folder u treeviewu
                    {
                        ExtendedTreeNode selectedNode = (ExtendedTreeNode)treeView_Server.SelectedNode;

                        Task task2 = new Task(() => BrisanjeSTreeViewaServer(selectedNode));
                        task2.Start();
                        await task2;
                    }

                    IspisPoruka("Brisanje je završeno.", VrstaPoruke.Neutralno);
                }
            }
            catch (Exception ex)
            {
                IspisPoruka(ex.Message, VrstaPoruke.Pogreska);
            }
        }






        public void BrisanjeSListViewaServer(ListView.SelectedListViewItemCollection selectedItems)
        {
            DialogBoxBrisanjeDatoteke dbx = new DialogBoxBrisanjeDatoteke();
            DialogResult result = dbx.ShowDialog(this);


            if (result == DialogResult.OK)
            {
                IspisPoruka("Brisanje u tijeku ... ", VrstaPoruke.Neutralno);
                myFTPConnection.DeleteFilesOnServer(selectedItems);

                foreach (ListViewItem item in selectedItems)
                {
                    if (((string)item.Name).Equals("True")) // ako brisemo folder/direktorij
                    {
                        item.Remove();  // brise se u listviewu (server)

                        if (treeView_Server.Nodes.Find((string)item.Tag, true).Count() > 0)
                        {
                            ExtendedTreeNode nodeToDelete = (ExtendedTreeNode)treeView_Server.Nodes.Find((string)item.Tag, true)[0];
                            nodeToDelete.Remove(); // brise se takodjer i u treeviewu (server) jer radi se o folderu
                        }
                        else
                        {
                            // ovo je us lucaju ako child treenode od selected treeview noda jos nije bilo generirano (nije bilo ekspandirano)
                            treeView_Server.SelectedNode.Nodes.Clear();
                        }

                    }
                    else  // ako brisemo file
                    {
                        item.Remove(); // brise se u listviewu (server)
                    }

                    string ItemToDelete = (string)item.Tag;
                    string key = treeView_Server.SelectedNode.Name;
                    ServerDictionary.ServerDeleteItem(key, ItemToDelete);                    
                }
            }
        }






        public void BrisanjeSTreeViewaServer(ExtendedTreeNode treeNodeToDelete)
        {
            DialogBoxBrisanjeDatoteke dbx = new DialogBoxBrisanjeDatoteke();
            DialogResult result = dbx.ShowDialog(this);
            
            if (result == DialogResult.OK)
            {
                IspisPoruka("Brisanje u tijeku ... ", VrstaPoruke.Neutralno);

                myFTPConnection.DeleteFilesOnServer(treeNodeToDelete);
                string itemToDelete = treeNodeToDelete.Name;
                string key = treeNodeToDelete.Parent.Name;
                ServerDictionary.ServerDeleteItem(key, itemToDelete);

                treeView_Server.SelectedNode.Remove(); // brisanje itema (foldera) u treeviewu

                IspisPoruka("Brisanje je završeno.", VrstaPoruke.Neutralno);
            }
        }









        //-----------------------------------------------------------------------------------------------------------------------------------------


        private async Task NoviFolder()
        {
            DialogBoxNewFolderServer dlgNewFolderServer = new DialogBoxNewFolderServer();
            dlgNewFolderServer.StartPosition = FormStartPosition.CenterScreen;
            dlgNewFolderServer.textBox_imeNovogFoldera.Text = treeView_Server.SelectedNode.Name + "/NoviFolder";
            dlgNewFolderServer.textBox_imeNovogFoldera.Select(dlgNewFolderServer.textBox_imeNovogFoldera.Text.LastIndexOf("/") + 1, 10); //selektiran je samo dio teksta koji se odnosi na ime novog foldera
            this.Enabled = false;

            DialogResult result = dlgNewFolderServer.ShowDialog(this);
            this.Enabled = true;

            if (result == DialogResult.OK)
            {
                string pathNovogFoldera = dlgNewFolderServer.textBox_imeNovogFoldera.Text;

                try
                {
                    if (myFTPConnection != null)
                    {
                        if (treeView_Server.Nodes.Find(pathNovogFoldera, true).Count() == 0) //Ako postoji nod s tim nameom onda se ne kreira novi folder
                        {
                            string imeFoldera = pathNovogFoldera.Substring(pathNovogFoldera.LastIndexOf("/") + 1);
                            string path = pathNovogFoldera.Substring(0, pathNovogFoldera.LastIndexOf("/"));

                            Task task1 = new Task(() => CreatingNoviFolderServer(path, imeFoldera));
                            task1.Start();
                            await task1;


                            ExtendedTreeNode node = (ExtendedTreeNode)treeView_Server.SelectedNode;

                            try
                            {
                                ExtendedTreeNode nodeWhereToInsert = (ExtendedTreeNode)treeView_Server.Nodes.Find(path, true)[0];

                                if (treeView_Server.SelectedNode.Name.Equals(path))
                                {
                                    ListView_Content.DodavanjeNovokreiranogFolderaListView(listviewContentServer, nodeWhereToInsert.Name, imeFoldera);      // dodajem novi folder u LISTVIEW 
                                }

                                ExtendedTreeNode newNode = GeneriranjeServerTreeViewa.KreiranjeNovogTreeNoda(nodeWhereToInsert.Name, imeFoldera);  // dodajem novi folder u TREEVIEW
                                nodeWhereToInsert.Nodes.Add(newNode);

                                ListViewItem noviFolderItem = ListView_Content.NoviFolderListViewItem(pathNovogFoldera);
                                ServerDictionary.ServerUploadNewItem(pathNovogFoldera.Substring(0, pathNovogFoldera.LastIndexOf("/")), noviFolderItem);
                            }
                            catch (Exception)
                            {
                                treeView_Server.SelectedNode = node;
                                return;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Folder odabranog imena već postoji! Odaberite drugo ime.");
                            return;
                        }
                    }
                    else
                    {
                        throw new Exception("Pogreška: Potrebno se spojiti na server.");
                    }
                }
                catch (Exception ex)
                {
                    IspisPoruka(ex.Message, VrstaPoruke.Pogreska);
                }
            }
        }









        public void CreatingNoviFolderServer(string path, string imeFoldera)
        {
            try
            {
                myFTPConnection.CreateNewFolderOnServer(path, imeFoldera);
            }
            catch (Exception ex)
            {
                IspisPoruka(ex.Message, VrstaPoruke.Pogreska);
            }
        }




        //-----------------------------------------------------------------------------------------------------------------------------------------

        private async void button_download_Click(object sender, EventArgs e)
        {
            await DownloadFilesAndFolders();
        }



        private async Task DownloadFilesAndFolders(string pathWhereToDownload = null, List<ListViewItem> dataToTransfer_listview=null, TreeNode dataToTransfer_treenode=null)
        {
            try
            {
                ListView.SelectedListViewItemCollection itemsSelectedServer = listviewContentServer.SelectedItems; // selectirani fileovi na serveru
                ExtendedTreeNode selectedTreeNodeServer = (ExtendedTreeNode)treeView_Server.SelectedNode;

                if (pathWhereToDownload == null) // ako downloadam preko buttona download
                {
                    folderBrowserDialog1.SelectedPath = treeView_lokalniDiskovi.SelectedNode.Name;
                    folderBrowserDialog1.Description = "Odabir foldera za preuzimanje odabranih datoteka sa servera";
                    DialogResult result = folderBrowserDialog1.ShowDialog();
                    string pathLocal = folderBrowserDialog1.SelectedPath;


                    if (result == DialogResult.OK)
                    {
                        IspisPoruka("Preuzimanje u tijeku ... ", VrstaPoruke.Neutralno);

                        if (itemsSelectedServer.Count > 0) // selectirani fileovi na serveru
                        {
                            Task task1 = new Task(() => myFTPConnection.DownloadFilesAndFolders(pathLocal, itemsSelectedServer));
                            task1.Start();
                            await task1;
                        }
                        else
                        {
                            Task task1 = new Task(() => myFTPConnection.DownloadFilesAndFolders(pathLocal, selectedTreeNodeServer));
                            task1.Start();
                            await task1;
                        }



                        TreeNode[] nodes = treeView_lokalniDiskovi.Nodes.Find(pathLocal, true);

                        if (nodes.Count() == 1)
                        {
                            if (nodes[0].IsSelected)
                            {
                                if (itemsSelectedServer.Count > 0) // preuzima se sadrzaj selektiran u server listviewu
                                {
                                    foreach (ListViewItem item in itemsSelectedServer)
                                    {
                                        if (item.Name.Equals("True")) // radi se o downloadu foldera
                                        {
                                            ExtendedTreeNode newNode = DirectoryTreeViewLocalDisk.KreiranjeNovogTreeNoda(pathLocal, item.Text);
                                            nodes[0].Nodes.Add(newNode);
                                            ListViewItem newItem = ListView_Content.KreiranjeNovogListViewItemaLocal(pathLocal, item);
                                            listviewContentLocal.Items.Add(newItem);
                                        }
                                        else // radi se o downloadu datoteke
                                        {
                                            ListViewItem newItem = ListView_Content.KreiranjeNovogListViewItemaLocal(pathLocal, item);
                                            listviewContentLocal.Items.Add(newItem);
                                        }
                                    }
                                }
                                else // preuzima se sadrzaj selektiran u server treeviewu
                                {
                                    ExtendedTreeNode newNode = DirectoryTreeViewLocalDisk.KreiranjeNovogTreeNoda(pathLocal, selectedTreeNodeServer.Text);
                                    nodes[0].Nodes.Add(newNode);
                                    ListViewItem newItem = ListView_Content.KreiranjeNovogListViewItemaLocal(pathLocal, null, selectedTreeNodeServer);
                                    listviewContentLocal.Items.Add(newItem);
                                }
                            }
                            else if (nodes[0].Parent.IsExpanded)
                            {
                                if (itemsSelectedServer.Count > 0)
                                {
                                    foreach (ListViewItem item in itemsSelectedServer)
                                    {
                                        if (item.Name.Equals("True")) // radi se o downloadu foldera
                                        {
                                            ExtendedTreeNode newNode = DirectoryTreeViewLocalDisk.KreiranjeNovogTreeNoda(pathLocal, item.Text);
                                            nodes[0].Nodes.Add(newNode);
                                        }
                                    }
                                }
                                else
                                {
                                    ExtendedTreeNode newNode = DirectoryTreeViewLocalDisk.KreiranjeNovogTreeNoda(pathLocal, selectedTreeNodeServer.Text);
                                    nodes[0].Nodes.Add(newNode);
                                }
                            }
                        }

                        IspisPoruka("Fileovi/folderu su uspješni preuzeti.", VrstaPoruke.Neutralno);
                    }
                }
                else // ako downloadam preko drag&drop
                {
                    folderBrowserDialog1.SelectedPath = pathWhereToDownload;
                    folderBrowserDialog1.Description = "Odabir foldera za preuzimanje odabranih datoteka sa servera";
                    DialogResult result = folderBrowserDialog1.ShowDialog();
                    string pathLocal = folderBrowserDialog1.SelectedPath;

                    IspisPoruka("Preuzimanje u tijeku ... ", VrstaPoruke.Neutralno);




                    TreeNode[] nodes = treeView_lokalniDiskovi.Nodes.Find(pathLocal, true);


                    if (dataToTransfer_listview != null)
                    {
                        Task task2 = new Task(() => myFTPConnection.DownloadFilesAndFolders(pathLocal, dataToTransfer_listview));
                        task2.Start();
                        await task2;


                        if (nodes.Count() == 1)
                        {
                            if (nodes[0].IsSelected)
                            {
                                foreach (ListViewItem item in dataToTransfer_listview)
                                {
                                    if (item.Name.Equals("True"))
                                    {
                                        ExtendedTreeNode newNode = DirectoryTreeViewLocalDisk.KreiranjeNovogTreeNoda(pathLocal, item.Text);
                                        nodes[0].Nodes.Add(newNode);
                                        ListViewItem newItem = ListView_Content.KreiranjeNovogListViewItemaLocal(pathLocal, item);
                                        listviewContentLocal.Items.Add(newItem);
                                    }
                                    else
                                    {
                                        ListViewItem newItem = ListView_Content.KreiranjeNovogListViewItemaLocal(pathLocal, item);
                                        listviewContentLocal.Items.Add(newItem);
                                    }
                                }
                            }
                            else if (nodes[0].Parent.IsExpanded)
                            {
                                foreach (ListViewItem item in dataToTransfer_listview)
                                {
                                    if (item.Name.Equals("True")) // radi se o downloadu foldera
                                    {
                                        ExtendedTreeNode newNode = DirectoryTreeViewLocalDisk.KreiranjeNovogTreeNoda(pathLocal, item.Text);
                                        nodes[0].Nodes.Add(newNode);
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        Task task2 = new Task(() => myFTPConnection.DownloadFilesAndFolders(pathLocal, (ExtendedTreeNode)dataToTransfer_treenode));
                        task2.Start();
                        await task2;


                        if (nodes.Count() == 1)
                        {
                            if (nodes[0].IsSelected)
                            {
                                ExtendedTreeNode newNode = DirectoryTreeViewLocalDisk.KreiranjeNovogTreeNoda(pathLocal, dataToTransfer_treenode.Text);
                                nodes[0].Nodes.Add(newNode);
                                ListViewItem newItem = ListView_Content.KreiranjeNovogListViewItemaLocal(pathLocal, node: dataToTransfer_treenode);
                                listviewContentLocal.Items.Add(newItem);
                            }
                            else if (nodes[0].Parent.IsExpanded)
                            {
                                ExtendedTreeNode newNode = DirectoryTreeViewLocalDisk.KreiranjeNovogTreeNoda(pathLocal, dataToTransfer_treenode.Text);
                                nodes[0].Nodes.Add(newNode);
                            }

                        }
               
                    }
                }

                IspisPoruka("Fileovi/folderu su uspješni preuzeti.", VrstaPoruke.Neutralno);
            }
            catch (Exception ex)
            {
                IspisPoruka(ex.Message, VrstaPoruke.Pogreska);
            }
        }




        //-----------------------------------------------------------------------------------------------------------------------------------------





        private void IspisPoruka(string message, VrstaPoruke messageType)
        {
            if (messageType==VrstaPoruke.OK)
            {
                richTextBox_FTPDisplay.SelectionColor = Color.Green;
                richTextBox_FTPDisplay.AppendText("STATUS: " + message + "\n");
                richTextBox_FTPDisplay.SelectionStart = richTextBox_FTPDisplay.Text.Length;
                richTextBox_FTPDisplay.ScrollToCaret();
            }
            else if (messageType==VrstaPoruke.Pogreska)
            {
                richTextBox_FTPDisplay.SelectionColor = Color.Red;
                richTextBox_FTPDisplay.AppendText("POGRESKA: " + message + "\n");
                richTextBox_FTPDisplay.SelectionStart = richTextBox_FTPDisplay.Text.Length;
                richTextBox_FTPDisplay.ScrollToCaret();
            }
            else if (messageType==VrstaPoruke.Neutralno)
            {
                richTextBox_FTPDisplay.SelectionColor = Color.Blue;
                richTextBox_FTPDisplay.AppendText("STATUS: " + message + "\n");
                richTextBox_FTPDisplay.SelectionStart = richTextBox_FTPDisplay.Text.Length;
                richTextBox_FTPDisplay.ScrollToCaret();
            }
        }


        //-----------------------------------------------------------------------------------------------------------------------------------------

        enum VrstaPoruke
        {
            OK,
            Pogreska,
            Neutralno
        }




        /*================================================================================================================================
                                                D R A G   A N D  D R O P  O P E R A C I J E
        ================================================================================================================================*/



        // **********************  LOCAL  **************************************

        private void listviewContentLocal_ItemDrag(object sender, ItemDragEventArgs e)
        {
            List<ListViewItem> itemsList = new List<ListViewItem>();

            foreach (ListViewItem item in listviewContentLocal.SelectedItems)
            {
                itemsList.Add(item);
            }

            listviewContentLocal.DoDragDrop(itemsList, DragDropEffects.All);            
        }


        //--------------------------------------------------------------------------------------------------------------------------------

        private void listviewContentLocal_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }


        //--------------------------------------------------------------------------------------------------------------------------------

        private async void listviewContentLocal_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(List<ListViewItem>)) || e.Data.GetDataPresent(typeof(ExtendedTreeNode)))
            {
                string whoSentData;
                List<ListViewItem> dataToTransfer_listview=null;
                ExtendedTreeNode dataToTransfer_treenode =null;

                if (e.Data.GetDataPresent(typeof(List<ListViewItem>)))
                {
                    dataToTransfer_listview = (List<ListViewItem>)e.Data.GetData(typeof(List<ListViewItem>));
                    whoSentData = dataToTransfer_listview[0].ListView.Name;
                }
                else
                {
                    dataToTransfer_treenode = (ExtendedTreeNode)e.Data.GetData(typeof(ExtendedTreeNode));
                    whoSentData = dataToTransfer_treenode.TreeView.Name;
                }



                // apsolutne koordinate glavne forme
                int formLocationX = this.Location.X;
                int formLocationY = this.Location.Y;

                // apsolutne koordnate listviewa
                int lvLocationX = listviewContentLocal.Location.X;
                int lvLocationY = listviewContentLocal.Location.Y;

                // odredjujem koordinate potrebne za odredjivanje serverListViewItema na koji je dropan sadrzaj
                int X = e.X - formLocationX - lvLocationX - 16;
                int Y = e.Y - formLocationY - lvLocationY - 32;

                ListViewHitTestInfo info = listviewContentLocal.HitTest(X, Y);


                if (whoSentData == "listviewContentLocal")
                {
                    return;
                }

                try
                {
                    string localPath;

                    if (info.Item != null)
                    {
                        localPath = myFTPConnection.CheckUploadPath(info.Item);
                    }
                    else
                    {
                        localPath = treeView_lokalniDiskovi.SelectedNode.Name;
                    }



                    if (dataToTransfer_listview!=null)
                    {
                        await DownloadFilesAndFolders(localPath, dataToTransfer_listview: dataToTransfer_listview);
                    }
                    else
                    {
                        await DownloadFilesAndFolders(localPath, dataToTransfer_treenode: dataToTransfer_treenode);
                    }


                }
                catch (Exception ex)
                {
                    IspisPoruka(ex.Message, VrstaPoruke.Pogreska);
                }
            }
        }

        //--------------------------------------------------------------------------------------------------------------------------------

        private void treeView_lokalniDiskovi_ItemDrag(object sender, ItemDragEventArgs e)
        {
            List<TreeNode> itemsList = new List<TreeNode>();
            itemsList.Add(treeView_lokalniDiskovi.SelectedNode);
            listviewContentLocal.DoDragDrop(itemsList, DragDropEffects.All);
        }


        //--------------------------------------------------------------------------------------------------------------------------------

        // ******************    SERVER  *****************************

        private void listviewContentServer_DragDrop(object sender, DragEventArgs e)
        {
            try
            {
                if (e.Data.GetDataPresent(typeof(List<ListViewItem>)) || e.Data.GetDataPresent(typeof(List<TreeNode>)) || e.Data.GetDataPresent(DataFormats.FileDrop))
                {

                    int formLocationX = this.Location.X;
                    int formLocationY = this.Location.Y;

                    int lvLocationX = listviewContentServer.Location.X;
                    int lvLocationY = listviewContentServer.Location.Y;

                    // odredjujem koordinate potrebne za odredjivanje serverListViewItema na koji je dropan sadrzaj
                    int X = e.X - formLocationX - lvLocationX - 16;
                    int Y = e.Y - formLocationY - lvLocationY - 32;

                    ListViewHitTestInfo info = listviewContentServer.HitTest(X, Y);
                    string serverPath;

                    if (myFTPConnection != null)
                    {      
                        if (info.Item != null)
                        {
                            serverPath = myFTPConnection.CheckUploadPath(info.Item);
                        }
                        else
                        {
                            serverPath = treeView_Server.SelectedNode.Name;
                        }                        
                    }
                    else
                    {
                        IspisPoruka("Potrebno je spojiti se na server!", VrstaPoruke.Pogreska);
                        return;
                    }



                    string whoSentData = null;
                    Action howToUpdate;

                    if (e.Data.GetDataPresent(typeof(List<ListViewItem>)))
                    {
                        List<ListViewItem> dataToTransfer = (List<ListViewItem>)e.Data.GetData(typeof(List<ListViewItem>));
                        howToUpdate = new Action(() => UploadFilesAndFolders(serverPath));
                        whoSentData = dataToTransfer[0].ListView.Name;
                    }
                    else if (e.Data.GetDataPresent(typeof(List<TreeNode>)))
                    {
                        List<TreeNode> dataToTransfer = (List<TreeNode>)e.Data.GetData(typeof(List<TreeNode>));
                        howToUpdate = new Action(() => UploadFilesAndFolders(serverPath));
                        whoSentData = dataToTransfer[0].TreeView.Name;
                    }
                    else if (e.Data.GetDataPresent(DataFormats.FileDrop))
                    {
                        string[] dataToTransfer = (string[])e.Data.GetData(DataFormats.FileDrop);
                        howToUpdate = new Action(() => UploadFromOtherSourceToServerListView(dataToTransfer, serverPath));
                        whoSentData = "OuterSource";
                    }
                    else
                    {
                        return;
                    }


                    if (whoSentData == "listviewContentServer")
                    {
                        return;
                    }
                    else
                    {
                        howToUpdate();
                    }
                }
                else
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                IspisPoruka(ex.Message, VrstaPoruke.Pogreska);
            }
        }


        //--------------------------------------------------------------------------------------------------------------------------------


        private void listviewContentServer_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }



        //--------------------------------------------------------------------------------------------------------------------------------

        private void listviewContentServer_ItemDrag(object sender, ItemDragEventArgs e)
        {
            List<ListViewItem> itemsList = new List<ListViewItem>();

            foreach (ListViewItem item in listviewContentServer.SelectedItems)
            {
                itemsList.Add(item);
            }

            listviewContentServer.DoDragDrop(itemsList, DragDropEffects.All);
        }


        //--------------------------------------------------------------------------------------------------------------------------------


        private void treeView_Server_ItemDrag(object sender, ItemDragEventArgs e)
        {
            ExtendedTreeNode item = new ExtendedTreeNode();
            item = (ExtendedTreeNode)e.Item;
            listviewContentLocal.DoDragDrop(item, DragDropEffects.All);
        }






























        private void Form_Glavna_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.pathLastSavedFile = formFTPSpajanje.pathLastSavedFile;
            Properties.Settings.Default.Save();
            Environment.Exit(0);
        }






        private void oProgramuToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FormOProgramu forma = new FormOProgramu();
            forma.Show(this);
        }

        private void oAutoruToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormOAutoru forma = new FormOAutoru();
            forma.Show(this);
        }

        private void izlazToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.pathLastSavedFile = formFTPSpajanje.pathLastSavedFile;
            Properties.Settings.Default.Save();
            Environment.Exit(0);
        }







        private void Form_Glavna_Resize(object sender, EventArgs e)
        {
            FormResizing.Resize(this);
        }






























































































        //--------------------------------------------------------------------------------------------------------------------------------



    }
}
