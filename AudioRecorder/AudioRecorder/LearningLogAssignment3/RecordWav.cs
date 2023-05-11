﻿// Updated: January 12, 2023
// Description:
// Records audio using the default recording device, into a file in a default directory (relative to
// where this file is stored). Just two functions: StartRecording() and EndRecording().
// This class adapts and utilizes code from Darin Dimitrov @ https://stackoverflow.com/a/3694293 .

using System;
using System.IO;
using System.Runtime.InteropServices;

// Note to students: you will probably need to change this namespace to match your project.
namespace LearningLogDemo
{
    internal static class RecordWav
    {
        // This part is entirely from Darin Dimitrov @ https://stackoverflow.com/a/3694293 .
        [DllImport("winmm.dll", EntryPoint = "mciSendStringA", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        private static extern int mciSendString(string lpstrCommand, string lpstrReturnString, int uReturnLength, int hwndCallback);

        /// <summary>
        /// Begins a .wav file recording using winmm.dll .
        /// </summary>
        internal static void StartRecording()
        {
            mciSendString("open new Type waveaudio Alias recsound", "", 0, 0);
            mciSendString("record recsound", "", 0, 0);
        }

        /// <summary>
        /// Ends a started .wav file recording using winmm.dll .
        /// </summary>
        /// <returns>A FileInfo object pointing to the resulting .wav file.</returns>
        internal static FileInfo EndRecording()
        {
            string fileName = "..//..//..//Data//Recording" + DateTime.Now.ToString("yyyyMMdd") + ".wav";
            
            mciSendString("save recsound " + fileName, "", 0, 0);
            mciSendString("close recsound ", "", 0, 0);

            FileInfo returnFile = new FileInfo(fileName);
            return returnFile;
        }

    }
}
