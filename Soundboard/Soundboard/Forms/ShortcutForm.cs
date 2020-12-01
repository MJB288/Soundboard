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
        public frmShortcutForm()
        {
            InitializeComponent();
        }

        private void frmShortcutForm_Load(object sender, EventArgs e)
        {
            this.KeyPress += getPressedKey;
        }

        private void getPressedKey(object sender, KeyPressEventArgs ke)
        {
            lblDisplayKey.Text = "Pressed Key = " + ke.KeyChar;
        }
    }
}
