﻿#region License Information (GPL v3)

/*
    ShareX - A program that allows you to take screenshots and share any file type
    Copyright (c) 2007-2022 ShareX Team

    This program is free software; you can redistribute it and/or
    modify it under the terms of the GNU General Public License
    as published by the Free Software Foundation; either version 2
    of the License, or (at your option) any later version.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with this program; if not, write to the Free Software
    Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301, USA.

    Optionally you can also view the license at <http://www.gnu.org/licenses/>.
*/

#endregion License Information (GPL v3)

using ShareX.HelpersLib;
using ShareX.Properties;
using ShareX.ScreenCaptureLib;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ShareX
{
    public partial class PinToScreenStartupForm : Form
    {
        public Bitmap Image { get; private set; }

        public PinToScreenStartupForm()
        {
            InitializeComponent();
            ShareXResources.ApplyTheme(this);
        }

        private void btnFromClipboard_Click(object sender, EventArgs e)
        {
            Image = ClipboardHelpers.TryGetImage();

            if (Image == null)
            {
                MessageBox.Show(Resources.ClipboardDoesNotContainAnImage, "ShareX - " + Resources.PinToScreen, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void btnFromScreen_Click(object sender, EventArgs e)
        {
            Image = RegionCaptureTasks.GetRegionImage();

            if (Image != null)
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void btnFromFile_Click(object sender, EventArgs e)
        {
            Image = ImageHelpers.LoadImageWithFileDialog(this);

            if (Image != null)
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}