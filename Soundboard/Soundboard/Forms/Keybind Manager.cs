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
    public partial class frmKeybind : Form
    {
        /// <summary>
        /// A dictionary that tracks the keybinds that were changed. Keys are the old keybinds, values are what the keybind was changed to.
        /// </summary>
        private Dictionary<String, String> changedKeyBinds;

        public frmKeybind()
        {
            InitializeComponent();
            changedKeyBinds = new Dictionary<String, String>();
        }


        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //List the amount of items 
            foreach(ListViewItem item in lviewKeybind.Items)
            {
                //For code readability - assign the action to a string variable. Program doesn't use much memory so can do this
                String actionName = item.SubItems[0].Text;
                String oldKeybind = item.Tag.ToString();
                String newKeybind = item.SubItems[1].Text;

                if(oldKeybind == null || oldKeybind == "")
                {
                    continue;
                }

                //Error checking - double check that keybind exists - means some error in listing and unlisting keybinds
                if (!InputHelper.BaseShortcuts.ContainsKey(actionName))
                {
                    MessageBox.Show("Error : Action - '" + actionName + "'");
                }
                //Other
                //InputHelper.BaseShortcuts[actionName] = ;
            }
        }

        private void frmKeybind_Load(object sender, EventArgs e)
        {
            loadBaseKeybinds();
        }
        
        private void loadBaseKeybinds()
        {
            lviewKeybind.Items.Clear();
            //Loop through all controls in the InputHelper.BaseShortcuts
            foreach(KeyValuePair<String, String> kvp in InputHelper.BaseShortcuts)
            {
                String[] listItemArray = { kvp.Value, kvp.Key };
                ListViewItem newItem = new ListViewItem(listItemArray);
                lviewKeybind.Items.Add(newItem);
            }
        }

        private void btnDefault_Click(object sender, EventArgs e)
        {

        }

        private void btnRebind_Click(object sender, EventArgs e)
        {
            String oldKeyBind = lviewKeybind.SelectedItems[0].SubItems[0].Text;
            String newKeyBind = InputHelper.getUserInputShortcut();

            //TODO- add a check that trims the dictionary - incase of rebinding the same action multiple times
            //Or add an extra value somehow

            if (changedKeyBinds.ContainsKey(oldKeyBind))
            {
                changedKeyBinds[oldKeyBind] = newKeyBind;
            }

            //Add the action to the dictionary
            changedKeyBinds.Add(oldKeyBind, newKeyBind);
            
        }

        private void changeKeybind()
        {

        }
    }
}
