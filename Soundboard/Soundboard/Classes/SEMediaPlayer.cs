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
        private WaveOut PlaybackPlayer;
        private WaveIn AudioRecorder;
        private WaveFileWriter AudioWriter;
        private WaveFileReader RecordingPlaybackReader;
        public Boolean Recording;
        private float PrevVolume;

        public SEMediaPlayer(float startingVolume)
        {
            MainPlayer = new WaveOut();
            PlaybackPlayer = new WaveOut();
            MainPlayer.Volume = startingVolume;
            PlaybackPlayer.Volume = startingVolume;
            Recording = false;
            AudioRecorder = new WaveIn();
            PrevVolume = 100.00f;
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

        public void playbackRecording(String soundPath)
        {
            if (!Recording)
            {
                //The path of the temporary file
                String TempPath = soundPath + "\\Recording\\Temp.wav";
                RecordingPlaybackReader = new NAudio.Wave.WaveFileReader(TempPath);
                PlaybackPlayer.Init(RecordingPlaybackReader);
                PlaybackPlayer.Play();

            }
        }

        /// <summary>
        /// Flip the Boolean and change the state of recording based off of it
        /// </summary>
        public void toggleRecordingState(int deviceNumber, String soundPath)
        {
            Recording = !Recording;
            //Change Behavior based off of the new boolean, not the previous boolean
            if (Recording)
            {
                //Double check that memory is properly disposed of
                resetRecordingPlaybackPlayer();
                //Signify that the program is currently Recording
                
                //Instatiate the recorder and the file writer
                String recordingPath = soundPath + "\\Recording\\Temp.wav";

                //Instatiate the WaveIn
                AudioRecorder = new WaveIn();
                AudioRecorder.DeviceNumber = deviceNumber;
                RecordHelper.StartRecordingIn(AudioWriter, AudioRecorder, recordingPath);
            }
            else
            {
                //Thanks to the event handlers setup in the Start Recording section - only one method needs to be called
                AudioRecorder.StopRecording();
            }
        }

        private void resetRecordingPlaybackPlayer()
        {
            //Reset the Waveout so that the file is properly closed
            if (PlaybackPlayer != null)
            {
                PlaybackPlayer.Stop();
                PlaybackPlayer.Dispose();

            }
            if (RecordingPlaybackReader != null)
            {
                RecordingPlaybackReader.Dispose();
            }
            PlaybackPlayer = new WaveOut();
            PlaybackPlayer.Volume = 0.01f * PrevVolume;
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

        public void StopPlaybackPlayer()
        {
            PlaybackPlayer.Stop();
        }

        public void setVolume(float newVolume)
        {
            MainPlayer.Volume = newVolume;
            PlaybackPlayer.Volume = newVolume;
            PrevVolume = newVolume;
        }
    }
}
