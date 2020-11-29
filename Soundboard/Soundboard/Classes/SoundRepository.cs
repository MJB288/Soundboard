using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soundboard.Classes
{
    class SoundRepository
    {
        //Holds all of the sound data
        public Dictionary<String, List<SoundFile>> SoundFiles;

        public String[] ShortcutSounds;

        public SoundRepository()
        {
            ShortcutSounds = new string[10];
        }

        public SoundRepository(Dictionary<String, List<SoundFile>> fileData)
        {
            SoundFiles = fileData;
            ShortcutSounds = new string[10];
        }

        public void setShortcutSound(int shortcutIndex, String FilePath)
        {
            ShortcutSounds[shortcutIndex] = FilePath;
        }

        public void clearShortcutSound(int shortcutIndex)
        {
            //Will use null - can kill two birds with one stone with a null check
            ShortcutSounds[shortcutIndex] = null;
        }

        public void clearAllShortcutSounds()
        {
            ShortcutSounds = new string[10];
        }

        public String getShortcutSound(int index)
        {
            return ShortcutSounds[index];
        }

        public String[] getGroupNames()
        {
            return SoundFiles.Keys.ToArray();
        }
    }
}
