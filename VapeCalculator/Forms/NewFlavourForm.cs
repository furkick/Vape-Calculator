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
    public partial class NewFlavourForm : Form
    {
        LiteDBFlavourRepo _dbFlavour;

        public NewFlavourForm()
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

        private void btnAddFlavour_Click(object sender, EventArgs e)
        {
            FlavourModel flavour = new FlavourModel();

            // Set defaults
            flavour.FlavourName = txtFlavourName.Text == "" ? "" : txtFlavourName.Text;
            flavour.Weight = txtFlavourWeight.Text == "" ? -1 : decimal.Parse(txtFlavourWeight.Text);

            ValidateFlavour validate = new ValidateFlavour();

            // Insert flavour and show message.
            if (validate.ValidateNewFlavour(flavour).Passed)
            {
                _dbFlavour.InsertFlavourProfile(flavour);

                this.Close();

                MessageBox.Show("Added new flavour: " + flavour.FlavourName);
            }
            else
            {
                MessageBox.Show(validate.ValidateNewFlavour(flavour).ErrorMessage);
            }

            
        }
    }
}
