﻿using Soundboard.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Soundboard.Forms
{
    public partial class frmShortcutManager : Form
    {
        //This temporary dictionary will hold all changes and then decide to save the keybinds or no
        private Dictionary<String, String> tempShortcutDictionary;
        private frmSound SoundDataRef;
        private ListViewColumnSorter ColumnSorter;
        public frmShortcutManager(frmSound SoundForm)
        {
            InitializeComponent();
            //Copy Constructor method, so don't need to clone here
            tempShortcutDictionary = SoundForm.SoundData.getShortcutDictionaryC();
            SoundDataRef = SoundForm;
            ColumnSorter = new ListViewColumnSorter();
        }

        /* EVENT HANDLERS */

        //--------------------------------------------------------------------------------------------------------------------------

        private void btnRemoveAll_Click(object sender, EventArgs e)
        {
            DialogResult confirmation = MessageBox.Show("Do you want to delete ALL shortcut keybinds?", "Confirm Remove All", MessageBoxButtons.YesNo);
            if (confirmation == DialogResult.Yes)
            {
                //Clear all items
                lviewShortcuts.Items.Clear();
                //Then Delete all of the shortcut keys
                tempShortcutDictionary = new Dictionary<String, String>();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            tempShortcutDictionary.Clear();
            tempShortcutDictionary = null;
            this.Close();
        }

        private void frmShortcutManager_Load(object sender, EventArgs e)
        {
            populateListView();
            //Attach the Column Sorter to the listview
            lviewShortcuts.ListViewItemSorter = ColumnSorter;
            //And then attach the event handler
            lviewShortcuts.ColumnClick += lviewShortcut_ColumnClicked;
            
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            //Since all changes are to the dictionary, let's save them here
            SoundDataRef.SoundData.setShortcutDictionary(tempShortcutDictionary);
            //Now invoke the save function
            SoundDataRef.SoundData.saveShortcutDictionary();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            int firstIndex = -1;
            foreach(int i in lviewShortcuts.SelectedIndices)
            {
                //Can't have a negative index
                if(firstIndex == -1)
                {
                    firstIndex = i;
                }
                MessageBox.Show("Deleting : " + lviewShortcuts.Items[i].SubItems[0].Text);
                //Remove the item from the dictionary
                tempShortcutDictionary.Remove(lviewShortcuts.Items[i].SubItems[0].Text);
                lviewShortcuts.Items.RemoveAt(i);

            }
            if (firstIndex != 0)
                firstIndex--;
            //Auto select the previous item if one exists
            if(lviewShortcuts.Items.Count != 0)
                lviewShortcuts.Items[firstIndex].Selected = true;

        }

        private void btnEditKey_Click(object sender, EventArgs e)
        {
            //This is primarily for readability purposes
            String filePath = lviewShortcuts.SelectedItems[0].SubItems[3].Text;
            
            String oldKeyBind = lviewShortcuts.SelectedItems[0].SubItems[0].Text;
            String newKeyBind = InputHelper.getUserInputShortcut();

            //populateListView();
            //Now process changes
            String soundTest = SoundDataRef.SoundData.getShortcutSound(newKeyBind);

            if(soundTest != null)
            {
                String[] soundTestSplit = soundTest.Split('\\');
                //Ask if the user wants to override the shortcut
                DialogResult overrideChoice = MessageBox.Show("Key combination '" + newKeyBind + "' is already bound to '" + soundTestSplit[soundTestSplit.Length - 1] +
                    "\nDo you wish to overide?", "Collision Notice", MessageBoxButtons.YesNo);
                if (overrideChoice == DialogResult.No)
                {
                    //Don't override, stop processing
                    return;
                }
            }
            tempShortcutDictionary.Remove(oldKeyBind);
            tempShortcutDictionary[newKeyBind] = filePath;
            lviewShortcuts.SelectedItems[0].SubItems[0].Text = newKeyBind;

        }

        //private void

        private void lviewShortcut_ColumnClicked(object sender, ColumnClickEventArgs e)
        {
            ColumnSort(e, lviewShortcuts, ColumnSorter);
        }

        //------------------------------------------------------------------------------------------------------------
        /* Helper Methods*/

        /// <summary>
        /// Given the event of a column being clicked on, use the supplied column sorter to sort a ListView. 
        /// The column sorter's mode will switch between ascending and descending, or change columns
        /// </summary>
        /// <param name="e"></param>
        /// <param name="lviewResults"></param>
        /// <param name="lvwColumnSorter"></param>
        private void ColumnSort(ColumnClickEventArgs e, ListView lviewResults, ListViewColumnSorter lvwColumnSorter)
        {
            //Checking to see if column is already selected
            if (e.Column == lvwColumnSorter.ColumnToSort)
            {
                //If already selected - reverse the order
                if (lvwColumnSorter.SortMode == SortOrder.Ascending)
                {
                    lvwColumnSorter.SortMode = SortOrder.Descending;
                }
                else
                {
                    lvwColumnSorter.SortMode = SortOrder.Ascending;
                }
            }
            else
            {
                //New column - default to ascending order
                lvwColumnSorter.ColumnToSort = e.Column;
                lvwColumnSorter.SortMode = SortOrder.Descending;
            }
            //Now perform the sort
            lviewResults.Sort();
        }

        /// <summary>
        /// Clears the listview of Shortcuts and repopulates the list with up to date information
        /// </summary>
        private void populateListView()
        {
            lviewShortcuts.Items.Clear();
            if (tempShortcutDictionary != null && tempShortcutDictionary.Count != 0)
            {
                List<ListViewItem> newItems = new List<ListViewItem>();
                foreach (KeyValuePair<String, String> kvp in tempShortcutDictionary)
                {
                    String[] itemArray = new String[4];
                    //The KeyBind
                    itemArray[0] = kvp.Key;
                    //The FileName
                    itemArray[1] = kvp.Value.Split('\\')[kvp.Value.Split('\\').Count() - 1];
                    //The Group Name
                    itemArray[2] = kvp.Value.Split('\\')[kvp.Value.Split('\\').Count() - 2];
                    //The Full Filepath
                    itemArray[3] = kvp.Value;
                    ListViewItem newItem = new ListViewItem(itemArray);
                    newItems.Add(newItem);
                }
                lviewShortcuts.Items.AddRange(newItems.ToArray());
            }
        }
    }
}
