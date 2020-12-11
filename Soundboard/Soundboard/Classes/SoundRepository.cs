using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soundboard.Classes
{
    public class SoundRepository
    {
        //Holds all of the sound data
        public Dictionary<String, List<SoundFile>> SoundFiles;

        private Dictionary<String, String> ShortcutDictionary;

        public SoundRepository()
        {
            ShortcutDictionary = new Dictionary<String, String>();
        }

        public SoundRepository(Dictionary<String, List<SoundFile>> fileData)
        {
            SoundFiles = fileData;
            ShortcutDictionary = new Dictionary<String, String>();
        }

        public void setShortcutSound(String keyCombo, String FilePath)
        {
            ShortcutDictionary[keyCombo] = FilePath;
        }

        public void setShortcutDictionary(Dictionary<String, String> newDictionary)
        {
            ShortcutDictionary = new Dictionary<String, String>(newDictionary);
        }

        public void clearShortcutSound(String keyCombo)
        {
            //Will use null - can kill two birds with one stone with a null check
            ShortcutDictionary.Remove(keyCombo);
        }

        public void clearAllShortcutSounds()
        {
            ShortcutDictionary = new Dictionary<String, String>();
        }

        public String getShortcutSound(String keyCombo)
        {
            if (!ShortcutDictionary.ContainsKey(keyCombo))
            {
                return null;
            }
            return ShortcutDictionary[keyCombo];
        }

        public String[] getGroupNames()
        {
            return SoundFiles.Keys.ToArray();
        }

        public Dictionary<String, String> getShortcutDictionaryC()
        {
            return new Dictionary<String, String>(ShortcutDictionary);
        }

        
    }
}
