using NAudio;
using NAudio.CoreAudioApi;
using NAudio.Wave;
using Soundboard.Classes;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Soundboard
{
    public partial class frmSound : Form
    {
        private SoundRepository SoundData;
        private String SoundPath;
        private WaveOut MainPlayer;
        private WaveOut PlaybackPlayer;
        private Boolean Recording;
        private WaveIn AudioRecorder;
        private WaveFileWriter AudioWriter;
        private WaveFileReader RecordingPlaybackReader;

        public frmSound()
        {
            InitializeComponent();
            Recording = false;
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            /*System.Media.SoundPlayer player = new System.Media.SoundPlayer("hellothere.mp3");
            player.*/

            //WMPLib.WindowsMediaPlayer player = new WMPLib.WindowsMediaPlayer();
            //player.URL = "hellothere.mp3";
            //            player.playerApplication.
            /* using (FileStream fs = new FileStream("hellothere.wav", FileMode.Open, FileAccess.Write, FileShare.ReadWrite))
             {
                 var waveReader = new NAudio.Wave.WaveFileReader("hellothere1.wav");
                 var waveIn = new NAudio.Wave.WaveIn();
                 

                 waveIn.DeviceNumber = 0;
                 waveOut.DeviceNumber = cboxSoundDevices.SelectedIndex;

                 var test = new NAudio.Wave.Mp3FileReader("hellothere.mp3");
                 waveOut.Init(test);
                 waveOut.Play();
             }*/
            if(lviewSounds.SelectedItems.Count == 0)
            {
                MessageBox.Show("No item is selected!", "Play Error");
                return;
            }
            if(MainPlayer.PlaybackState == PlaybackState.Paused || MainPlayer.PlaybackState == PlaybackState.Playing)
            {
                MainPlayer.Stop();
            }
            MainPlayer.DeviceNumber = cboxOutputDevices.SelectedIndex;
            //MainPlayer.Volume = .01f * (float)tbarVolume.Value;
            
            if(lviewSounds.SelectedItems[0].Tag.ToString()[lviewSounds.SelectedItems[0].Tag.ToString().Length - 1] == '3')
            {
                Mp3FileReader mp3Reader = null;
                try
                {
                    mp3Reader = new NAudio.Wave.Mp3FileReader((String)lviewSounds.SelectedItems[0].Tag);
                }
                catch (FileNotFoundException)
                {
                    MessageBox.Show("Error : File '" + lviewSounds.SelectedItems[0].Tag + "' is not found!");
                    return;
                }
                MainPlayer.Init(mp3Reader);
                MainPlayer.Play();
            }
            else if(lviewSounds.SelectedItems[0].Tag.ToString().ToLower()[lviewSounds.SelectedItems[0].Tag.ToString().Length - 1] == 'v')
            {
                WaveFileReader wavReader = null;
                try
                {
                    wavReader = new NAudio.Wave.WaveFileReader((String)lviewSounds.SelectedItems[0].Tag);
                }
                catch (FileNotFoundException)
                {
                    MessageBox.Show("Error : File '" + lviewSounds.SelectedItems[0].Tag + "' is not found!");
                    return;
                }
                MainPlayer.Init(wavReader);
                MainPlayer.Play();
            }
            
            
            //NAudio.Wave.DirectSoundOut.
//            var device = new MMDeviceEnumerator();
        }

        private void lviewSounds_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void frmSound_Load(object sender, EventArgs e)
        { 
            //Load all of the sound devices for both input and output
            loadInputDevices();
            loadOutputDevices();

            SoundPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\Sounds";
            //Instatiate the Recording Folder if necessary
            System.IO.Directory.CreateDirectory(SoundPath + "\\Recording");
            //Acquire the sound data
            refreshSoundData();

            MainPlayer = new NAudio.Wave.WaveOut();
            PlaybackPlayer = new NAudio.Wave.WaveOut();
            tbarVolume.Value = 50;
            MainPlayer.Volume = 0.01f * tbarVolume.Value;

            btnPlay.Shor
            //loadSoundDevices(NAudio.Wave.WaveIn.DeviceCount, NAudio.Wave.WaveIn)
        }

        private object getCapability(bool input, int deviceID)
        {
            if (input)
            {
                return NAudio.Wave.WaveIn.GetCapabilities(deviceID);
            }
            else
            {
                return NAudio.Wave.WaveOut.GetCapabilities(deviceID);
            }
        }

        /// <summary>
        /// Uses the NAudio Library to get the list of input devices and uploads the list of names to a comboBox for selection
        /// </summary>
        private void loadInputDevices()
        {
            cboxInputDevices.Items.Clear();
            for(int deviceId = 0; deviceId < NAudio.Wave.WaveIn.DeviceCount; deviceId++)
            {
                var capabilities = NAudio.Wave.WaveIn.GetCapabilities(deviceId);
                cboxInputDevices.Items.Add(capabilities.ProductName);
            }
            cboxInputDevices.SelectedIndex = 0;
        }

        /// <summary>
        /// Uses the NAudio Library to get the list of output devices and uploads the list of names to a comboBox for selection
        /// </summary>
        private void loadOutputDevices()
        {
            cboxOutputDevices.Items.Clear();
            for (int deviceId = 0; deviceId < NAudio.Wave.WaveOut.DeviceCount; deviceId++)
            {
                var capabilities = NAudio.Wave.WaveOut.GetCapabilities(deviceId);
                cboxOutputDevices.Items.Add(capabilities.ProductName);
            }
            cboxOutputDevices.SelectedIndex = 0;
        }

        /// <summary>
        /// Reacquires the list of sound files in the data repository
        /// </summary>
        private void refreshSoundData()
        {
            cboxGroups.Items.Clear();
            //foreach(System.IO.Directory.GetFiles(SoundPath, "*.mp3"))
            String[] filePaths = System.IO.Directory.GetFiles(SoundPath, "*", SearchOption.AllDirectories).Where(file => file.Contains(".mp3") || file.Contains(".wav")).ToArray();
            SoundFileFactory fileCreator = new SoundFileFactory(filePaths);
            SoundData = new SoundRepository(fileCreator.constructSoundFiles());
            //lblTest.Text = SoundData.SoundFiles.Keys.ToString
            try
            {
                cboxGroups.Items.AddRange(SoundData.getGroupNames());
                //While the rest of this code doesn't throw an exception - don't want to execute if no files
                cboxGroups.SelectedIndex = 0;
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Error - unable to find files in directory :\n" + SoundPath, "Files Not Found");
            }
        }

        private void cboxGroups_SelectedIndexChanged(object sender, EventArgs e)
        {
            lviewSounds.Items.Clear();
            //Incase the combobox is cleared - don't fire any code or more exceptions will happen
            if(cboxGroups.SelectedIndex < 0)
            {
                return;
            }

            //Fill out the list of SoundFiles based on the group that has been selected
            foreach(SoundFile soundFile in SoundData.SoundFiles[cboxGroups.SelectedItem.ToString()])
            {
                //Remove the .mp3 Extension (or .wav since that format is now current supported)
                StringBuilder noMp3Name = new StringBuilder(soundFile.soundName);
                noMp3Name.Remove(noMp3Name.Length - 4, 4);
                //Create a string array of attributes
                String[] itemArray = { noMp3Name.ToString(), "0"};
                //Convert the attributes into a List View format
                ListViewItem lviewItem = new ListViewItem(itemArray);
                //And then add them to the path
                lviewItem.Tag = soundFile.filePath;
                lviewSounds.Items.Add(lviewItem);
                
            }
            lviewSounds.Items[0].Selected = true;
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            if(MainPlayer == null || MainPlayer.PlaybackState == PlaybackState.Stopped)
            {
                return;
            }
            MainPlayer.Stop();
        }

        private void tbarVolume_Scroll(object sender, EventArgs e)
        {
            MainPlayer.Volume = .01f * tbarVolume.Value;
            PlaybackPlayer.Volume = .01f * tbarVolume.Value;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            refreshSoundData();
        }

        private void btnRecord_Click(object sender, EventArgs e)
        {
            //Only this button can access this boolean at the moment, so no locks are needed
            

            btnPlayback.Enabled = Recording;
            btnSaveRec.Enabled = Recording;
            //Now adjust the state of recording since it is currently a toggle at the current moment
            toggleRecordingState();
        }

        /// <summary>
        /// Flip the Boolean and change the state of recording based off of it
        /// </summary>
        private void toggleRecordingState()
        {
            Recording = !Recording;
            //Change Behavior based off of the new boolean, not the previous boolean
            if (Recording)
            {
                //Double check that memory is properly disposed of
                resetRecordingPlaybackPlayer();
                //Signify that the program is currently Recording
                btnRecord.BackColor = Color.Red;
                //Instatiate the recorder and the file writer
                String recordingPath = SoundPath + "\\Recording\\Temp.wav";

                //Instatiate the WaveIn
                AudioRecorder = new WaveIn();
                AudioRecorder.DeviceNumber = cboxInputDevices.SelectedIndex;
                RecordHelper.StartRecordingIn(AudioWriter, AudioRecorder, recordingPath);
            }
            else
            {
                btnRecord.BackColor = Color.Gray;
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
            PlaybackPlayer.Volume = 0.01f * tbarVolume.Value;
        }

        /// <summary>
        /// Gets the Recording device currently selected by the user and returns it as an MMDevice Object for Wasapi purposes
        /// </summary>
        /// <returns></returns>
        private MMDevice getSelectedRecordingDevice()
        {
            var deviceEnumerator = new MMDeviceEnumerator();
            return deviceEnumerator.EnumerateAudioEndPoints(DataFlow.Capture, DeviceState.All)[cboxInputDevices.SelectedIndex];
        }

        private void btnPlayback_Click(object sender, EventArgs e)
        {
            if (!Recording)
            {
                //The path of the temporary file
                String TempPath = SoundPath + "\\Recording\\Temp.wav";
                RecordingPlaybackReader = new NAudio.Wave.WaveFileReader(TempPath);
                PlaybackPlayer.Init(RecordingPlaybackReader);
                PlaybackPlayer.Play();

            }
        }

        private void btnSaveRec_Click(object sender, EventArgs e)
        {
            String TempPath = SoundPath + "\\Recording\\Temp.wav";
            String SavePath = "";
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Filter = "wav files (*.wav)|*.wav|All files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                SavePath = saveFileDialog1.FileName;
                //Copy the Temp File over to the specified Save Path
                try
                {
                    System.IO.File.Copy(TempPath, SavePath, true);
                }
                catch(FileNotFoundException)
                {
                    MessageBox.Show("Error : Temporary Sound Storage Not Found", "File Not Found");
                    return;
                }
                catch (PathTooLongException)
                {
                    MessageBox.Show("Error : Specified path exceeds system length! Save to a different location!");
                    return;
                }
                catch (NotSupportedException nse)
                {
                    MessageBox.Show("Error : Specified file format not supported :\n" + nse.Message);
                    return;
                }
                btnPlayback.Enabled = false;
                btnRecord.Enabled = false;
                MessageBox.Show("Save Successful!");
            }
            else //As it is right now - this could be removed, but I'll leave it like this for now incase I think of anything
            {
                MessageBox.Show("Save Canceled");
                return;
            }
            
        }
    }
}
