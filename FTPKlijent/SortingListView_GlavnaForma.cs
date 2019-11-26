using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FTPKlijent
{
    class SortingListView_GlavnaForma
    {
        private static bool sortedAscending = false;


        public static void SortListByColumn(ListView listview, int sortByColumn)
        {
            List<ListViewItem> inputList = new List<ListViewItem>();
            List<ListViewItem> sortedList = new List<ListViewItem>();

            foreach (ListViewItem item in listview.Items)
            {
                inputList.Add(item);
            }


            if (sortByColumn==3)
            {
                if (sortedAscending==true)
                {
                    sortedList = inputList.OrderBy((item) => Convert.ToDateTime(item.SubItems[sortByColumn].Text)).ToList();
                    sortedAscending = false;
                }
                else
                {
                    sortedAscending = true;
                    sortedList = inputList.OrderByDescending((item) => Convert.ToDateTime(item.SubItems[sortByColumn].Text)).ToList();
                }
            }
            else if (sortByColumn==1)
            {
                if (sortedAscending==true)
                {
                    sortedList = inputList.OrderBy((item) => Convert.ToInt64(item.SubItems[sortByColumn].Text)).ToList();
                    sortedAscending = false;
                }
                else
                {
                    sortedAscending = true;
                    sortedList = inputList.OrderByDescending((item) => Convert.ToUInt64(item.SubItems[sortByColumn].Text)).ToList();
                }
            }
            else
            {
                if (sortedAscending==true)
                {
                    sortedList = inputList.OrderBy((item) => item.SubItems[sortByColumn].Text).ToList();
                    sortedAscending = false;
                }
                else
                {
                    sortedAscending = true;
                    sortedList = inputList.OrderByDescending((item) => item.SubItems[sortByColumn].Text).ToList();
                }
            }


            listview.Items.Clear();

            foreach (ListViewItem item in sortedList)
            {
                listview.Items.Add(item);
            }
        }

    }
}
