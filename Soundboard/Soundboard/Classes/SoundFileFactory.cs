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
                
            }
            return soundData;
        }
    }
}
