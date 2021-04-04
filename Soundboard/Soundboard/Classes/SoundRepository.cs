using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

        public String getShortcutbyFilePath(String filePath)
        {
            var shortcutEntry = ShortcutDictionary.FirstOrDefault(dictEntry => dictEntry.Value.Equals(filePath));
            return shortcutEntry.Key;
        }

        public String[] getGroupNames()
        {
            return SoundFiles.Keys.ToArray();
        }

        public Dictionary<String, String> getShortcutDictionaryC()
        {
            return new Dictionary<String, String>(ShortcutDictionary);
        }

        public void saveShortcutDictionary()
        {
            using (FileStream fs = File.OpenWrite("Shortcuts.bin")) 
            {
                using (BinaryWriter bw = new BinaryWriter(fs))
                {
                    //Write the count so we know how many entries to read later
                    bw.Write(ShortcutDictionary.Count);
                    foreach(KeyValuePair<String, String> kvp in ShortcutDictionary)
                    {
                        bw.Write(kvp.Key);
                        bw.Write(kvp.Value);
                    }
                }
            }
        }

        public Dictionary<String, String> loadShortcutDictionary()
        {
            Dictionary<String, String> loadedDictionary = new Dictionary<String, String>();
            try
            {
                using (FileStream fs = File.OpenRead("Shortcuts.bin"))
                {
                    using (BinaryReader br = new BinaryReader(fs))
                    {
                        //Write the count so we know how many entries to read later
                        int entryAmount = br.ReadInt32();
                        for (int i = 0; i < entryAmount; i++)
                        {
                            String key = br.ReadString();
                            String value = br.ReadString();
                            loadedDictionary.Add(key, value);
                        }
                    }
                }
            }
            catch (FileNotFoundException)
            {
                //If the file is not found - simply return the empty dictionary.
                MessageBox.Show("Shortcut prefernces not found!");
                
            }
            return loadedDictionary;
        }
    }
}
