using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;


namespace Soundboard.Classes
{
    /// <summary>
    /// A factory pattern object designed for constructing SoundFile objects
    /// </summary>
    class SoundFileFactory
    {
        public string[] FilePaths { get; set; }
        public SoundFileFactory(string[] filePaths)
        {
            FilePaths = filePaths;
        }

        public Dictionary<String, List<SoundFile>> constructSoundFiles()
        {
            //First off check for null or empty data - don't run this if true
            if (FilePaths == null || FilePaths.Count() == 0) return null;
            Dictionary<String, List<SoundFile>> soundData = new Dictionary<string, List<SoundFile>>();
            //Now iterate through each filepath
            foreach (String filePath in FilePaths)
            {
                //Split the filepath 
                String[] fileSplit = filePath.Split('\\');
                //Get the length of the Sound Effect
                TimeSpan duration = RecordHelper.getSoundDuration(filePath);
                SoundFile newFile = new SoundFile(fileSplit[fileSplit.Count() - 1], filePath, duration,fileSplit[fileSplit.Count() - 2]);
                //Check if we have an existing group or not
                if (!soundData.ContainsKey(newFile.groupName))
                {
                    soundData[newFile.groupName] = new List<SoundFile>();
                }
                soundData[newFile.groupName].Add(newFile);
            }
            return soundData;
        }


       
    }
}
