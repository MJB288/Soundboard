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
                MessageBox.Show("An error has occured during recording : \n" + ex.Message, ex.GetType().Name);
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

        /// <summary>
        /// Opens a save file dialog and prompts the user where to save their file
        /// </summary>
        /// <param name="recordingPath"></param>
        public static void SaveRecording(String recordingPath)
        {
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
                    System.IO.File.Copy(recordingPath, SavePath, true);
                }
                catch (FileNotFoundException)
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
                
                MessageBox.Show("Save Successful!");
            }
            else //As it is right now - this could be removed, but I'll leave it like this for now incase I think of anything
            {
                MessageBox.Show("Save Canceled!");
                return;
            }
        }
    }
}
