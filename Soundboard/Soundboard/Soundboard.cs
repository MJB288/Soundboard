using NAudio;
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
            using (FileStream fs = new FileStream("hellothere.wav", FileMode.Open, FileAccess.Write, FileShare.ReadWrite))
            {
                var waveReader = new NAudio.Wave.WaveFileReader("hellothere1.wav");
                var waveIn = new NAudio.Wave.WaveIn();
                var waveOut = new NAudio.Wave.WaveOut();

                waveIn.DeviceNumber = 0;
                waveOut.DeviceNumber = cboxSoundDevices.SelectedIndex;
                
                var test = new NAudio.Wave.Mp3FileReader("hellothere.mp3");
                waveOut.Init(test);
                waveOut.Play();
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

            SoundPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\Sounds";

            //Acquire the sound data
            refreshSoundData();

            
        }

        /// <summary>
        /// Reacquires the list of sound files in the data repository
        /// </summary>
        private void refreshSoundData()
        {
            SoundFileFactory fileCreator = new SoundFileFactory(System.IO.Directory.GetFiles(SoundPath, "*.mp3"));
            SoundData = new SoundRepository(fileCreator.constructSoundFiles());

        }
    }
}
