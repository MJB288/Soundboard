using NAudio;
using NAudio.CoreAudioApi;
using NAudio.Wave;
using Soundboard.Classes;
using Soundboard.Forms;
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

namespace Soundboard.Forms
{
    public partial class frmSound : Form
    {
        public SoundRepository SoundData;
        private String SoundPath;
        private SEMediaPlayer MediaCenter;
       

        public frmSound()
        {
            InitializeComponent();
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            if (lviewSounds.SelectedItems.Count == 0)
            {
                MessageBox.Show("No item is selected!", "Play Error");
                return;
            }
            if (MediaCenter.MPisPlaying() || MediaCenter.MPisPaused())
            {
                MediaCenter.StopMainPlayer();
            }
            //Play the sound and get the result
            int result = MediaCenter.playSound(lviewSounds.SelectedItems[0].Tag.ToString(), cboxOutputDevices.SelectedIndex);
            if (result == -1)
            {
                MessageBox.Show("Error : File Could not be found : \n" + lviewSounds.SelectedItems[0].Tag.ToString());
            }

            //NAudio.Wave.DirectSoundOut.
            //            var device = new MMDeviceEnumerator();
        }

        private void lviewSounds_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void frmSound_Load(object sender, EventArgs e)
        {
            this.KeyDown += frmSound_KeyDown;
            //Load all of the sound devices for both input and output
            loadInputDevices();
            loadOutputDevices();

            SoundPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\Sounds";
            //Instatiate the Recording Folder if necessary
            System.IO.Directory.CreateDirectory(SoundPath + "\\Recording");
            //Acquire the sound data
            refreshSoundData();

            //TODO - load previous volume level from memory
            tbarVolume.Value = 50;

            MediaCenter = new SEMediaPlayer(0.01f * tbarVolume.Value);
            
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
            MediaCenter.StopMainPlayer();
        }

        private void tbarVolume_Scroll(object sender, EventArgs e)
        {
            MediaCenter.setVolume(.01f * tbarVolume.Value);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            refreshSoundData();
        }

        private void btnRecord_Click(object sender, EventArgs e)
        {
            //Only this button can access this boolean at the moment, so no locks are needed


            btnPlayback.Enabled = MediaCenter.Recording;
            btnSaveRec.Enabled = MediaCenter.Recording;
            //Now adjust the state of recording since it is currently a toggle at the current moment
            MediaCenter.toggleRecordingState(cboxInputDevices.SelectedIndex, SoundPath);
            //Now the boolean is flipped, account for post-change logic
            if (MediaCenter.Recording)
            {
                btnRecord.BackColor = Color.Red;
            }
            else
            {
                btnRecord.BackColor = Color.Gray;
            }
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
            MediaCenter.playbackRecording(SoundPath);
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
                MessageBox.Show("Save Canceled!");
                return;
            }
            
        }

        private void btnSetShortcut_Click(object sender, EventArgs e)
        {
            //Check for a selected Item
            if (lviewSounds.SelectedItems.Count == 0)
            {
                MessageBox.Show("No item is selected!", "Shortcut Error");
                return;
            }
            //Open the form, passing the String filepath to be shortcutted
            frmShortcutForm assignShortcutform = new frmShortcutForm(lviewSounds.SelectedItems[0].Tag.ToString(), this);
            //We want the user to assign a shortcut, so therefore, lockout control from base form
            assignShortcutform.ShowDialog();
        }

        private void frmSound_KeyDown(object sender, KeyEventArgs keyEvent)
        {
            playShortcutSound("abcd");
        }

        private void playShortcutSound(String keyCombo)
        {
            MessageBox.Show(keyCombo);
        }
    }
}
