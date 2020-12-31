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
       
        //STARTUP
        //------------------------------------------------------------------------------

        public frmSound()
        {
            InitializeComponent();
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



        // BUTTON EVENT HANDLERS
        // ----------------------------------------------------------------------------------



        private void btnPlay_Click(object sender, EventArgs e)
        {
            playSelectedSound();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            MediaCenter.StopMainPlayer();
            MediaCenter.StopPlaybackPlayer();
        }

        private void btnRecord_Click(object sender, EventArgs e)
        {
            //Since recording needs to be acted upon by shortcut as well - in a separate method
            toggleRecording();
        }

        private void btnPlayback_Click(object sender, EventArgs e)
        {
            MediaCenter.playbackRecording(SoundPath);
        }

        /// <summary>
        /// Event Handler : Invokes the RecordHelper.SaveRecording method on the temporary sound file.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSaveRec_Click(object sender, EventArgs e)
        {
            String TempPath = SoundPath + "\\Recording\\Temp.wav";
            //Invoke the save file method
            RecordHelper.SaveRecording(TempPath);
        }

        private void btnSetShortcut_Click(object sender, EventArgs e)
        {
            //Check for a selected Item
            if (lviewSounds.SelectedItems.Count == 0)
            {
                MessageBox.Show("No item is selected!", "Shortcut Error");
                return;
            }

            String keyCombo = InputHelper.getUserInputShortcut();

            //Now get the string the form assigned
            //Now pass the data to the sound repository - using the form reference that was passed to this form
            processShortcutSoundChange(keyCombo);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            refreshSoundData();
        }



        //------------------------------------------------------------------------------------

        //OTHER EVENT HANDLERS

        //-------------------------------------------------------------------------------------
        private void cboxGroups_SelectedIndexChanged(object sender, EventArgs e)
        {
            lviewSounds.Items.Clear();
            //Incase the combobox is cleared - don't fire any code or more exceptions will happen
            if (cboxGroups.SelectedIndex < 0)
            {
                return;
            }

            //Fill out the list of SoundFiles based on the group that has been selected
            foreach (SoundFile soundFile in SoundData.SoundFiles[cboxGroups.SelectedItem.ToString()])
            {
                //Remove the .mp3 Extension (or .wav since that format is now current supported)
                StringBuilder noMp3Name = new StringBuilder(soundFile.soundName);
                noMp3Name.Remove(noMp3Name.Length - 4, 4);
                //Create a string array of attributes
                String[] itemArray = { noMp3Name.ToString(), "0" };
                //Convert the attributes into a List View format
                ListViewItem lviewItem = new ListViewItem(itemArray);
                //And then add them to the path
                lviewItem.Tag = soundFile.filePath;
                lviewSounds.Items.Add(lviewItem);

            }
            lviewSounds.Items[0].Selected = true;
        }

        private void tbarVolume_Scroll(object sender, EventArgs e)
        {
            MediaCenter.setVolume(.01f * tbarVolume.Value);
        }

        private void frmSound_KeyDown(object sender, KeyEventArgs keyEvent)
        {
            if (!InputHelper.NoShortcutAlone.Contains(keyEvent.KeyCode))
            {

                String keyCombo = InputHelper.convertKeyInputToString(keyEvent, Form.ModifierKeys);
                //First we need to determine if a base shortcut (e.x. Stop) was invoked before deciding if a sound is being played or not
                if (InputHelper.BaseShortcuts.ContainsKey(keyCombo))
                {
                    //Invoke the processing method
                    processBaseShortcut(InputHelper.BaseShortcuts[keyCombo]);
                }
                playShortcutSound(keyCombo);
            }
        }

        private void tsmiSoundShortcuts_Click(object sender, EventArgs e)
        {
            frmShortcutManager sManager = new frmShortcutManager(this);
            sManager.Show();
        }

        private void tsmiBasicKeybinds_Click(object sender, EventArgs e)
        {
            frmKeybind keyManager = new frmKeybind();
            keyManager.Show();
        }

        private void lviewSounds_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        //--------------------------------------------------------------------------------------------

        // HELPER METHODS
        
        
        //---------------------------------------------------------------------------------------------

        /// <summary>
        /// Plays the currently selected sound on lviewSounds with the selected device from cboxOutputDevices
        /// </summary>
        private void playSelectedSound()
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
            String result = MediaCenter.playSound(lviewSounds.SelectedItems[0].Tag.ToString(), cboxOutputDevices.SelectedIndex);
            //Check if an exception occurred
            if (!result.Equals(""))
            {
                MessageBox.Show("Playback Exception for '" + lviewSounds.SelectedItems[0].SubItems[0].Text + "' : \n" + result, "Playback Exception");
                //SoundData.clearShortcutSound(keyCombo);
            }

            //NAudio.Wave.DirectSoundOut.
            //            var device = new MMDeviceEnumerator();
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

        /// <summary>
        /// A method for invoking recording functions.
        /// </summary>
        private void toggleRecording()
        {
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

        public void processShortcutSoundChange(String keyCombo)
        {
            String soundTest = SoundData.getShortcutSound(keyCombo);
            if (soundTest != null)
            {
                String[] soundTestSplit = soundTest.Split('\\');
                //Ask if the user wants to override the shortcut
                DialogResult overrideChoice = MessageBox.Show("Key combination '" + keyCombo + "' is already bound to '" + soundTestSplit[soundTestSplit.Length - 1] +
                    "\nDo you wish to overide?", "Collision Notice", MessageBoxButtons.YesNo);
                if (overrideChoice == DialogResult.No)
                {
                    //Don't override, stop processing
                    return;
                }

            }
            //Set the shortcut in the options
            SoundData.setShortcutSound(keyCombo, lviewSounds.SelectedItems[0].Tag.ToString());
        }

        /// <summary>
        /// This function when given the name of a keybound action will process and execute that action if it is allowed
        /// </summary>
        /// <param name="actionName"></param>
        private void processBaseShortcut(String actionName)
        {
            switch (actionName) {
                case "Play":
                    //Call the method for playing a sound effect
                    playSelectedSound();
                    break;
                case "Stop":
                    MediaCenter.StopMainPlayer();
                    MediaCenter.StopPlaybackPlayer();
                    break;
                case "Record":
                    toggleRecording();
                    break;
                case "Playback":
                    MediaCenter.playbackRecording(SoundPath);
                    break;
                //Do nothing if not a base shortcut for this form
                default:
                    break;

            }
        }
        
        private void playShortcutSound(String keyCombo)
        {
            //Now convert the input into a shortcut if there is one
            String filePath = SoundData.getShortcutSound(keyCombo);
            //Check for null filepath - means no shortcut
            if (filePath != null) {
                String result = MediaCenter.playSound(filePath, cboxOutputDevices.SelectedIndex);
                //If the file is not found - notify the user and remove the shortcut
                if(!result.Equals(""))
                {
                    MessageBox.Show("Shortcut Playback Exception for combination '" + keyCombo +  "' : \n" + result, "Playback Exception");
                    //SoundData.clearShortcutSound(keyCombo);
                }
            }
        }

        
    }
}
