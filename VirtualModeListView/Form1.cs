using System;
using System.Reflection;
using System.Windows.Forms;
using System.Collections.Generic;

namespace VirtualModeListView
{
    public partial class Form1 : Form
    {
        private static int maxLines = 10;

        System.Collections.Generic.List<ListViewItem> listOfAvailLVI = new List<ListViewItem>();
        ListViewItem newListViewItem = null;
        System.Collections.Generic.List<String> listNew = new System.Collections.Generic.List<String>();

        public Form1()
        {
            InitializeComponent();
        }
        
        // Populate Items
        private void Form1_Load(object sender, EventArgs e)
        {
            listView.VirtualMode = true;
            listView.VirtualListSize = maxLines;
            toolStripStatusLabel2.Text = maxLines.ToString();

            // Items on Form load. 
            for (int l = 0; l < maxLines; l++)
            {
                // First column
                newListViewItem = new ListViewItem("FormLoadFirstCol" + l);
                // newListViewItem.Name = "newListViewItem_Name" + l;
                // newListViewItem.Text = "newListViewItem_Text" + l;   // This text will replace "newListViewItem" + l"

                // Second Column
                newListViewItem.SubItems.Add("FormLoadSecondCol" + l);
                // newListViewItem.SubItems[1].Text = "SubItems_text" + l;  // This text will replace "SubItems_text" + l

                listOfAvailLVI.Add(newListViewItem);
            }
            Console.WriteLine("");
        }

        private void listView1_RetrieveVirtualItem(object sender, RetrieveVirtualItemEventArgs e)
        {
            ListViewItem it = listOfAvailLVI[e.ItemIndex];
            e.Item = it;
        }

        // Add Item
        // Each subitem will go to the second column. 
        // Important NOTE: If there is an extra column, there has to be a subitem added to the ListViewItem created for the first column.
        private void AddItems_Click(object sender, EventArgs e)
        {
            Console.WriteLine("maxLines: " + maxLines);
            int count = maxLines;

            // New Added items
            for (int l = count; l < (count + 10); l++)
            {
                // First Column
                newListViewItem = new ListViewItem("AddedItemFirstCol " + l);
                // Second Column.
                newListViewItem.SubItems.Add("AddedItemSecondCol" + l);

                listOfAvailLVI.Add(newListViewItem);
                maxLines = maxLines + 1;
            }

            // New Extra Item
            // First Column
            newListViewItem = new ListViewItem("ExtraItemFirstCol");
            // Second Column
            newListViewItem.SubItems.Add("ExtraItemSecondCol");

            listOfAvailLVI.Add(newListViewItem);
            maxLines = maxLines + 1;

            listOfAvailLVI.Sort(delegate (ListViewItem x, ListViewItem y)
            {
                return (x.Text).CompareTo(y.Text);
            });

            listView.VirtualListSize = maxLines;
        }

        private void Move_Click(object sender, EventArgs e)
        {
            // Get element text of selected Index
            ListView.SelectedIndexCollection col = listView.SelectedIndices;
            foreach (var eachItemInCollection in col)
            {
                Console.WriteLine(listView.Items[Convert.ToInt32(eachItemInCollection)].Text);
            }
        }

        // Remove Item
        /* A virtual list knows nothing about your list of items. 
         * It doesn't keep track of them, not even a small set. 
         * It only ever asks "what do you want to show at the n'th row?"
         * If your master list changes, all you need to do is redraw the list.
         * The listview will then ask you again what it should show at every row visible in the control.
        */
        private void remove_Click(object sender, EventArgs e)
        {
            // Get element text of selected Index
            ListView.SelectedIndexCollection col = listView.SelectedIndices;
            List<int> listOfIndexestoRemove = new List<int>();
            foreach (var elementToRemove in col)
            {
                int index = Convert.ToInt32(elementToRemove);
                listOfIndexestoRemove.Add(index);
            }

            // Very imp step
            listOfIndexestoRemove.Reverse();

            foreach (int indexOfElementToRemove in listOfIndexestoRemove)
            {
                listOfAvailLVI.RemoveAt(indexOfElementToRemove);
                maxLines = maxLines - 1;
            }
            listView.VirtualListSize = maxLines;
        }
        
        private void SelectAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < listView.VirtualListSize; i++)
            {
                listView.Items[i].Selected = true;
            }

            // Get element text of selected Index
            ListView.SelectedIndexCollection col = listView.SelectedIndices;
            foreach (var eachItemInCollection in col)
            {
                Console.WriteLine(listView.Items[Convert.ToInt32(eachItemInCollection)].Text);
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}