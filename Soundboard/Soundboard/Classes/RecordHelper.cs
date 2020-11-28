using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Soundboard.Classes
{
    public static class RecordHelper
    {

        /// <summary>
        /// Handles recording of an input device.
        /// </summary>
        /// <param name="audioWriter">Records the sound data to the specified filepath</param>
        /// <param name="audioRecorder">WaveIn Object set to the currently selected input device</param>
        /// <param name="filePath">Where to save the recorded sound data</param>
        /// <returns>True if successful, false if not</returns>
        public static bool StartRecordingIn(WaveFileWriter audioWriter, WaveIn audioRecorder, String filePath)
        {
            try
            {
                audioWriter = new WaveFileWriter(filePath, audioRecorder.WaveFormat);
            }
            //A little lazy, but I will display the exception name in the popup
            catch (Exception ex)
            {
                MessageBox.Show("An error has occured : \n" + ex.Message, ex.GetType().Name);
                return false;
            }
            //Setup the Recording Event Handlers
            audioRecorder.DataAvailable += (s, audioArgs) =>
            {
                audioWriter.Write(audioArgs.Buffer, 0, audioArgs.BytesRecorded);
            };
            audioRecorder.RecordingStopped += (s, a) =>
            {
                audioWriter.Dispose();
                audioRecorder.Dispose();
                audioWriter = null;
            };

            audioRecorder.StartRecording();

            return true;
        }
    }
}
