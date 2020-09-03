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
        private Dictionary<String, List<SoundFile>> SoundFiles;
        

        public SoundRepository()
        {

        }

        public SoundRepository(Dictionary<String, List<SoundFile>> fileData)
        {
            SoundFiles = fileData;
        }
    }
}
