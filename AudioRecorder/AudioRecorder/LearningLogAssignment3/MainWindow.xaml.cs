// Author:  Sarthak Thukran
// Created: February 8, 2023
// Updated: March 8, 2023
// Description:
// This is the form code for a form that creates a recording for the purpose of showing successive learning. Allows you to record, make notes, and select a quality and wellness rating, then saves the object.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Media;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LearningLogDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool isRecording = false;
        string filePath = String.Empty;

        /// <summary>
        /// Constructor for the MainWindow.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            buttonRecord.Focus();
            UpdateStatus("Application ready.");
            viewEntries.ItemsSource = LogEntry.List;
        }

        /// <summary>
        /// Start or end an audio recording using RecordWav.
        /// </summary>
        private void buttonRecord_Click(object sender, RoutedEventArgs e)
        {
            // If the application is currently recording audio...
            if (isRecording)
            {
                // Modify the button.
                labelRecordIcon.Content = "🎤";
                labelRecordText.Content = "_Record";
                // Modify the enabled state of buttons based on requirements.
                buttonRecord.IsEnabled = false;
                buttonPlay.IsEnabled = true;
                buttonDelete.IsEnabled = true;
                buttonSave.IsEnabled = true;
                // Stop the audio recording.
                isRecording = false;
                // Store the filename of the recorded .wav file in filePath.
                filePath = RecordWav.EndRecording().FullName;
                UpdateStatus("New recording file saved to " + filePath);
            }
            // If the application is NOT currently recording audio...
            else
            {
                // Modify the button.
                labelRecordIcon.Content = "🛑";
                labelRecordText.Content = "_Finish";
                // Start recording audio!
                isRecording = true;
                RecordWav.StartRecording();
                UpdateStatus("Recording started.");
            }
        }

        /// <summary>
        /// Play back the current sound file (supposing it exists!).
        /// </summary>
        private void buttonPlay_Click(object sender, RoutedEventArgs e)
        {
            // Attempt to play the file!
            try
            {
                var player = new SoundPlayer(filePath);
                player.Play();
                UpdateStatus("Played " + filePath);
            }
            // If the file isn't found, raise an error message.
            catch (FileNotFoundException error)
            {
                MessageBox.Show("The recording at " + filePath + " has been moved or deleted.\n"
                    + "\nMessage: " + error.Message
                    + "\nSource: " + error.Source
                    , "File Access Error");
                buttonPlay.IsEnabled = false;
                buttonRecord.IsEnabled = true;
                UpdateStatus("Error accessing " + filePath);
            }
            // If something else has gone wrong, give as much info as we have.
            catch (Exception error)
            {
                MessageBox.Show("An unknown error has taken place when accessing " + filePath + ". Please provide the follow information to your IT support personnel.:\n"
                    + "\nMessage: " + error.Message
                    + "\nSource: " + error.Source
                    + "\nType: " + error.GetType()
                    + "\nStack Trace: " + error.StackTrace
                    , "Unknown Error");
                UpdateStatus("Error accessing " + filePath);
            }
        }

        /// <summary>
        /// Me close form.
        /// </summary>
        private void buttonExit_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to close?", "Exit?", MessageBoxButton.YesNo);

            // Confirm whether the user wants to close the app.
            if (result == MessageBoxResult.Yes)
            {
                Close();
            }
        }

        /// <summary>
        /// Refresh the values on the Summary form when it is viewed.
        /// </summary>
        private void TabChanged(object sender, SelectionChangedEventArgs e)
        {
            // If the form is loaded and we're viewing the summary tab, get up-to-date values from the class.
            if (this.IsLoaded && tabTopLevel.SelectedItem == tabSummary)
            {
                textEntryCount.Text = LogEntry.Count.ToString();
                textFirstEntry.Text = LogEntry.FirstEntry.ToString();
                textNewestEntry.Text = LogEntry.NewestEntry.ToString();
                UpdateStatus("Viewed summary information.");
            }
            // If the List tab is viewed, just update the status bar.
            else if (this.IsLoaded && tabTopLevel.SelectedItem == tabList)
            {
                UpdateStatus("Viewed entry list.");
            }
        }

        /// <summary>
        /// Acts as if the recording were deleted so a new one needs to be created. Sets the form to more-or-less its default state.
        /// </summary>
        private void buttonDelete_Click(object sender, RoutedEventArgs e)
        {
            // Check that we can delete the file.
            try
            {
                // Store the filename of the recorded .wav file in filePath.
                File.Delete(filePath);
                filePath = String.Empty;

                // Modify the enabled state of buttons based on requirements.
                buttonRecord.IsEnabled = true;
                buttonPlay.IsEnabled = false;
                buttonDelete.IsEnabled = false;
                buttonSave.IsEnabled = false;

                UpdateStatus("Deleted the current learning log recording.");
            }
            // If the file doesn't exist, notify the user.
            catch (FileNotFoundException error)
            {
                MessageBox.Show("The recording at " + filePath + " cannot be deleted.\n"
                    + "\nMessage: " + error.Message
                    + "\nSource: " + error.Source
                    , "File Access Error");
                buttonDelete.IsEnabled = false;
                UpdateStatus("Cannot delete " + filePath);
            }
            // If something else goes wrong, give as much info as possible.
            catch (Exception error)
            {
                MessageBox.Show("An unknown error has taken place when accessing " + filePath + ". Please provide the follow information to your IT support personnel.:\n"
                    + "\nMessage: " + error.Message
                    + "\nSource: " + error.Source
                    + "\nType: " + error.GetType()
                    + "\nStack Trace: " + error.StackTrace
                    , "Unknown Error");
                UpdateStatus("Unknown error");
            }
        }

        /// <summary>
        /// Takes the data from the form and saves the entry as a LogEntry object.
        /// </summary>
        private void buttonSave_Click(object sender, RoutedEventArgs e)
        {
            // Takes any recording and any written notes and creates a LogEntry object.
            var myRecording = new FileInfo(filePath);

            try
            {
                // Create a new instance of your LogEntry class and passing in a FileInfo object and any notes that are written as parameters.
                var newEntry = new LogEntry(comboWellness.SelectedIndex, comboQuality.SelectedIndex, textNotes.Text, myRecording);

                // Once saved, the entire form should be cleared and effectively set back to its default state.
                buttonRecord.IsEnabled = true;
                buttonPlay.IsEnabled = false;
                buttonDelete.IsEnabled = false;
                buttonSave.IsEnabled = false;
                // Store the filename of the recorded .wav file in filePath.
                filePath = String.Empty;
                // Clear the notes box and set the comboboxes to their default state.
                textNotes.Clear();
                comboWellness.SelectedIndex = 2;
                comboQuality.SelectedIndex = 2;

                UpdateStatus(newEntry.ToString() + " saved to " + newEntry.RecordingFile.DirectoryName);
            }
            catch (ArgumentException error)
            {
                // If the notes are in error, show an error message and set focus.
                if (error.ParamName == LogEntry.NotesParameter)
                {
                    MessageBox.Show("The notes are empty or invalid.", "Entry Error");
                    textNotes.Focus();
                }
                // If another parameter is in error, we don't know what happened. Try to explain it.
                else
                {
                    MessageBox.Show("Cannot create this log entry; an unknown aspect is invalid.\n"
                    + "\nMessage: " + error.Message
                    , "Entry Error");
                }
                UpdateStatus("Cannot create entry");
            }
            // Catch anything else that could go wrong; provide as much info as we can.
            catch (Exception error)
            {
                MessageBox.Show("An unknown error has taken place creating the log entry. Please provide the follow information to your IT support personnel.:\n"
                    + "\nMessage: " + error.Message
                    + "\nSource: " + error.Source
                    + "\nType: " + error.GetType()
                    + "\nStack Trace: " + error.StackTrace
                    , "Unknown Error");
                UpdateStatus("Unknown error");
            }
        }

        /// <summary>
        /// Update the status bar displayed in the application using a message supplied by the user.
        /// </summary>
        /// <param name="message">The current status of the application</param>
        private void UpdateStatus(string message)
        {
            statusMessage.Content = DateTime.Now.ToString() + ": " + message;
        }

    }
}
