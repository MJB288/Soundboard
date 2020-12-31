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
        public String KeyCombo;
        public frmShortcutForm(String shortcutFilePath, frmSound soundboard)
        {
            InitializeComponent();
            ShortcutFilePath = shortcutFilePath;
            Soundboard = soundboard;
            KeyCombo = "";
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
                KeyCombo = InputHelper.convertKeyInputToString(ke, Form.ModifierKeys);
                //lblDisplayKey.Text = "Pressed Key = " + keyCombo;

                
                this.Close();
            }

           
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
