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
    using System.Windows.Forms;
    using PdBets;

    /// <summary>
    /// Main form.
    /// </summary>
    [Export(typeof(IPdBets))]
    public partial class MainForm : Form, IPdBets
    {
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
            // Return passed bet string
            return betString;
        }

        /// <summary>
        /// Raises the open file button click event.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void OnOpenFileButtonClick(object sender, EventArgs e)
        {
			
        }

        /// <summary>
        /// Raises the next button click event.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void OnNextButtonClick(object sender, EventArgs e)
        {
			
        }

        /// <summary>
        /// Raises the undo button click event.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void OnUndoButtonClick(object sender, EventArgs e)
        {
			
        }

        /// <summary>
        /// Raises the run button click event.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void OnRunButtonClick(object sender, EventArgs e)
        {
			
        }

        /// <summary>
        /// Raises the new tool strip button click event.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void OnNewToolStripButtonClick(object sender, EventArgs e)
        {
			
        }

        /// <summary>
        /// Raises the about tool strip button click event.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void OnAboutToolStripButtonClick(object sender, EventArgs e)
        {
			
        }

        /// <summary>
        /// Raises the exit tool strip menu item click event.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void OnExitToolStripMenuItemClick(object sender, EventArgs e)
        {
			
        }

        /// <summary>
        /// Raises the always on top tool strip menu item click event.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void OnAlwaysOnTopToolStripMenuItemClick(object sender, EventArgs e)
        {
			
        }
    }
}