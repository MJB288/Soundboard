using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NAudio;
using NAudio.CoreAudioApi;
using NAudio.Wave;

namespace Soundboard.Classes
{

    /// <summary>
    /// This class is responsible for handling all audio playback actions
    /// </summary>
    public class SEMediaPlayer
    {
        private WaveOut MainPlayer;
        public SEMediaPlayer(float startingVolume)
        {
            MainPlayer = new WaveOut();
            MainPlayer.Volume = startingVolume;
        }

        public int playSound(String FilePath, int deviceNumber)
        {            
            MainPlayer.DeviceNumber = deviceNumber;
            //MainPlayer.Volume = .01f * (float)tbarVolume.Value;

            if (FilePath.Substring(FilePath.Length - 4, 4).Equals(".mp3"))
            {
                Mp3FileReader mp3Reader = null;
                try
                {
                    mp3Reader = new NAudio.Wave.Mp3FileReader(FilePath);
                }
                catch (FileNotFoundException)
                {
                    return -1;
                }
                MainPlayer.Init(mp3Reader);
                MainPlayer.Play();
            }
            else if (FilePath.Substring(FilePath.Length - 4, 4).Equals(".wav"))
            {
                WaveFileReader wavReader = null;
                try
                {
                    wavReader = new NAudio.Wave.WaveFileReader(FilePath);
                }
                catch (FileNotFoundException)
                {
                    return -1;
                }
                MainPlayer.Init(wavReader);
                MainPlayer.Play();
            }
            return 1;
        }

        public bool MPisPlaying()
        {
            return MainPlayer.PlaybackState == PlaybackState.Playing;
        }

        public bool MPisPaused()
        {
            return MainPlayer.PlaybackState == PlaybackState.Paused;
        }

        public void StopMainPlayer()
        {
            MainPlayer.Stop();
        }

        public void setVolume(float newVolume)
        {
            MainPlayer.Volume = newVolume;
        }
    }
}
