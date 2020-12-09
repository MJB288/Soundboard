using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Soundboard.Classes
{

    /// <summary>
    /// A static class containing methods for processing inputs
    /// </summary>
    public static class InputHelper
    {
        /// <summary>
        /// A static array of Key Codes that should not be recognized as individual key presses for shortcuts
        /// </summary>
        public static Keys[] NoShortcutAlone = { Keys.ShiftKey, Keys.ControlKey, Keys.Alt, Keys.Menu };

        public static String convertKeyInputToString(KeyEventArgs keyEvent, Keys modifierKeys)
        {
            String keyCombo = "";
            if (modifierKeys.HasFlag(Keys.Control))
            {
                keyCombo += "Ctrl ";
            }
            if (modifierKeys.HasFlag(Keys.Shift))
            {
                keyCombo += "Shift ";
            }
            /* May exclude the Alt Key until I can supress the windows noises that occur when pressing it on this window
            if(Form.ModifierKeys.HasFlag(Keys.Alt))
            {
                keyCombo += "Alt ";
            }*/


            keyCombo += keyEvent.KeyCode.ToString();
            return keyCombo;
        }
    }
}
