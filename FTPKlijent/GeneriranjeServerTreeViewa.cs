using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinSCP;

namespace FTPKlijent
{
    class GeneriranjeServerTreeViewa
    {
        public ExtendedTreeNode superNode;

        public GeneriranjeServerTreeViewa(string rootPathServer)
        {
            superNode = new ExtendedTreeNode(rootPathServer);
            superNode.Name = rootPathServer;
            superNode.Text = rootPathServer;
            superNode.Tag = rootPathServer;
            superNode.ImageIndex = 0;
            superNode.SelectedImageIndex = 0;

            Control.CheckForIllegalCrossThreadCalls = false;
        }



//-------------------------------------------------------------------------------------------------------------------------------------------------------------------------



        public void GenerateTreeView(ExtendedTreeNode mainNode, string pathServer, FTPConnection2 myFTPConnection)
        {
            using (Session myConnection = new Session())
            {
                myConnection.Open(myFTPConnection.MyConnectionOptions);
                Generate(myConnection, mainNode, pathServer);
            }
        }



        public void Generate(Session myConnection, ExtendedTreeNode mainNode, string pathServer)
        {
            RemoteDirectoryInfo directoryInfo = myConnection.ListDirectory(pathServer);
            int numberOfFolders = directoryInfo.Files.Where(x => x.IsDirectory && x.Name!="..").Count();

            if (numberOfFolders>0)
            {
                ExtendedTreeNode folderNode = new ExtendedTreeNode("?");
                folderNode.Text = "?";
                folderNode.Name = "?";
                folderNode.Tag = "Directory";
                folderNode.ImageIndex = 2;
                folderNode.SelectedImageIndex = 2;
                mainNode.Nodes.Add(folderNode); 
            }
        }


        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        public List<TreeNode> ExpandTreeNode(ExtendedTreeNode nodeToExpand, FTPConnection2 myFTPConnection)
        {
            List<TreeNode> nodesToReturn = new List<TreeNode>();
            

            using (Session myConnection = new Session())
            {
                myConnection.Open(myFTPConnection.MyConnectionOptions);
                RemoteDirectoryInfo directoryInfo = myConnection.ListDirectory(nodeToExpand.Name);                

                foreach (RemoteFileInfo file in directoryInfo.Files)
                {
                    if (file.Name != ".." && file.IsDirectory)
                    {
                        ExtendedTreeNode folderNode = new ExtendedTreeNode(file.Name);
                        folderNode.Text = file.Name;

                        if (nodeToExpand.Name.Equals("/"))
                        {
                            folderNode.Name = "/" + file.FullName;
                        }
                        else
                        {
                            folderNode.Name = file.FullName;
                        }

                        folderNode.Tag = "Directory";
                        folderNode.ImageIndex = 2;
                        folderNode.SelectedImageIndex = 2;
                        Generate(myConnection, folderNode, folderNode.Name);
                        nodesToReturn.Add(folderNode);
                    }
                }
            }

            
            return nodesToReturn;
        }



        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------



        public static ExtendedTreeNode KreiranjeNovogTreeNoda(string folderServerPath, string folderName)
        {
            ExtendedTreeNode newNode = new ExtendedTreeNode(folderName);
            newNode.Text = folderName;
            newNode.Name = folderServerPath+"/"+ folderName;
            newNode.Tag = "Directory";
            newNode.ImageIndex = 2;
            newNode.SelectedImageIndex = 2;

            return newNode;
        }



        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------



        public static void GeneriranjeNovihTreeNodovaPrilikomUploada(string localPath, string serverPath, FTPConnection2 myFTPConnection, TreeView treeview)
        {
            string path_newFileOrFolder = serverPath + "/" + Path.GetFileName(localPath);

            if (treeview.Nodes.Find(path_newFileOrFolder, true).Count()!=0) // prilikom overwritea nodovi vec postoje pa ih ne treba ponovo generirati
            {
                treeview.Nodes.Find(path_newFileOrFolder, true)[0].Remove();
            }

            FileAttributes localFileAttribute = File.GetAttributes(localPath);

            if (localFileAttribute == FileAttributes.Directory)
            { 
                ExtendedTreeNode rootNode = (ExtendedTreeNode)treeview.Nodes.Find(serverPath, true)[0];
                AddingNewTreeNodes(rootNode, localPath, serverPath);
            }
        }



        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------



        public static void AddingNewTreeNodes(ExtendedTreeNode rootNode, string localPath, string serverPath)
        {   
            string folderName = Path.GetFileName(localPath);
            ExtendedTreeNode newNode = KreiranjeNovogTreeNoda(serverPath, folderName);           

            string[] dirs=Directory.GetDirectories(localPath);            

            foreach (string dir in dirs)
            {                
                localPath = dir;
            }                       

            rootNode.Nodes.Add(newNode);
        }
















    }
}
