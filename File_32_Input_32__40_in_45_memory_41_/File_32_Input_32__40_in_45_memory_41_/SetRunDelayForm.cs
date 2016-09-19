﻿// <copyright file="SetRunDelayForm.cs" company="www.PublicDomain.tech">All rights waived.</copyright>

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
/// Set run delay form.
/// </summary>
namespace File_32_Input_32__40_in_45_memory_41_
{
    // Directives
    using System;
    using System.Drawing;
    using System.Windows.Forms;

    /// <summary>
    /// Set run delay form.
    /// </summary>
    public partial class SetRunDelayForm : Form
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="File_32_Input_32__40_in_45_memory_41_.SetRunDelayForm"/> class.
        /// </summary>
        /// <param name="currentDelay">Current delay.</param>
        public SetRunDelayForm(int currentDelay)
        {
            // The InitializeComponent() call is required for Windows Forms designer support.
            this.InitializeComponent();

            // Set current delay as edit delay combo box text
            this.editDelayComboBox.Text = currentDelay.ToString();
        }

        /// <summary>
        /// Gets or sets the current delay value.
        /// </summary>
        /// <value>The current delay value.</value>
        public int CurrentDelayValue { get; set; }

        /// <summary>
        /// Raises the set value button click event.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void OnSetValueButtonClick(object sender, EventArgs e)
        {
            // Declare new current delay
            int newCurrentDelay;

            // Try to parse new value
            if (int.TryParse(this.editDelayComboBox.Text, out newCurrentDelay))
            {
                // Set new current delay value property
                this.CurrentDelayValue = newCurrentDelay;

                // Close dialog
                this.Close();
            }
        }
    }
}
