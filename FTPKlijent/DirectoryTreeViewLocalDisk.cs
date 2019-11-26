using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FTPKlijent
{
    class DirectoryTreeViewLocalDisk
    {
        private TreeView treeview;
        private ExtendedTreeNode superNode;
        private Form_Glavna mainForm;


        public DirectoryTreeViewLocalDisk(TreeView tv, string superNodeName, Form_Glavna mainForm)
        {
            this.treeview = tv;
            SuperNodeCreation(superNodeName);
            CreatingDirectoriesTree();
            this.mainForm = mainForm;

        }


        private void SuperNodeCreation(string superNodeName)
        {
            superNode = new ExtendedTreeNode(superNodeName);
            superNode.Name = superNodeName;
            superNode.Text = superNodeName;
            superNode.Tag = superNodeName;
            superNode.ImageIndex = 0;
            superNode.SelectedImageIndex = 0;
        }



        public void Expand(ExtendedTreeNode nodeToExpand)
        {       

            try
            {
                if (!nodeToExpand.Text.Equals(superNode.Text))
                {
                    nodeToExpand.Nodes.Clear();
                    ExtendedTreeNode[] treeNodeChildren = TreeViewCreation(nodeToExpand.Name);

                    foreach (ExtendedTreeNode node in treeNodeChildren)
                    {
                        nodeToExpand.Nodes.Add(node);
                    }

                    foreach (ExtendedTreeNode dir in nodeToExpand.Nodes)
                    {
                        if (dir.Name != "" && (dir.Tag.Equals("Directory") || dir.Tag.Equals("Drive")))
                        {
                            treeNodeChildren= TreeViewCreation(dir.Name);

                            if (treeNodeChildren!=null)
                            {
                                foreach (ExtendedTreeNode node in treeNodeChildren)
                                {
                                    dir.Nodes.Add(node);
                                } 
                            }
                        }
                    }
                }
                else
                {
                    nodeToExpand.Nodes.Clear();

                    string[] drives = Environment.GetLogicalDrives();

                    foreach (var drive in drives)
                    {
                        DriveInfo myDrive = new DriveInfo(drive);

                        if (myDrive.IsReady)
                        {
                            ExtendedTreeNode driveNode = new ExtendedTreeNode(drive);

                            driveNode.Text = drive;
                            driveNode.Name = drive;
                            driveNode.Tag = "Drive";
                            driveNode.ImageIndex = 1;
                            driveNode.SelectedImageIndex = 1;

                            ExtendedTreeNode[] myNode = TreeViewCreation(drive);

                            foreach (ExtendedTreeNode node in myNode)
                            {
                                driveNode.Nodes.Add(node);
                            }

                            nodeToExpand.Nodes.Add(driveNode);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }





        public void CreatingDirectoriesTree() // kreiranje diskova
        {
            string[] drives = Environment.GetLogicalDrives();

            foreach (var drive in drives)
            {
                DriveInfo myDrive = new DriveInfo(drive);

                if (myDrive.IsReady)
                {
                    ExtendedTreeNode[] myNode = TreeViewCreation(drive);
                    myNode[0].Text = drive;
                    myNode[0].Name = drive;
                    myNode[0].Tag = "Drive";
                    myNode[0].ImageIndex = 1;
                    myNode[0].SelectedImageIndex = 1;
                    superNode.Nodes.Add(myNode[0]);
                }
            }

            treeview.Nodes.Add(superNode);
        }



        public ExtendedTreeNode[] TreeViewCreation(string startingDirectory)
        {
            try
            {
                string[] subdirectories = Directory.GetDirectories(startingDirectory);

                ExtendedTreeNode[] treeNodeChildren = new ExtendedTreeNode[Directory.GetFileSystemEntries(startingDirectory).Count()]; //Directory.GetFileSystemEntries obuhvaca i foldere i datoteke
                int counter = 0;


                foreach (var subdir in subdirectories)
                {
                    ExtendedTreeNode node = new ExtendedTreeNode(subdir);
                    node.Name = subdir;
                    node.Text = subdir.Substring(subdir.LastIndexOf("\\") + 1);
                    node.Tag = "Directory";
                    node.ImageIndex = 2;
                    node.SelectedImageIndex = 2;
                    treeNodeChildren[counter] = node;
                    counter++;
                }
           
                return treeNodeChildren.Where((x, y) => treeNodeChildren[y] != null).ToArray();
            }
            catch (UnauthorizedAccessException)
            {
                return null;
            }
            catch  (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }







        public static ExtendedTreeNode KreiranjeNovogTreeNoda(string path, string folderName)
        {
            ExtendedTreeNode newNode = new ExtendedTreeNode(folderName);
            newNode.Text = folderName;
            newNode.Name = path + "\\" + folderName;
            newNode.Tag = "Directory";
            newNode.ImageIndex = 2;
            newNode.SelectedImageIndex = 2;

            string[] directories=Directory.GetDirectories(newNode.Name);

            if (directories.Count()>0)
            {
                newNode.Nodes.Add("newSubnode");
            }


            return newNode;
        }












    }
}
