using NAudio;
using NAudio.Wave;
using Soundboard.Classes;
using System;
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
        public frmSound()
        {
            InitializeComponent();
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
            MainPlayer.DeviceNumber = cboxSoundDevices.SelectedIndex;
            //MainPlayer.Volume = .01f * (float)tbarVolume.Value;
            Mp3FileReader mp3Reader = new NAudio.Wave.Mp3FileReader((String)lviewSounds.SelectedItems[0].Tag);
            MainPlayer.Init(mp3Reader);
            MainPlayer.Play();
            
            
            //NAudio.Wave.DirectSoundOut.
//            var device = new MMDeviceEnumerator();
        }

        private void lviewSounds_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void frmSound_Load(object sender, EventArgs e)
        { 
            //Load all of the sound devices
            cboxSoundDevices.Items.Clear();
            for (int deviceId = 0; deviceId < NAudio.Wave.WaveOut.DeviceCount; deviceId++)
            {
                var capabilities = NAudio.Wave.WaveOut.GetCapabilities(deviceId);
                cboxSoundDevices.Items.Add(capabilities.ProductName);
            }
            cboxSoundDevices.SelectedIndex = 0;

            SoundPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\Sounds";

            //Acquire the sound data
            refreshSoundData();

            MainPlayer = new NAudio.Wave.WaveOut();
            tbarVolume.Value = 50;
        }

        /// <summary>
        /// Reacquires the list of sound files in the data repository
        /// </summary>
        private void refreshSoundData()
        {
            //foreach(System.IO.Directory.GetFiles(SoundPath, "*.mp3"))
            SoundFileFactory fileCreator = new SoundFileFactory(System.IO.Directory.GetFiles(SoundPath, "*.mp3", SearchOption.AllDirectories));
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

            foreach(SoundFile soundFile in SoundData.SoundFiles[cboxGroups.SelectedItem.ToString()])
            {
                StringBuilder noMp3Name = new StringBuilder(soundFile.soundName);
                noMp3Name.Remove(noMp3Name.Length - 4, 4);
                String[] itemArray = { noMp3Name.ToString(), "0"};
                ListViewItem lviewItem = new ListViewItem(itemArray);
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
        }
    }
}
