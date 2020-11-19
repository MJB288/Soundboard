﻿using NAudio;
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
        private Boolean Recording;
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
            MainPlayer.DeviceNumber = cboxSoundDevices.SelectedIndex;
            //MainPlayer.Volume = .01f * (float)tbarVolume.Value;
            
            if(lviewSounds.SelectedItems[0].Tag.ToString()[lviewSounds.SelectedItems[0].Tag.ToString().Length - 1] == '3')
            {
                Mp3FileReader mp3Reader = new NAudio.Wave.Mp3FileReader((String)lviewSounds.SelectedItems[0].Tag);
                MainPlayer.Init(mp3Reader);
                MainPlayer.Play();
            }
            else if(lviewSounds.SelectedItems[0].Tag.ToString().ToLower()[lviewSounds.SelectedItems[0].Tag.ToString().Length - 1] == 'v')
            {
                WaveFileReader wavReader = new NAudio.Wave.WaveFileReader((String)lviewSounds.SelectedItems[0].Tag);
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
            //Load all of the sound devices
            cboxSoundDevices.Items.Clear();
            for (int deviceId = 0; deviceId < NAudio.Wave.WaveOut.DeviceCount; deviceId++)
            {
                var capabilities = NAudio.Wave.WaveOut.GetCapabilities(deviceId);
                cboxSoundDevices.Items.Add(capabilities.ProductName);
            }
            cboxSoundDevices.SelectedIndex = 0;

            loadInputDevices();

            SoundPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\Sounds";

            //Acquire the sound data
            refreshSoundData();

            MainPlayer = new NAudio.Wave.WaveOut();
            tbarVolume.Value = 50;
            MainPlayer.Volume = 0.01f * tbarVolume.Value;

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

        /*private void loadSoundDevices(int deviceCount, NAudio)
        {

        }*/

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

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            refreshSoundData();
        }

        private void btnRecord_Click(object sender, EventArgs e)
        {
            //Only this button can access this boolean at the moment, so no locks are needed
            Recording = !Recording;
            //Change Behavior based off of the new boolean, not the previous boolean
            if (Recording)
            {
                btnRecord.BackColor = Color.Red;
            }
            else
            {
                btnRecord.BackColor = Color.Gray;
            }
        }
    }
}
