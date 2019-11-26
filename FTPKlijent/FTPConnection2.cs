using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Cache;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinSCP;

namespace FTPKlijent
{
    class FTPConnection2
    {
        private SessionOptions myConnectionOptions;
        TransferOptions myConnectionTransferOptions;
        public string ErrorMessage { get; set; }
        public static bool ConnectionEstablished = false;

        public SessionOptions MyConnectionOptions
        {
            get
            {
                return myConnectionOptions;
            }
        }

        private RichTextBox richTextBox_FTPDisplay; // da se može ispisivati u rtb prilikom uploada, downloada i brisanja sa servera
        public bool wasConnectionEstablished = false;

        



//------------------------------------------------------------------------------------------------------------------------------------------------------------------------



        public FTPConnection2(string hostname, string username, string password, string portNumber, RichTextBox richTextBox_FTPDisplay, int protocol)
        {
            myConnectionOptions = new SessionOptions();
            myConnectionOptions.HostName = hostname;
            myConnectionOptions.UserName = username;
            myConnectionOptions.Password = password;

            if (string.IsNullOrEmpty(portNumber))
            {
                myConnectionOptions.PortNumber = 0;
            }
            else
            {
                myConnectionOptions.PortNumber = Convert.ToInt16(portNumber);
            }


            switch (protocol)
            {
                case 0:
                    myConnectionOptions.Protocol = Protocol.Ftp;
                    break;
                case 1:
                    myConnectionOptions.Protocol = Protocol.Sftp;                    
                    break;
                case 2:
                    myConnectionOptions.Protocol = Protocol.S3;
                    break;
                case 3:
                    myConnectionOptions.Protocol = Protocol.Scp;
                    break;
                case 4:
                    myConnectionOptions.Protocol = Protocol.Webdav;
                    break;
                default:
                    myConnectionOptions.Protocol = Protocol.Ftp;
                    break;
            }

            
            this.richTextBox_FTPDisplay = richTextBox_FTPDisplay;

            myConnectionTransferOptions = new TransferOptions();
            myConnectionTransferOptions.FileMask = "*";
            myConnectionTransferOptions.OverwriteMode = OverwriteMode.Overwrite;
            myConnectionTransferOptions.TransferMode = TransferMode.Automatic;

        }



        //------------------------------------------------------------------------------------------------------------------------------------------------------------------------



        public List<string[]> GetDirectoriesAndFiles(string path)
        {
            try
            {
                List<string[]> directoriesAndFiles = new List<string[]>();

                using (Session myConnection = new Session())
                {
                    myConnection.Open(MyConnectionOptions);
                    RemoteDirectoryInfo directoryInfo = myConnection.ListDirectory(path);

                    foreach (RemoteFileInfo fileInfo in directoryInfo.Files)
                    {
                        if (fileInfo.Name != "..")
                        {
                            string[] item = new string[6];

                            item[0] = fileInfo.Name;                                    // ime filea/dir
                            item[1] = Convert.ToString(fileInfo.Length);                // veličina filea/dir
                            item[2] = Path.GetExtension(fileInfo.Name);                  // ekstenzija
                            item[3] = Convert.ToString(fileInfo.LastWriteTime);         // last modified
                            item[4] = Convert.ToString(fileInfo.IsDirectory);           // provjeravam radi li se o dir ili fileu

                            if (path.Equals("/"))
                            {
                                item[5] = "/"+fileInfo.FullName;                                // full path 
                            }
                            else
                            {
                                item[5] = fileInfo.FullName;
                            }

                            directoriesAndFiles.Add(item);
                        }
                    }
                }

                return directoriesAndFiles;
            }
            catch (Exception e)
            {
                ErrorMessage = e.Message;
                wasConnectionEstablished = false;
                throw new Exception(ErrorMessage);
            }
        }




        //------------------------------------------------------------------------------------------------------------------------------------------------------------------------


        public string CheckUploadPath(ListViewItem item) // provjeravam da li je kao upload path oznacen file ili direktorij; ako je file onda je upload destinacija path foldera koji sadrzi oznaceni file
        {
            string path= (string)item.Tag;

            if (item.Name.Equals("True"))
            {
                return path;
            }
            else
            {
                return path.Substring(0, path.LastIndexOf("/"));                
            }
        }



        //------------------------------------------------------------------------------------------------------------------------------------------------------------------------


        //**************************************************************************************************
        //                          UPLOAD FOLDERA I FILEOVA NA SERVER

