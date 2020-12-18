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
        /// <summary>
        /// A static list of shortcuts that do things other than play a sound. 
        /// </summary>
        public static Dictionary<String, String> BaseShortcuts = loadBaseShortcuts();

        public static String LastKeyCombo = "";
        public static bool LastKeyComboLock = false;

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
        /// <summary>
        /// Loads the dictionary of user keybinds for shortcuts that do something other than play sound
        /// </summary>
        /// <returns></returns>
        private static Dictionary<String, String> loadBaseShortcuts()
        {
            //No prebound shortcuts yet so I will simply return a new dictionary
            return new Dictionary<String, String>();
        }

        /// <summary>
        /// A method that removes a base shortcut and replaces it with another. This is for sound purposes
        /// </summary>
        public static void changeBaseShortcuts(String originalShortcut, String newShortcut)
        {
            if (!BaseShortcuts.ContainsKey(originalShortcut))
            {
                throw new ArgumentException("Base Shortcut '" + originalShortcut + "' was not found!");
            }

            BaseShortcuts[newShortcut] = BaseShortcuts[originalShortcut];
            //Now remove the old key bind
            BaseShortcuts.Remove(originalShortcut);
        }
    }

    
}
