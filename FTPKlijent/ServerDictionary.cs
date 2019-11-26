using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FTPKlijent
{
    static class ServerDictionary
    {
        public static Dictionary<string, List<ListViewItem>> ContentDictionary = new Dictionary<string, List<ListViewItem>>();

        public static void RemoveItem(string key)
        {
            try
            {
                if (ContentDictionary.ContainsKey(key))
                {
                    ContentDictionary.Remove(key);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }


        public static void AddItem(string key, List<ListViewItem> listItem)
        {
            try
            {
                if (!ContentDictionary.ContainsKey(key))
                {
                    ContentDictionary.Add(key, listItem);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }


        public static void ServerUploadNewItem(string key, ListViewItem newItem)
        {
            try
            {
                if (ContentDictionary.ContainsKey(key))
                {
                    List<ListViewItem> existingList = ContentDictionary[key];
                    existingList.Add(newItem);
                    RemoveItem(key);
                    AddItem(key, existingList);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }


        public static void ServerDeleteItem(string key, string itemToDelete)
        {
            try
            {
                if (ContentDictionary.ContainsKey(key))
                {
                    List<ListViewItem> existingList = ContentDictionary[key];
                    int index = existingList.FindIndex(x => ((string)x.Tag).Equals(itemToDelete));
                    existingList.RemoveAt(index);
                    RemoveItem(key);
                    AddItem(key, existingList);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }




        public static void RenameKey(string oldKey, string newKey)
        {
            try
            {
                if (ContentDictionary.ContainsKey(oldKey))
                {
                    List<ListViewItem> list= ContentDictionary[oldKey];
                    RemoveItem(oldKey);
                    AddItem(newKey, list);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }







        public static void RenameListViewItem(string key, string folderOrFileOldFullPath, string folderOrFileNewFullPath)
        {
            try
            {
                if (ContentDictionary.ContainsKey(key))
                {
                    List<ListViewItem> list = ContentDictionary[key];
                    int index=list.FindIndex(x=>((string)x.Tag).Equals(folderOrFileOldFullPath));

                    ListViewItem item = list[index];
                    item.Tag = folderOrFileNewFullPath;
                    item.Text = folderOrFileNewFullPath.Substring(folderOrFileNewFullPath.LastIndexOf("/") + 1);

                    list.RemoveAt(index);
                    list.Add(item);

                    RemoveItem(key);
                    AddItem(key, list);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

    }
}