        public async Task<bool> UploadFilesAndFolders(IEnumerable listViewItems, string pathServer)
        {
            try
            {
                using (Session myConnection = new Session())
                {
                    myConnection.Open(MyConnectionOptions);
                    pathServer = pathServer+"/";
                    bool wasItSuccessful=false;

                    foreach (ListViewItem listViewItem in listViewItems)
                    {
                        string pathLocal = (string)listViewItem.Tag;
                        FileAttributes localFileAttribute = File.GetAttributes(pathLocal);

                        if (localFileAttribute == FileAttributes.Directory)
                        {
                            DirectoryInfo localDirInfo = new DirectoryInfo(pathLocal);

                            Task<bool> task2 = new Task<bool>(() => DoesFileExists(pathServer + localDirInfo.Name));
                            task2.Start();
                            bool answer = await task2;

                            if (answer == true)
                            {
                                // pitam da li zelim prebrisati postojeci folder
                                DialogFileFolderOverwrite dialog = new DialogFileFolderOverwrite();
                                dialog.label2.Text = "(" + localDirInfo.Name + ")";
                                DialogResult dialogResult = dialog.ShowDialog();

                                if (dialogResult == DialogResult.Cancel)
                                {
                                    return false;
                                }
                            }
                        }
                        else
                        {
                            FileInfo localFileInfo = new FileInfo(pathLocal);
                            bool answer = DoesFileExists(pathServer + localFileInfo.Name);

                            if (answer == true)
                            {
                                // pitam da li zelim prebrisati postojeci file
                                DialogFileFolderOverwrite dialog = new DialogFileFolderOverwrite();
                                dialog.label2.Text = "(" + localFileInfo.Name + ")";
                                DialogResult dialogResult = dialog.ShowDialog();

                                if (dialogResult == DialogResult.Cancel)
                                {
                                    return false;
                                }
                            }
                        }
                       
                        
                        Task<bool> task1=new Task<bool>(()=>Upload(pathServer, pathLocal, myConnection));
                        task1.Start();
                        wasItSuccessful=await task1;                        
                    }

                    return wasItSuccessful;
                }
            }
            catch (Exception e)
            {
                ErrorMessage = e.Message;
                throw new Exception(e.Message);                
            }
         }




        



        public async Task<bool> UploadFilesAndFolders(ExtendedTreeNode node, string pathServer)
        {
            try
            {
                using (Session myConnection = new Session())
                {
                    myConnection.Open(MyConnectionOptions);
                    pathServer = pathServer + "/";
                    string pathLocal = node.Name;

                    Task<bool> task1 = new Task<bool>(() => Upload(pathServer, pathLocal, myConnection));
                    task1.Start();
                    bool wasItSuccessful = await task1;

                    return wasItSuccessful;
                }
            }
            catch (Exception e)
            {
                ErrorMessage = e.Message;
                throw new Exception(e.Message);
            }
        }








        public bool Upload(string pathServer, string pathLocal, Session myConnection)
        {

            TransferOperationResult result = myConnection.PutFiles(pathLocal, pathServer, false, myConnectionTransferOptions);
            bool wasItSuccessful = result.IsSuccess;

            if (wasItSuccessful == false)
            {
                IspisPoruka("(UPLOAD) " + pathLocal + "nije uploadan!", "Pogreska");
                return wasItSuccessful;
            }
            else
            {
                IspisPoruka("(UPLOAD) " + pathLocal + " ---> " + pathServer, "OK");
                return wasItSuccessful;
            }
        }




        //------------------------------------------------------------------------------------------------------------------------------------------------------------------------


        public void CreateNewFolderOnServer(string pathServer, string folderName)
        {
            try
            {
                using (Session myConnection = new Session())
                {
                    myConnection.Open(MyConnectionOptions);

                    TransferOptions myConnectionTransferOptions = new TransferOptions();
                    myConnectionTransferOptions.FileMask = "*";
                    myConnectionTransferOptions.OverwriteMode = OverwriteMode.Overwrite;
                    myConnectionTransferOptions.TransferMode = TransferMode.Binary;

                    if (!pathServer.Equals("/"))
                    {
                        RemoteFileInfo fileInfo = myConnection.GetFileInfo(pathServer); // ako je oznacen file kao upload destinacija onda mi je nova destinacija folder koji sadrzi taj file

                        if (!fileInfo.IsDirectory)
                        {
                            pathServer = pathServer.Substring(0, pathServer.LastIndexOf("/"));
                        } 
                    }

                    pathServer = pathServer + "/" + folderName;
                    myConnection.CreateDirectory(pathServer);

                    IspisPoruka("(NOVI FOLDER) "+ "Folder "+folderName+ " je uspiješno kreiran.", "OK");
                }
            }
            catch (Exception e)
            {
                ErrorMessage = e.Message;
                throw new Exception(e.Message);
            }
        }



