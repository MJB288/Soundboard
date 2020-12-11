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
        public frmShortcutManager(SoundRepository SoundData)
        {
            InitializeComponent();
            //Copy Constructor method, so don't need to clone here
            tempShortcutDictionary = SoundData.getShortcutDictionaryC();
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
                    String[] itemArray = new String[3];
                    itemArray[0] = kvp.Key;
                    itemArray[1] = kvp.Value.Split('\\')[kvp.Value.Split('\\').Count() - 1];
                    itemArray[2] = kvp.Value;
                    ListViewItem newItem = new ListViewItem(itemArray);
                    newItems.Add(newItem);
                }
                lviewShortcuts.Items.AddRange(newItems.ToArray());
            }
        }
    }
}
