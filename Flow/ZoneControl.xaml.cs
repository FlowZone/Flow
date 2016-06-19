//------------------------------------------------------------------------------
// <copyright file="ZoneControl.xaml.cs" company="Company">
//     Copyright (c) Company.  All rights reserved.
// </copyright>
//------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Windows.Forms;

namespace Flow
{
    using System.Diagnostics.CodeAnalysis;
    using System.Windows;
    using System.Windows.Controls;

    /// <summary>
    /// Interaction logic for ZoneControl.
    /// </summary>
    public partial class ZoneControl : UserControl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ZoneControl"/> class.
        /// </summary>

        private List<Item> items;

        private int totalItems;
        private int currentItem;

        public ZoneControl()
        {
            totalItems = 0;
            currentItem = 0;
            items = new List<Item>();
            this.InitializeComponent();
        }

        /// <summary>
        /// Handles click on the button by displaying a message box.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event args.</param>
        [SuppressMessage("Microsoft.Globalization", "CA1300:SpecifyMessageBoxOptions", Justification = "Sample code")]
        [SuppressMessage("StyleCop.CSharp.NamingRules", "SA1300:ElementMustBeginWithUpperCaseLetter", Justification = "Default event handler naming pattern")]
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(
                string.Format(System.Globalization.CultureInfo.CurrentUICulture, "Invoked '{0}'", this.ToString()),
                "Zone");
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            var edit = new EditItems(items);
            var result = edit.ShowDialog();
            if (result == DialogResult.OK)
            {
                SetItems(edit.returnItems);
            }
        }

        private void SetItems(List<Item> newItems)
        {
            if (newItems.Count >= 1)
            {
                this.items = newItems;
                totalItems = newItems.Count;
                currentItem = 1;
                UpdateItem();
            }
            else
            {
                totalItems = 0;
                currentItem = 0;
                UpdateItem();
            }
        }

        private void UpdateItem()
        {
            Counter.Text = string.Format("{0}/{1}", currentItem, totalItems);
            if (totalItems > 0)
            {
                Task.Text = items[currentItem - 1].Task;
                Title.Text = items[currentItem - 1].Title;
            }
            

        }

        private void Previous_Click(object sender, RoutedEventArgs e)
        {
            if (currentItem > 1)
            {
                currentItem--;
                UpdateItem();
            }
        }

        private void Next_Click(object sender, RoutedEventArgs e)
        {
            if (currentItem < totalItems)
            {
                currentItem++;
                UpdateItem();
            }
        }
    }
}