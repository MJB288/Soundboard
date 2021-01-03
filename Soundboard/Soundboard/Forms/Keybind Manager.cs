using Soundboard.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Soundboard.Forms
{
    public partial class frmKeybind : Form
    {
        /// <summary>
        /// A dictionary that tracks the keybind-action pairs to add to the InputHelper.BaseShortcuts Dictionary
        /// </summary>
        private Dictionary<String, String> ChangedKeyBinds;
        /// <summary>
        /// A dictionary that tracks which keybinds to remove from the InputHelper.BaseShortcuts Dictionary
        /// </summary>
        private List<String> DeleteKeyBinds;

        private List<String> UniqueKeyBinds;

        public frmKeybind()
        {
            InitializeComponent();
            ChangedKeyBinds = new Dictionary<String, String>();
            DeleteKeyBinds = new List<String>();
            UniqueKeyBinds = new List<String>();
        }


        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Dictionary<String, String> newDictionary = new Dictionary<String, String>();
            //List the amount of items 
            foreach(ListViewItem item in lviewKeybind.Items)
            {
                //For code readability - assign the action to a string variable. Program doesn't use much memory so can do this
                String actionName = item.SubItems[0].Text;
                String oldKeybind = "";
                if (item.Tag != null) 
                {
                    oldKeybind = item.Tag.ToString();
                }
                String newKeybind = item.SubItems[1].Text;

                newDictionary.Add(newKeybind, actionName);

            }
            InputHelper.BaseShortcuts = new Dictionary<String, String>(newDictionary);
            InputHelper.saveBaseShortcuts();
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
                //Add each keybind to the list
                UniqueKeyBinds.Add(kvp.Key);
            }
        }

        private void btnDefault_Click(object sender, EventArgs e)
        {

        }

        private void btnRebind_Click(object sender, EventArgs e)
        {
            changeKeybind();
        }

        private void changeKeybind()
        {
            String oldKeyBind = lviewKeybind.SelectedItems[0].SubItems[1].Text;
            String newKeyBind = InputHelper.getUserInputShortcut();
            String action = lviewKeybind.SelectedItems[0].SubItems[0].Text;

            //Check that the newKeyBind isn't used
            if (UniqueKeyBinds.Contains(newKeyBind))
            {
                MessageBox.Show("Error - Keybind '" + newKeyBind + "' already bound!", "Keybind Error");
                return;
            }

            UniqueKeyBinds.Remove(oldKeyBind);
            UniqueKeyBinds.Add(newKeyBind);


            //TODO- add a check that trims the dictionary - incase of rebinding the same action multiple times
            //Or add an extra value somehow




            //Check if value assigned in the changedKeyBinds and remove it if yes
            /*if (ChangedKeyBinds.ContainsKey(oldKeyBind))
            {
                ChangedKeyBinds.Remove(oldKeyBind);
            }

            if (!DeleteKeyBinds.Contains(oldKeyBind))
            {
                DeleteKeyBinds.Add(oldKeyBind);
            }
            

            //Add the action to the dictionary
            ChangedKeyBinds.Add(oldKeyBind, action);*/
            lviewKeybind.SelectedItems[0].SubItems[1].Text = newKeyBind;
            lviewKeybind.SelectedItems[0].Tag = (object)oldKeyBind;
            btnSave.Enabled = true;
        }
    }
}
