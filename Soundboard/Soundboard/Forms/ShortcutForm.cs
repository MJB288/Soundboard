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
    public partial class frmShortcutForm : Form
    {
        
        /// <summary>
        /// The filepath of the sound file that will be played with the key press
        /// </summary>
        private String ShortcutFilePath;
        private frmSound Soundboard;
        public frmShortcutForm(String shortcutFilePath, frmSound soundboard)
        {
            InitializeComponent();
            ShortcutFilePath = shortcutFilePath;
            Soundboard = soundboard;
        }

        private void frmShortcutForm_Load(object sender, EventArgs e)
        {
            //this.KeyPress += getPressedKey;
            this.KeyUp += getPressedKeyUp;
        }

        private void getPressedKeyUp(object sender, KeyEventArgs ke)
        {
            //I don't want Shift, Ctrl, or Alt to be registered as individual keypresses
            //Also - 
            if (!InputHelper.NoShortcutAlone.Contains(ke.KeyCode))
            {
                //Get the String combination for the pressed key
                String keyCombo = InputHelper.convertKeyInputToString(ke, Form.ModifierKeys);
                //lblDisplayKey.Text = "Pressed Key = " + keyCombo;

                //Now pass the data to the sound repository - using the form reference that was passed to this form
                String soundTest = Soundboard.SoundData.getShortcutSound(keyCombo);
                if (soundTest != null)
                {
                    String[] soundTestSplit = soundTest.Split('\\');
                    //Ask if the user wants to override the shortcut
                    DialogResult overrideChoice = MessageBox.Show("Key combination '" + keyCombo + "' is already bound to '" + soundTestSplit[soundTestSplit.Length - 1] +
                        "\nDo you wish to overide?", "Collision Notice", MessageBoxButtons.YesNo);
                    if(overrideChoice == DialogResult.No)
                    {
                        //Don't override, close the window
                        this.Close();
                        return;
                    }
                    
                }
                //Set the shortcut in the options
                Soundboard.SoundData.setShortcutSound(keyCombo, ShortcutFilePath);
                this.Close();
            }

           
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
