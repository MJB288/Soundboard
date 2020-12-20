using Soundboard.Classes;
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
        public frmShortcutManager(frmSound SoundForm)
        {
            InitializeComponent();
            //Copy Constructor method, so don't need to clone here
            tempShortcutDictionary = SoundForm.SoundData.getShortcutDictionaryC();
            SoundDataRef = SoundForm;
        }

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

        private void btnApply_Click(object sender, EventArgs e)
        {
            foreach(KeyValuePair<String, String> kvp in tempShortcutDictionary)
            {
                MessageBox.Show(kvp.Key + "\n" + kvp.Value);
            }
            //Since all changes are to the dictionary, let's save them here
            SoundDataRef.SoundData.setShortcutDictionary(tempShortcutDictionary);
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
            frmShortcutForm newShortcutSetter = new frmShortcutForm(lviewShortcuts.SelectedItems[0].SubItems[3].Text, SoundDataRef);
            newShortcutSetter.ShowDialog();
            //Remove the current keybind
            //Reset the list view
            //TODO- update the ListView without resetting the entire list and also not lazily toss it on the bottom
            populateListView();

        }
    }
}
