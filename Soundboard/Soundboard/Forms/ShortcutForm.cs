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
        /// A static array of Key Codes that should not be recognized as individual key presses for shortcuts
        /// </summary>
        public static Keys[] NoShortcutAlone = { Keys.ShiftKey, Keys.ControlKey, Keys.Alt, Keys.Menu};
        public frmShortcutForm()
        {
            InitializeComponent();
        }

        private void frmShortcutForm_Load(object sender, EventArgs e)
        {
            //this.KeyPress += getPressedKey;
            this.KeyUp += getPressedKeyUp;
        }

        private void getPressedKey(object sender, KeyPressEventArgs ke)
        {
            lblDisplayKey.Text = "Pressed Key = " + ke.KeyChar;
            if (Form.ModifierKeys.HasFlag(Keys.Shift))
            {
                lblDisplayKey.Text += " Shift";
            }
        }

        private void getPressedKeyUp(object sender, KeyEventArgs ke)
        {
            //I don't want Shift, Ctrl, or Alt to be registered as individual keypresses
            //Also - 
            if (!NoShortcutAlone.Contains(ke.KeyCode))
            {
                String keyCombo = "";
                if (Form.ModifierKeys.HasFlag(Keys.Control))
                {
                   keyCombo += "Ctrl ";
                }
                if (Form.ModifierKeys.HasFlag(Keys.Shift))
                {
                    keyCombo += "Shift ";
                }
                /*
                if(Form.ModifierKeys.HasFlag(Keys.Alt))
                {
                    keyCombo += "Alt ";
                }*/
                keyCombo += ke.KeyCode.ToString();
                lblDisplayKey.Text = "Pressed Key = " + keyCombo;
                
            }
        }
    }
}
