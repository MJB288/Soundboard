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
        private Boolean Mute;
        private float PrevVolume;
        public bool SingleSoundPlay = false;


        public SEMediaPlayer(float startingVolume)
        {
            //Initialize the players
            MainPlayer = new WaveOut();
            PlaybackPlayer = new WaveOut();
            //Set their starting volume
            MainPlayer.Volume = startingVolume;
            PlaybackPlayer.Volume = startingVolume;
            Recording = false;
            AudioRecorder = new WaveIn();
            PrevVolume = 1.00f;
        }

        /// <summary>
        /// Plays an mp3 or wav file at a specified filepath.
        /// </summary>
        /// <param name="FilePath"></param>
        /// <param name="deviceNumber"></param>
        /// <returns>Returns empty string if successful, otherwise returns Exception message</returns>
        public String playSound(String FilePath, int deviceNumber)
        {            
            MainPlayer.DeviceNumber = deviceNumber;
            //MainPlayer.Volume = .01f * (float)tbarVolume.Value;
            if (SingleSoundPlay)
            {
                MainPlayer.Stop();
            }


            if (FilePath.Substring(FilePath.Length - 4, 4).Equals(".mp3"))
            {
                Mp3FileReader mp3Reader = null;
                try
                {
                    mp3Reader = new NAudio.Wave.Mp3FileReader(FilePath);
                }
                catch (FileNotFoundException fex)
                {
                    return fex.Message;
                }
                catch (System.InvalidOperationException ioex)
                {
                    return ioex.Message;
                }
                MainPlayer.Init(mp3Reader);
                MainPlayer.Play();
               /* MainPlayer.PlaybackStopped += (a, s) =>
                {
                    mp3Reader.Dispose();
                    MainPlayer.Dispose();
                };*/
            }
            else if (FilePath.Substring(FilePath.Length - 4, 4).Equals(".wav"))
            {
                WaveFileReader wavReader = null;
                try
                {
                    wavReader = new NAudio.Wave.WaveFileReader(FilePath);
                }
                catch (FileNotFoundException fex)
                {
                    return fex.Message;
                }
                catch (System.InvalidOperationException ioex)
                {
                    return ioex.Message;
                }
                MainPlayer.Init(wavReader);
                MainPlayer.Play();
               /* MainPlayer.PlaybackStopped += (a, s) =>
                {
                    wavReader.Dispose();
                    MainPlayer.Dispose();
                };*/
            }
            return "";
        }

        /// <summary>
        /// Plays the previously recorded sound byte at the temporary file directory.
        /// </summary>
        /// <param name="soundPath"></param>
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

        /// <summary>
        /// Properly dispenses the memory used by the Playback player 
        /// </summary>
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
            PlaybackPlayer.Volume = PrevVolume;
        }

        /// <summary>
        /// Checks if the main player is in the playing state
        /// </summary>
        /// <returns>True - is Playing, False - is paused or Stopped</returns>
        public bool MPisPlaying()
        {
            return MainPlayer.PlaybackState == PlaybackState.Playing;
        }

        /// <summary>
        /// Checks if the main player is in the paused state
        /// </summary>
        /// <returns>True - is paused, False - is playing or stopped</returns>
        public bool MPisPaused()
        {
            return MainPlayer.PlaybackState == PlaybackState.Paused;
        }

        /// <summary>
        /// Calls the stop function built into the Main Wave Out
        /// </summary>
        public void StopMainPlayer()
        {
            MainPlayer.Stop();
        }

        /// <summary>
        /// Calls the stop function built into the Playback Wave Out
        /// </summary>
        public void StopPlaybackPlayer()
        {
            PlaybackPlayer.Stop();
        }

        /// <summary>
        /// Sets the volume on the main player and the playback player.
        /// </summary>
        /// <param name="newVolume"></param>
        public void setVolume(float newVolume)
        {
            if (!Mute)
            {
                MainPlayer.Volume = newVolume;
                PlaybackPlayer.Volume = newVolume;
            }
            PrevVolume = newVolume;
        }
        
        /// <summary>
        /// Mutes and unmutes the player based on boolean input. 
        /// </summary>
        /// <remarks>
        /// It is a boolean input rather than a boolean toggle simply in case there is a need in the future
        /// to guarantee that mute is being put into a certain state, even if for a brief moment.
        /// </remarks>
        /// <param name="muteState">True - mute player, False - unmute Player</param>
        public void setMuted(bool muteState)
        {
            Mute = muteState;
            if (Mute)
            {
                MainPlayer.Volume = 0;
                PlaybackPlayer.Volume = 0;
            }
            else
            {
                MainPlayer.Volume = PrevVolume;
                PlaybackPlayer.Volume = PrevVolume;
            }
        }

        public bool isMuted()
        {
            return Mute;
        }
    }
}
