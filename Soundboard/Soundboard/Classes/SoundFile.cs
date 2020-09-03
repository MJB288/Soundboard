using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soundboard
{
    /// <summary>
    /// A class that holds all of the necessary attributes for playback
    /// </summary>
    class SoundFile
    {
        public String soundName { get; set; }
        public String filePath {get; set;}
        public String groupName { get; set; }
        //public TimeSpan duration { get; set; }

        /// <summary>
        /// Constructs a SoundFile object. Automatically determines groupname from the last folder name in the filepath
        /// </summary>
        /// <param name="name"></param>
        /// <param name="path">The Filepath where the file is located</param>
        /// <param name="duration">The duration of the sound file</param>
        public SoundFile(String name, String path/*, TimeSpan duration*/)
        {
            soundName = name;
            filePath = path;
            //this.duration = duration;
            //The group name will automatically be determined by the lowest level folder holding the File
            groupName = path.Split('\\')[path.Split('\\').Count()-2];
        }

        /// <summary>
        /// Constructs a SoundFile Object. Allows User/Programmer input on what the group name should be
        /// </summary>
        /// <param name="name"></param>
        /// <param name="path"></param>
        /// <param name="duration"></param>
        /// <param name="groupName"></param>
        public SoundFile(String name, String path, /*TimeSpan duration,*/ String groupName)
        {
            soundName = name;
            filePath = path;
            //this.duration = duration;
            this.groupName = groupName;
        }
    }
}
