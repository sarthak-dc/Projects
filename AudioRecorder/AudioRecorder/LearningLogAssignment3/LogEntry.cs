// Author:  Sarthak Thukran
// Created: February 17, 2023
// Updated: March 8, 2023
// Description:
// A class that describes learning log entry objects. These have recordings, notes, quality and wellness ratings.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Navigation;

namespace LearningLogDemo
{
    internal class LogEntry
    {
        #region Declarations

        // Static variables.
        private static List<LogEntry> entryList = new List<LogEntry>();
        private static int count = 0;
        private static DateTime firstEntry = DateTime.MaxValue;
        private static DateTime newestEntry;

        // Instance variables.
        private int id = count;
        private DateTime entryDate = DateTime.Now;
        private FileInfo recordingFile;
        private string notes = String.Empty;

        // Constants for exception handling.
        internal const string NotesParameter = "Notes";

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor. Really just for inheritance and other shenanigans.
        /// </summary>
        public LogEntry()
        {
        }

        /// <summary>
        /// Parametrized constructor. Accepts various values for a new Learning LogEntry, validates them and set the new values.
        /// </summary>
        /// <param name="wellnessValue">Wellness at the time of the LogEntry; integer between 0-4.</param>
        /// <param name="qualityValue">Quality of the LogEntry; integer between 0-4.</param>
        /// <param name="notesValue">Written notes about the LogEntry.</param>
        /// <param name="recordingValue">A FileInfo object representing the location of the recording file.</param>
        public LogEntry(int wellnessValue, int qualityValue, string notesValue, FileInfo recordingValue)
        {
            Notes = notesValue;

            // Only proceed with creating the object if the notes are not empty.
            // Set the values in the class.
            Wellness = wellnessValue;
            Quality = qualityValue;
            recordingFile = recordingValue;

            // Increment or assign the static variables.
            count++;
            newestEntry = entryDate;

            // If this is the first LogEntry, set the firstEntry to the current date.
            if (entryDate < firstEntry)
            {
                firstEntry = entryDate;
            }

            entryList.Add(this);
        }

        #endregion

        #region Properties

        /// <summary>
        /// A unique identifier for the LogEntry.
        /// </summary>
        internal int Id { get; }

        /// <summary>
        /// The date that this entry was created.
        /// </summary>
        internal DateTime EntryDate { get => entryDate; }

        /// <summary>
        /// A numeric rating between 0-4 that represents how "well" the creator was when the Entry was made.
        /// </summary>
        internal int Wellness { get; set; }

        /// <summary>
        /// A numeric rating between 0-4 that represents the quality of this day's entry.
        /// </summary>
        internal int Quality { get; set; }

        /// <summary>
        /// The notes that the user wrote when the entry was made and saved.
        /// </summary>
        internal string Notes
        {
            get
            {
                return notes;
            }
            set
            {
                if (value.Trim() == String.Empty)
                {
                    throw new ArgumentNullException(NotesParameter, "You need to enter notes before saving this entry.");
                }
                else
                {
                    notes = value.Trim();
                }
            }
        }

        /// <summary>
        /// Identifies the recording file generated as part of this learning log entry.
        /// </summary>
        internal FileInfo RecordingFile { get => recordingFile; }

        /// <summary>
        /// The number of LogEntry objects that exist.
        /// </summary>
        static internal int Count {get => count;}
        
        /// <summary>
        /// The creation date/time of the first LogEntry object.
        /// </summary>
        static internal DateTime FirstEntry { get => firstEntry; }

        /// <summary>
        /// The creation date/time of the newest LogEntry object.
        /// </summary>
        static internal DateTime NewestEntry {  get => newestEntry; }
        #endregion

        /// <summary>
        /// Return the list of completed entries.
        /// </summary>
        static internal List<LogEntry> List { get => entryList; }

        #region Methods

        // Returns a string that represents the current object.
        public override string ToString()
        {
            return "Entry " + id + " entered on " + EntryDate.ToString() + " with quality rating " + Quality;
        }

        #endregion
    }
}
