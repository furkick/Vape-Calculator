using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VapeCalculator.liteDB;
using VapeCalculator.Models;
using VapeCalculator.Validation;

namespace VapeCalculator.Forms
{
    public partial class ViewFlavoursForm : Form
    {

        LiteDBFlavourRepo _dbFlavour;

        public ViewFlavoursForm()
        {
            _dbFlavour = new LiteDBFlavourRepo();
            InitializeComponent();

            // Define the border style of the form to a dialog box.
            this.FormBorderStyle = FormBorderStyle.FixedDialog;

            // Set the MaximizeBox to false to remove the maximize box.
            this.MaximizeBox = false;

            // Set the start position of the form to the center of the screen.
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void ViewFlavoursForm_Load(object sender, EventArgs e)
        {
            SetUpFlavourList();
        }

        private void LoadFlavours()
        {
            // Load all existing flavours
            lstFlavours.DataSource = _dbFlavour.GetAllFlavourProfiles().ToList();
            lstFlavours.DisplayMember = "FlavourName";
            lstFlavours.ValueMember = "Id";
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            // Get the selected flavour
            var selectedProfile = lstFlavours.GetItemText(lstFlavours.SelectedValue);
            
            // If last flavour refresh the form
            if (selectedProfile == "1")
            {
                RemoveFlavour();
                ClearForm();
            }
            else if (selectedProfile != null && selectedProfile != "")
            {
                RemoveFlavour();
            }
            else
            {
                ClearForm();
            }

            // Reload flavours
            LoadFlavours();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            FlavourModel data = new FlavourModel();

            // Check we actually have values.
            data.Id = lstFlavours.SelectedValue == null ? -2 : int.Parse(lstFlavours.GetItemText(lstFlavours.SelectedValue));
            data.FlavourName = txtFlavourName.Text == "" ? "" : txtFlavourName.Text;
            data.Weight = txtFlavourWeight.Text == "" ? -1 : decimal.Parse(txtFlavourWeight.Text);

            ValidateFlavour validate = new ValidateFlavour();
            
            // Validate the form
            if (validate.ValidateNewFlavour(data).Passed)
            {
                // If existing then show message
                if (_dbFlavour.UpdateFlavourProfile(data))
                    MessageBox.Show("Flavour Updated");

                LoadFlavours();
            }
            else
            {
                MessageBox.Show(validate.ValidateNewFlavour(data).ErrorMessage);
            }            
        }

        private void btnNewFlavour_Click(object sender, EventArgs e)
        {
            // Create a new flavour
            NewFlavourForm();
        }

        private void NewFlavourForm()
        {
            // Show new flavour form
            var newFlavour = new NewFlavourForm();
            newFlavour.FormClosed += NewFlavourFormClosed;
            newFlavour.Show();
        }

        private void SetUpFlavourList()
        {
            // Set default to non selected
            lstFlavours.SelectedIndexChanged -= lstFlavours_SelectedIndexChanged;

            // Load in flavours
            LoadFlavours();

            // Set default to non selected
            lstFlavours.SelectedIndexChanged += lstFlavours_SelectedIndexChanged;
            lstFlavours.SelectedIndex = -1;
        }

        void NewFlavourFormClosed(object sender, FormClosedEventArgs e)
        {
            // Load in flavours again on close to ensure new are in drop downs
            LoadFlavours();
        }

        private void lstFlavours_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Get selected flavour.
            var selectedFlavour = lstFlavours.GetItemText(lstFlavours.SelectedIndex);

            FlavourModel profile = new FlavourModel();

            // Do we actually have one selected?
            if (selectedFlavour != null && selectedFlavour != "" && selectedFlavour != "-1")
            {
                var profileId = int.Parse(lstFlavours.GetItemText(lstFlavours.SelectedValue));

                profile = _dbFlavour.GetFlavourProfileById(profileId);

                // Show current values
                txtFlavourName.Text = profile.FlavourName;
                txtFlavourWeight.Text = profile.Weight.ToString();
            }
        }

        private bool RemoveFlavour()
        {
            // Remove a flavour
            var profileId = int.Parse(lstFlavours.GetItemText(lstFlavours.SelectedValue));

            return _dbFlavour.RemoveFlavourProfile(profileId);
        }

        private void ClearForm()
        {
            // Clear the form
            txtFlavourName.Text = "";
            txtFlavourWeight.Text = "";
        }
    }
}