        //********************************************************************************************************** 
        //                                          DOWNLOAD FILEOVA
  

        public void DownloadFilesAndFolders(string pathLocal, IList items)
        {
            try
            {
                using (Session myConnection = new Session())
                {
                    myConnection.Open(MyConnectionOptions);
                    string newPathLocal;

                    foreach (ListViewItem item in items) // fileovi sa servera
                    {
                        string pathServer = (string)item.Tag;
                        newPathLocal = pathLocal + "\\" + item.Text;
                        Download(pathServer, newPathLocal, myConnection);
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }






        public void DownloadFilesAndFolders(string pathLocal, ExtendedTreeNode node)
        {
            try
            {
                using (Session myConnection = new Session())
                {
                    myConnection.Open(MyConnectionOptions);
                    string pathServer = node.Name;
                    pathLocal = pathLocal + "\\" + node.Text; 
                    Download(pathServer, pathLocal, myConnection);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }







        private void Download(string pathServer, string pathLocal, Session myConnection)
        {
            TransferOperationResult result = myConnection.GetFiles(pathServer, pathLocal, false, myConnectionTransferOptions);

            if (result.IsSuccess == false)
            {
                IspisPoruka("(DOWNLOAD) "+pathServer + " nije preuzet!", "Pogreska");
                
            }
            else
            {
                IspisPoruka("(DOWNLOAD) " + pathServer + " ---> " + pathLocal, "OK");                
            }
        }






        /*************************************************************************************************************
                                         DELETE FILES AND FOLDERS (NA SERVERU)
        */

        public void DeleteFilesOnServer(ListView.SelectedListViewItemCollection selectedItems)
        {
            try
            {
                using(Session myConnection = new Session())
                {
                    myConnection.Open(MyConnectionOptions);

                    foreach (ListViewItem item in selectedItems)
                    {
                        string pathToDelete = (string)item.Tag;
                        Delete(pathToDelete, myConnection);
                    }                    
                }
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
                throw new Exception(ex.Message);
            }
        }


        



        public void DeleteFilesOnServer(ExtendedTreeNode node)
        {
            try
            {
                using (Session myConnection = new Session())
                {
                    myConnection.Open(MyConnectionOptions);
                    string pathToDelete = node.Name;
                    Delete(pathToDelete, myConnection);                    
                }
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
                throw new Exception(ex.Message);
            }
        }




        private void Delete(string pathToDelete, Session myConnection)
        {
            RemovalOperationResult result = myConnection.RemoveFiles(pathToDelete);

            if (result.IsSuccess == false)
            {
                IspisPoruka("(BRISANJE) "+ pathToDelete+" nije obrisan!", "Pogreska");
            }
            else
            {
                IspisPoruka("(BRISANJE) " + pathToDelete + " je obrisan.", "OK");
            }
        }







        /*************************************************************************************************************
                                     RENAME FILES AND FOLDERS (NA SERVERU)
    */

        public void RenameOnServer(string newLabel, string path)
        {
            try
            {
                using (Session myConnection = new Session())
                {
                    myConnection.Open(MyConnectionOptions);
                    string target = path.Substring(0, path.LastIndexOf("/"))+"/"+ newLabel;

                    myConnection.MoveFile(path, target);
                }
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
                throw new Exception(ex.Message);
            }
        }









        //***********************************************************************************
        //                      POSTOJI LI TRAZENI FOLDER/FILE NA SERVERU

        public bool DoesFileExists(string pathServer)
        {
            using (Session myConnection = new Session())
            {
                myConnection.Open(MyConnectionOptions);
                bool answer = myConnection.FileExists(pathServer);
                return answer;
            }

        }





        


        //***********************************************************************************
        //                      ISPISIVANJE U RICHTEXTBOX (GLAVNA FORMA)


        private void IspisPoruka(string message, string messageType)
        {
            if (messageType.Equals("OK"))
            {
                richTextBox_FTPDisplay.SelectionColor = Color.DarkGreen;
                richTextBox_FTPDisplay.AppendText("STATUS: " + message + "\n");
                richTextBox_FTPDisplay.SelectionStart = richTextBox_FTPDisplay.Text.Length;
                richTextBox_FTPDisplay.ScrollToCaret();
            }
            else if (messageType.Equals("Pogreska"))
            {
                richTextBox_FTPDisplay.SelectionColor = Color.Red;
                richTextBox_FTPDisplay.AppendText("POGRESKA: " + message + "\n");
                richTextBox_FTPDisplay.SelectionStart = richTextBox_FTPDisplay.Text.Length;
                richTextBox_FTPDisplay.ScrollToCaret();
            }
        }

    }
}