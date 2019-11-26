using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FTPKlijent
{
    static class ListView_Content
    {

        //********************************************************************************************************************
        //                                                  L O K A L N O
        //********************************************************************************************************************


        public static void ShowContentLocal(ListView listviewContentLocal, string path, IWin32Window owner)
        {
            listviewContentLocal.Items.Clear(); //brise prethodni prikaz listviewa

            if (path == Environment.MachineName)
            {
                string[] drives = Environment.GetLogicalDrives();

                foreach (var drive in drives)
                {
                    DriveInfo myDrive = new DriveInfo(drive);

                    if (myDrive.IsReady)
                    {
                        ListViewItem lvi = new ListViewItem(myDrive.Name);
                        lvi.SubItems.Add(Convert.ToString(myDrive.TotalFreeSpace / 1024));
                        lvi.SubItems.Add("Lokalni disk");
                        lvi.SubItems.Add("-");
                        lvi.Tag = myDrive.Name;
                        lvi.ImageIndex = 0;

                        listviewContentLocal.Items.Add(lvi);
                    }
                }
            }
            else
            {
                try
                {
                    if (Directory.Exists(path))
                    {
                        string[] subdirectories = Directory.GetDirectories(path);
                        string[] files = Directory.GetFiles(path);

                        foreach (string pathLocal in subdirectories)
                        { 
                            ListViewItem item=KreiranjeListViewItemaLocal(pathLocal, owner);
                            listviewContentLocal.Items.Add(item);
                        }


                        foreach (string pathLocal in files)
                        {
                            ListViewItem item = KreiranjeListViewItemaLocal(pathLocal, owner);
                            listviewContentLocal.Items.Add(item);
                        }
                    }
                    else
                    {
                        throw new ApplicationException("Lokalni folder/file ne postoji. Pokušajte osvježiti prikaz.");
                    }
                }
                catch (ApplicationException ae)
                {
                    throw new ApplicationException(ae.Message);
                }
                catch (Exception e) 
                {
                    throw new Exception(e.Message);             
                }
            }
        }

        



        public static ListViewItem KreiranjeListViewItemaLocal(string pathLocal, IWin32Window owner)
        {
            FileAttributes attr = File.GetAttributes(pathLocal);

            if (attr.HasFlag(FileAttributes.Directory)) // kreiranje ListViewItema ako se radi o direktoriju/folderu
            {
                DirectoryInfo dirInfo = new DirectoryInfo(pathLocal);        // kompletni path direktorija

                ListViewItem lvi = new ListViewItem(dirInfo.Name);           // samo ime foldera
                lvi.SubItems.Add("0");                                       // za velicinu foldera ispisujemo 0
                lvi.SubItems.Add("Direktorij");                              // ispisuje se samo inf. da se radi o direktoriju
                lvi.SubItems.Add(Convert.ToString(dirInfo.LastWriteTime));   // last modified direktorija
                lvi.Name = "True";                                           // da li je direktorij?
                lvi.Tag = pathLocal;
                lvi.ImageIndex = 1;

                return lvi;
            }
            else // kreiranje ListViewItema ako se radi o fileu
            {
                FileInfo fileInfo = new FileInfo(pathLocal);                     //kompletni path filea
                Icon fileIcon = SystemIcons.WinLogo;
                fileIcon = Icon.ExtractAssociatedIcon(fileInfo.FullName);

                if (!((Form_Glavna)owner).imageList_ListViewContent.Images.ContainsKey(fileInfo.Extension))
                {
                    ((Form_Glavna)owner).imageList_ListViewContent.Images.Add(fileInfo.Extension, fileIcon);
                }

                ListViewItem lvi = new ListViewItem(fileInfo.Name);         // samo ime filea
                lvi.SubItems.Add(Convert.ToString(fileInfo.Length / 1024)); // velicina filea
                lvi.SubItems.Add(fileInfo.Extension);                       // tip filea
                lvi.SubItems.Add(Convert.ToString(fileInfo.LastWriteTime)); // last modified filea
                lvi.Tag = pathLocal;
                lvi.Name = "False";                                         // da li je direktorij?
                lvi.ImageKey = fileInfo.Extension;

                return lvi;
            }

                
        }




        public static ListViewItem KreiranjeNovogListViewItemaLocal(string localPath, ListViewItem itemKojiSePreuzima = null, TreeNode node = null)
        {
            ListViewItem lvi;

            if (node == null)
            {
                lvi = new ListViewItem(itemKojiSePreuzima.Text);           // ime filea/dir

                if (itemKojiSePreuzima.Name.Equals("True"))
                {
                    lvi.SubItems.Add("0"); // velicina
                    lvi.SubItems.Add(""); // ekstenzija
                    lvi.Name = "True";
                    lvi.Tag = localPath + "\\" + itemKojiSePreuzima.Text;
                    lvi.ImageIndex = 1;
                }
                else
                {
                    lvi.SubItems.Add(itemKojiSePreuzima.SubItems[1]); // velicina
                    lvi.SubItems.Add(itemKojiSePreuzima.SubItems[2]); // ekstenzija
                    lvi.Name = "False";
                    lvi.Tag = localPath + "\\" + itemKojiSePreuzima.Text;
                    lvi.ImageKey = itemKojiSePreuzima.ImageKey;
                }
            }
            else
            {
                lvi = new ListViewItem(node.Text);
                lvi.SubItems.Add("0"); // velicina
                lvi.SubItems.Add(""); // ekstenzija
                lvi.Name = "True";
                lvi.Tag = localPath + "\\" + node.Text;
                lvi.ImageIndex = 1;
            }
        

            return lvi;                                                   

            
        }






        //********************************************************************************************************************
        //                                                  S E R V E R
        //********************************************************************************************************************

        public static void ShowContentServer(ListView listViewContentServer, string path, FTPConnection2 myConnection, IWin32Window owner)
        {
            listViewContentServer.Items.Clear();//brise prethodni prikaz listviewa

            try
            {
                    List<string[]> subdirectories1 = myConnection.GetDirectoriesAndFiles(path);

                    foreach (string[] dir in subdirectories1)
                    {
                        ListViewItem lvi = new ListViewItem(dir[0]);                        // ime filea/dir                        item[0] = fileInfo.Name; 
                        lvi.SubItems.Add(Convert.ToString(Convert.ToInt64(dir[1]) / 1024)); // velicina                             item[1] = Convert.ToString(fileInfo.Length);
                        lvi.SubItems.Add(dir[2]);                                           // ekstenzija                           item[2] = Path.GetExtension(fileInfo.Name);
                        lvi.SubItems.Add(dir[3]);                                           // last modified                        item[3] = Convert.ToString(fileInfo.LastWriteTime);
                        lvi.Name = dir[4];                                                  // da li je direktorij?                 item[4] = Convert.ToString(fileInfo.IsDirectory);
                        lvi.Tag = dir[5];                                                   // kompletni path filea/dir             item[5] = fileInfo.FullName;


                        if (dir[4].Equals("True")) // radi se o folderu
                        {
                            lvi.ImageIndex = 1;
                        }
                        else
                        {
                            if (((Form_Glavna)owner).imageList_ListViewContent.Images.ContainsKey(dir[2]))
                            {
                                lvi.ImageKey = dir[2];
                            }
                            else
                            {
                                try
                                {
                                    Icon fileIcon = Icons.IconFromExtension(dir[2], Icons.SystemIconSize.Small);
                                    ((Form_Glavna)owner).imageList_ListViewContent.Images.Add(dir[2], fileIcon);
                                    lvi.ImageKey = dir[2];

                                }
                                catch (Exception)
                                {

                                    lvi.ImageIndex = 2;
                                }
 
                            }
                        }

                        listViewContentServer.Items.Add(lvi);
                    }               
            }
            catch (Exception e)
            {                
                throw new Exception(e.Message);
            }
        }







        public static void DodavanjeNovokreiranogFolderaListView(ListView listview, string folderServerPath, string folderName)
        {
            ListViewItem lvi = new ListViewItem(folderName);                        // ime filea/dir
            lvi.SubItems.Add("0");                                                  // velicina
            lvi.SubItems.Add("");                                                   // ekstenzija
            lvi.SubItems.Add(Convert.ToString(DateTime.Now));                       // last modified
            lvi.Tag = folderServerPath+"/"+ folderName;                             // kompletni path filea/dir
            lvi.Name = "True";                                                      // da li je direktorij?
            lvi.ImageIndex = 1;
            listview.Items.Add(lvi);
        }
        

        public static ListViewItem NoviFolderListViewItem(string folderServerPath)
        {
            ListViewItem lvi = new ListViewItem(folderServerPath.Substring(folderServerPath.LastIndexOf("/")+1));                        // ime filea/dir
            lvi.SubItems.Add("0");                                                                                                     // velicina
            lvi.SubItems.Add("");                                                                                                      // ekstenzija
            lvi.SubItems.Add(Convert.ToString(DateTime.Now));                                                                          // last modified
            lvi.Tag = folderServerPath;                                                                                                // kompletni path filea/dir
            lvi.Name = "True";                                                                                                         // da li je direktorij?
            lvi.ImageIndex = 1;

            return lvi;
        }



        public static ListViewItem KreiranjeListViewItemaServer(string pathLocal, string pathServer, ImageList imagelist)
        {
            FileAttributes checkIsItDirectory = File.GetAttributes(pathLocal);

            if (checkIsItDirectory != FileAttributes.Directory)
            {
                FileInfo fileInfo = new FileInfo(pathLocal);

                ListViewItem lvi = new ListViewItem(fileInfo.Name);                        // ime filea/dir
                lvi.SubItems.Add(Convert.ToString(fileInfo.Length / 1024));                // velicina
                lvi.SubItems.Add(fileInfo.Extension);                                      // ekstenzija
                lvi.SubItems.Add(Convert.ToString(fileInfo.LastWriteTime));                // last modified
                lvi.Tag = pathServer + "/" + fileInfo.Name;                                // kompletni path filea/dir na serveru
                lvi.Name = "False";                                                        // da li je direktorij?


                if (imagelist.Images.ContainsKey(lvi.SubItems[2].Text))
                {
                    lvi.ImageKey = lvi.SubItems[2].Text;
                }
                else
                {
                    lvi.ImageIndex = 2;
                }

                return lvi;
            }
            else
            {
                DirectoryInfo dirInfo = new DirectoryInfo(pathLocal);

                ListViewItem lvi = new ListViewItem(dirInfo.Name);                        // ime filea/dir
                lvi.SubItems.Add("0");                                                    // velicina
                lvi.SubItems.Add(dirInfo.Extension);                                      // ekstenzija
                lvi.SubItems.Add(Convert.ToString(dirInfo.LastWriteTime));                // last modified
                lvi.Tag = pathServer + "/" + dirInfo.Name;                                // kompletni path filea/dir na serveru
                lvi.Name = "True";                                                        // da li je direktorij?
                lvi.ImageIndex = 1;

                return lvi;
            }
        }




    }
}
