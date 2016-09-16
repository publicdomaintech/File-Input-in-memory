// <copyright file="MainForm.cs" company="www.PublicDomain.tech">All rights waived.</copyright>

// Programmed by Victor L. Senior (VLS) <support@publicdomain.tech>, 2016
//
// Web: http://publicdomain.tech
//
// Sources: http://github.com/publicdomaintech/
//
// This software and associated documentation files (the "Software") is
// released under the CC0 Public Domain Dedication, version 1.0, as
// published by Creative Commons. To the extent possible under law, the
// author(s) have dedicated all copyright and related and neighboring
// rights to the Software to the public domain worldwide. The Software is
// distributed WITHOUT ANY WARRANTY.
//
// If you did not receive a copy of the CC0 Public Domain Dedication
// along with the Software, see
// <http://creativecommons.org/publicdomain/zero/1.0/>

/// <summary>
/// File Input (in-memory)
/// </summary>
namespace File_32_Input_32__40_in_45_memory_41_
{
    // Directives
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.Composition;
    using System.Drawing;
    using System.IO;
    using System.Text.RegularExpressions;
    using System.Windows.Forms;
    using PdBets;

    /// <summary>
    /// Main form.
    /// </summary>
    [Export(typeof(IPdBets))]
    public partial class MainForm : Form, IPdBets
    {
        /// <summary>
        /// The loaded numbers list.
        /// </summary>
        private List<int> loadedNumbersList = new List<int>();

        /// <summary>
        /// The list pointer.
        /// </summary>
        private int listPointer = 0;

        /// <summary>
        /// Running flag
        /// </summary>
        private bool isRunning = false;

        /// <summary>
        /// The roulette class instance.
        /// </summary>
        private Roulette roulette = new Roulette();

        /// <summary>
        /// Initializes a new instance of the <see cref="File_32_Input_32__40_in_45_memory_41_.MainForm"/> class.
        /// </summary>
        public MainForm()
        {
            // The InitializeComponent() call is required for Windows Forms designer support.
            this.InitializeComponent();
        }

        /// <summary>
        /// Occurs when new input is sent.
        /// </summary>
        public event EventHandler<NewInputEventArgs> NewInput;

        /// <summary>
        /// Processes incoming input and bet strings.
        /// </summary>
        /// <param name="inputString">Input string.</param>
        /// <param name="betString">Bet string.</param>
        /// <returns>>The processed input string.</returns>
        public string Input(string inputString, string betString)
        {
            // Check if must loop
            if (inputString == "-L" && this.isRunning)
            {
                // Send next number
                this.SendNextNumber();
            }

            // Return passed bet string
            return betString;
        }

        /// <summary>
        /// Sends the next number.
        /// </summary>
        private void SendNextNumber()
        {
            // Check there's something to work with and pointer is within range
            if (this.loadedNumbersList.Count < 1 || this.listPointer > (this.loadedNumbersList.Count - 1))
            {
                // Exit
                return;
            }

            // Send number to pdBets
            this.NewInput(this.nextButton, new NewInputEventArgs(this.loadedNumbersList[this.listPointer].ToString()));

            // Rise list pointer
            this.listPointer++;
        }

        /// <summary>
        /// Raises the open file button click event.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void OnOpenFileButtonClick(object sender, EventArgs e)
        {
            // Show open file dialog and check for dialog result OK
            if (this.mainOpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Check for empty file
                    if (new System.IO.FileInfo(this.mainOpenFileDialog.FileName).Length == 0)
                    {
                        // Nothing to work with, halt flow
                        return;
                    }

                    /* Read file to memory */

                    // Reset list pointer
                    this.listPointer = 0;

                    // Reset loaded numbers list
                    this.loadedNumbersList.Clear();

                    // Make use of StreamReader
                    using (StreamReader sr = new StreamReader(this.mainOpenFileDialog.FileName))
                    {
                        // Declare current line
                        string currentLine;

                        // Iterate through all lines in file
                        while ((currentLine = sr.ReadLine()) != null)
                        {
                            // Process numbers only
                            currentLine = Regex.Replace(currentLine, "[^0-9]", string.Empty);

                            // Check there's something
                            if (currentLine.Length == 0)
                            {
                                // Next iteration
                                continue;
                            }

                            // Check if line contains a valid roulette number
                            if (this.roulette.ValidateRouletteNumber(currentLine))
                            {
                                // Valid number, add to list
                                this.loadedNumbersList.Add(this.roulette.GetRouletteNumber(currentLine));
                            }
                        }
                    }

                    // Update number left status label
                    this.numbersLeftCountToolStripStatusLabel.Text = this.loadedNumbersList.Count.ToString();
                }
                catch (Exception ex)
                {
                    // Error message
                    MessageBox.Show("Error while reading file from disk." + Environment.NewLine + "Error message: " + ex.Message, "File read error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Raises the next button click event.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void OnNextButtonClick(object sender, EventArgs e)
        {
            // Send next number
            this.SendNextNumber();
        }

        /// <summary>
        /// Raises the undo button click event.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void OnUndoButtonClick(object sender, EventArgs e)
        {
            // Send "undo" message
            this.NewInput(this.nextButton, new NewInputEventArgs("-U"));

            // Check list pointer
            if (this.listPointer > 0)
            {
                // Decrement list pointer
                this.listPointer--;
            }
        }

        /// <summary>
        /// Raises the run button click event.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void OnRunButtonClick(object sender, EventArgs e)
        {
            // Code here
        }

        /// <summary>
        /// Raises the new tool strip button click event.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void OnNewToolStripButtonClick(object sender, EventArgs e)
        {
            // Code here
        }

        /// <summary>
        /// Raises the about tool strip button click event.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void OnAboutToolStripButtonClick(object sender, EventArgs e)
        {
            // Code here
        }

        /// <summary>
        /// Raises the exit tool strip menu item click event.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void OnExitToolStripMenuItemClick(object sender, EventArgs e)
        {
            // Code here
        }

        /// <summary>
        /// Raises the always on top tool strip menu item click event.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void OnAlwaysOnTopToolStripMenuItemClick(object sender, EventArgs e)
        {
            // Code here
        }
    }
}