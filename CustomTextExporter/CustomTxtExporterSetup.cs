using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CustomTxtExporter
{
    public partial class CustomTxtExporterSetup : Form
    {
        private readonly ExporterSettings _exportSettings = null;

        public CustomTxtExporterSetup(ExporterSettings settings)
        {
            _exportSettings = settings;
            InitializeComponent();

            UpdateForm();
        }

        private void UpdateForm()
        {
            cboOverride.Checked = _exportSettings.OverRideDefault;
            cboUseImageFileName.Checked = _exportSettings.UseImageFileName;
            txtDestination.Text = _exportSettings.Destination;
        }

        private void cboOverride_CheckedChanged(object sender, EventArgs e)
        {
            if (cboOverride.Checked)
            {
                cboUseImageFileName.Enabled = true;
                txtDestination.Enabled = true;
                btnBrowse.Enabled = true;
            }
            else
            {
                cboUseImageFileName.Enabled = false;
                txtDestination.Enabled = false;
                btnBrowse.Enabled = false;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _exportSettings.OverRideDefault = cboOverride.Checked;
            _exportSettings.UseImageFileName = cboUseImageFileName.Checked;
            _exportSettings.Destination = txtDestination.Text;

            DialogResult = DialogResult.OK;
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderDialog = new FolderBrowserDialog {SelectedPath = txtDestination.Text};

            if (folderDialog.ShowDialog() != DialogResult.OK) return;

            txtDestination.Text = folderDialog.SelectedPath;
        }
    }
}
