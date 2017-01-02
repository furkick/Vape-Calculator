using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VapeCalculator.Calculation;
using VapeCalculator.Forms;
using VapeCalculator.liteDB;
using VapeCalculator.Models;
using VapeCalculator.Validation;

namespace VapeCalculator
{
    public partial class VapeCalculator : Form
    {
        LiteDBRepo _db;
        LiteDBFlavourRepo _dbFlavours;

        public VapeCalculator()
        {
            InitializeComponent();

            _db = new LiteDBRepo();
            _dbFlavours = new LiteDBFlavourRepo();

            // Define the border style of the form to a dialog box.
            this.FormBorderStyle = FormBorderStyle.FixedDialog;

            // Set the MaximizeBox to false to remove the maximize box.
            this.MaximizeBox = false;

            // Set the start position of the form to the center of the screen.
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Create DB if doesn't exist
            _db.CreateDB();
            _dbFlavours.CreateDB();

            SetUpJuiceList();
            SetUpDropDowns();
        }

        #region "Form events"

        private void btnAdd_Click(object sender, EventArgs e)
        {
            JuiceProfile newJuice = new JuiceProfile();

            // Set up juice object.
            if (txtProfileName.Text == "")
            {
                MessageBox.Show("You have not specified a name.");
                return;
            }
            else
            {
                newJuice.Name = txtProfileName.Text;
            }

            // Do we have a juice to calculate?
            if (!CalculateJuice())
                return;            

            newJuice.JuiceAmount = decimal.Parse(txtJuiceAmount.Text);

            newJuice.FlavourOneName = drpFlavourOne.Text;
            newJuice.FlavourOnePercent = decimal.Parse(txtFirstFlavourPercent.Text);
            newJuice.FlavourTwoName = drpFlavourTwo.Text == "" ? "" : drpFlavourTwo.Text;
            newJuice.FlavourTwoPercent = txtSecondFlavourPercent.Text == "" ? 0 : decimal.Parse(txtSecondFlavourPercent.Text);
            newJuice.FlavourThreeName = drpFlavourThree.Text == "" ? "" : drpFlavourThree.Text;
            newJuice.FlavourThreePercent = txtThirdFlavourPercent.Text == "" ? 0 : decimal.Parse(txtThirdFlavourPercent.Text);
            newJuice.FlavourFourName = drpFlavourFour.Text == "" ? "" : drpFlavourFour.Text;
            newJuice.FlavourFourPercent = txtFourthFlavourPercent.Text == "" ? 0 : decimal.Parse(txtFourthFlavourPercent.Text);
            newJuice.FlavourFiveName = drpFlavourFive.Text == "" ? "" : drpFlavourFive.Text;
            newJuice.FlavourFivePercent = txtFifthFlavourPercent.Text == "" ? 0 : decimal.Parse(txtFifthFlavourPercent.Text);
            newJuice.FlavourSixName = drpFlavourSix.Text == "" ? "" : drpFlavourSix.Text;
            newJuice.FlavourSixPercent = txtSixthFlavourPercent.Text == "" ? 0 : decimal.Parse(txtSixthFlavourPercent.Text);

            newJuice.PGPercent = decimal.Parse(txtPGPercent.Text);
            newJuice.VGPercent = decimal.Parse(txtVGPercent.Text);
            newJuice.NicPercent = decimal.Parse(txtNicPercent.Text);
            newJuice.NicType = chkType.Checked == true ? "VG" : "PG";

            // Have we selected an existing juice?
            if (GetSelectedJuice().ToString() != "")
            {
                // Set the existing juice Id
                newJuice.Id = int.Parse(GetSelectedJuice());
                // Update
                _db.UpdateJuiceProfile(newJuice);
            }
            else
            {
                // Do we even have a juice name?
                if (newJuice.Name != "" && newJuice.Name != null)
                {
                    if (_db.InsertJuiceProfile(newJuice))
                    {
                        txtProfileName.Text = "";
                    }
                }
            }

            // Reload the list.
            loadProfileList();
        }

        // Delete a juice.
        private void btnDelete_Click(object sender, EventArgs e)
        {
            // Get the juice to remove
            var selectedProfile = GetSelectedJuice();
            
            // Have we even selected one?
            if (selectedProfile != null && selectedProfile != "")
            {
                var profileId = GetSelectedJuice();

                _db.RemoveProfile(int.Parse(profileId));
            }
            // is this the last juice if so refresh form
            if (_db.GetAllProfiles().Count() < 1)
            {
                btnNewJuice_Click(null, null);
            }
            else
            {
                loadProfileList();
            }
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            // Calculate our values
            CalculateJuice();
        }

        private void listProfiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Get the selected juice
            var selectedProfile = listProfiles.GetItemText(listProfiles.SelectedIndex);

            JuiceProfile profile = new JuiceProfile();
            ModelFactory factory = new ModelFactory();
            JuiceCalculation calc = new JuiceCalculation();

            // Make sure we actually have one in the list
            if (selectedProfile != null && selectedProfile != "" && selectedProfile != "-1")
            {
                profile = _db.GetProfileById(int.Parse(GetSelectedJuice()));

                // Reinitialise the dropdown (fix for weird selection issue)
                SetUpDropDowns();

                SetInputBoxValues(profile);

                var values = factory.Parse(profile);

                values.FlavourOneWeight = decimal.Parse(drpFlavourOne.SelectedValue.ToString());
                values.FlavourTwoWeight = drpFlavourTwo.SelectedValue == null ? 0 : decimal.Parse(drpFlavourTwo.SelectedValue.ToString());
                values.FlavourThreeWeight = drpFlavourThree.SelectedValue == null ? 0 : decimal.Parse(drpFlavourThree.SelectedValue.ToString());
                values.FlavorFourWeight = drpFlavourFour.SelectedValue == null ? 0 : decimal.Parse(drpFlavourFour.SelectedValue.ToString());
                values.FlavourFiveWeight = drpFlavourFive.SelectedValue == null ? 0 : decimal.Parse(drpFlavourFive.SelectedValue.ToString());
                values.FlavourSixWeight = drpFlavourSix.SelectedValue == null ? 0 : decimal.Parse(drpFlavourSix.SelectedValue.ToString());


                InputCalculationLabels(calc.CalculateAmount(values));
            }
        }

        private void btnNewJuice_Click(object sender, EventArgs e)
        {
            // Clear the controls
            this.Controls.Clear();

            // Reinitialize the form
            this.InitializeComponent();

            // Reload the form
            Form1_Load(this, null);
        }
        
        private void btnViewFlavours_Click(object sender, EventArgs e)
        {
            // Load the flavours form
            var viewFlavours = new ViewFlavoursForm();
            viewFlavours.FormClosed += new FormClosedEventHandler(ViewFlavoursFormClosed);
            viewFlavours.Show();
        }

        void ViewFlavoursFormClosed(object sender, FormClosedEventArgs e)
        {
            btnNewJuice_Click(this, null);
        }
        #endregion   

        #region "Data Loading"        

        // Load the list of juices
        private void loadProfileList()
        {
            listProfiles.DataSource = _db.GetAllProfiles().ToList();
            listProfiles.DisplayMember = "Name";
            listProfiles.ValueMember = "Id";
        }

        private void LoadDropDowns()
        {
            // Set up the drop downs, have to get data every time as they all bound to another otherwise

            drpFlavourOne.DataSource = _dbFlavours.GetAllFlavourProfiles().ToList();
            drpFlavourOne.DisplayMember = "FlavourName";
            drpFlavourOne.ValueMember = "Weight";

            drpFlavourTwo.DataSource = _dbFlavours.GetAllFlavourProfiles().ToList();
            drpFlavourTwo.DisplayMember = "FlavourName";
            drpFlavourTwo.ValueMember = "Weight";

            drpFlavourThree.DataSource = _dbFlavours.GetAllFlavourProfiles().ToList();
            drpFlavourThree.DisplayMember = "FlavourName";
            drpFlavourThree.ValueMember = "Weight";

            drpFlavourFour.DataSource = _dbFlavours.GetAllFlavourProfiles().ToList();
            drpFlavourFour.DisplayMember = "FlavourName";
            drpFlavourFour.ValueMember = "Weight";

            drpFlavourFive.DataSource = _dbFlavours.GetAllFlavourProfiles().ToList();
            drpFlavourFive.DisplayMember = "FlavourName";
            drpFlavourFive.ValueMember = "Weight";

            drpFlavourSix.DataSource = _dbFlavours.GetAllFlavourProfiles().ToList();
            drpFlavourSix.DisplayMember = "FlavourName";
            drpFlavourSix.ValueMember = "Weight";

        }
        #endregion

        #region "Set up controls"

        // Setup labels for calculation
        private void InputCalculationLabels(CalculationModel calulations)
        {
            lblFlavourOneMG.Text = calulations.FlavourOne.ToString();
            lblFlavourTwoMG.Text = calulations.FlavourTwo.ToString();
            lblFlavourThreeMG.Text = calulations.FlavourThree.ToString();
            lblFlavourFourMG.Text = calulations.FlavourFour.ToString();
            lblFlavourFiveMG.Text = calulations.FlavourFive.ToString();
            lblFlavourSixMG.Text = calulations.FlavourSix.ToString();
            lblPGMG.Text = calulations.PG.ToString();
            lblVGMG.Text = calulations.VG.ToString();
            lblNicMG.Text = calulations.Nic.ToString();
            lblTotal.Text = calulations.TotalWeight.ToString();
        }

        // Set up the list box of juices
        private void SetUpJuiceList()
        {
            // Default to nothing.
            listProfiles.SelectedIndexChanged -= listProfiles_SelectedIndexChanged;

            // Load all juices.
            loadProfileList();

            // Default to nothing.
            listProfiles.SelectedIndexChanged += listProfiles_SelectedIndexChanged;
            listProfiles.SelectedIndex = -1;
        }

        // Set up the dropdowns
        private void SetUpDropDowns()
        {
            LoadDropDowns();
            drpFlavourOne.SelectedIndex = -1;
            drpFlavourTwo.SelectedIndex = -1;
            drpFlavourThree.SelectedIndex = -1;
            drpFlavourFour.SelectedIndex = -1;
            drpFlavourFive.SelectedIndex = -1;
            drpFlavourSix.SelectedIndex = -1;
        }

        // On juice selection set values
        private void SetInputBoxValues(JuiceProfile loadedProfile)
        {
            txtProfileName.Text = loadedProfile.Name;
            txtJuiceAmount.Text = loadedProfile.JuiceAmount.ToString();

            drpFlavourOne.SelectedIndex = drpFlavourOne.FindStringExact(loadedProfile.FlavourOneName);
            drpFlavourTwo.SelectedIndex = drpFlavourTwo.FindStringExact(loadedProfile.FlavourTwoName);
            drpFlavourThree.SelectedIndex = drpFlavourThree.FindStringExact(loadedProfile.FlavourThreeName);
            drpFlavourFour.SelectedIndex = drpFlavourFour.FindStringExact(loadedProfile.FlavourFourName);
            drpFlavourFive.SelectedIndex = drpFlavourFive.FindStringExact(loadedProfile.FlavourFiveName);
            drpFlavourSix.SelectedIndex = drpFlavourSix.FindStringExact(loadedProfile.FlavourSixName);

            txtFirstFlavourPercent.Text = loadedProfile.FlavourOnePercent.ToString() == "0" ? "": loadedProfile.FlavourOnePercent.ToString();
            txtSecondFlavourPercent.Text = loadedProfile.FlavourTwoPercent.ToString() == "0" ? "" : loadedProfile.FlavourTwoPercent.ToString();
            txtThirdFlavourPercent.Text = loadedProfile.FlavourThreePercent.ToString() == "0" ? "" : loadedProfile.FlavourThreePercent.ToString();
            txtFourthFlavourPercent.Text = loadedProfile.FlavourFourPercent.ToString() == "0" ? "" : loadedProfile.FlavourFourPercent.ToString();
            txtFifthFlavourPercent.Text = loadedProfile.FlavourFivePercent.ToString() == "0" ? "" : loadedProfile.FlavourFivePercent.ToString();
            txtSixthFlavourPercent.Text = loadedProfile.FlavourSixPercent.ToString() == "0" ? "" : loadedProfile.FlavourSixPercent.ToString();

            txtPGPercent.Text = loadedProfile.PGPercent.ToString();
            txtVGPercent.Text = loadedProfile.VGPercent.ToString();
            txtNicPercent.Text = loadedProfile.NicPercent.ToString();
            chkType.Checked = loadedProfile.NicType == "PG" ? chkType.Checked = false : chkType.Checked = true;
        }

        // Get the currently selected item in the juice list.
        private string GetSelectedJuice()
        {
            return listProfiles.GetItemText(listProfiles.SelectedValue);
        }
        #endregion

        #region "Calculation"

        private bool CalculateJuice()
        {
            JuiceCalculation calc = new JuiceCalculation();

            // Set up object for calculation
            CalculationValuesModel newJuice = new CalculationValuesModel();

            newJuice.JuiceAmount = txtJuiceAmount.Text == "" ? -1 : int.Parse(txtJuiceAmount.Text);

            newJuice.FlavourOnePercent = txtFirstFlavourPercent.Text == "" ? -1 : decimal.Parse(txtFirstFlavourPercent.Text);
            newJuice.FlavourOneWeight = drpFlavourOne.SelectedValue == null ? -1 : decimal.Parse(drpFlavourOne.SelectedValue.ToString());

            newJuice.FlavourTwoPercent = txtSecondFlavourPercent.Text == "" ? 0 : decimal.Parse(txtSecondFlavourPercent.Text);
            newJuice.FlavourTwoWeight = drpFlavourTwo.SelectedValue == null ? 0 : decimal.Parse(drpFlavourTwo.SelectedValue.ToString());

            newJuice.FlavourThreePercent = txtThirdFlavourPercent.Text == "" ? 0 : decimal.Parse(txtThirdFlavourPercent.Text);
            newJuice.FlavourThreeWeight = drpFlavourThree.SelectedValue == null ? 0 : decimal.Parse(drpFlavourThree.SelectedValue.ToString());

            newJuice.FlavourFourPercent = txtFourthFlavourPercent.Text == "" ? 0 : decimal.Parse(txtFourthFlavourPercent.Text);
            newJuice.FlavorFourWeight = drpFlavourFour.SelectedValue == null ? 0 : decimal.Parse(drpFlavourFour.SelectedValue.ToString());

            newJuice.FlavourFivePercent = txtFifthFlavourPercent.Text == "" ? 0 : decimal.Parse(txtFifthFlavourPercent.Text);
            newJuice.FlavourFiveWeight = drpFlavourFive.SelectedValue == null ? 0 : decimal.Parse(drpFlavourFive.SelectedValue.ToString());

            newJuice.FlavourSixPercent = txtSixthFlavourPercent.Text == "" ? 0 : decimal.Parse(txtSixthFlavourPercent.Text);
            newJuice.FlavourSixWeight = drpFlavourSix.SelectedValue == null ? 0 : decimal.Parse(drpFlavourSix.SelectedValue.ToString());

            newJuice.VGPercent = txtVGPercent.Text == "" ? -1 : int.Parse(txtVGPercent.Text);
            newJuice.PGPercent = txtPGPercent.Text == "" ? -1 : int.Parse(txtPGPercent.Text);
            newJuice.NicPercent = txtNicPercent.Text == "" ? -1 : int.Parse(txtNicPercent.Text);
            newJuice.NicType = chkType.Checked == true ? "VG" : "PG";

            ValidateControls validate = new ValidateControls();

            // Have we passed validation?
            if (validate.ValidateNewCalculation(newJuice).Passed)
            {
                InputCalculationLabels(calc.CalculateAmount(newJuice));
                return true;
            }                
            else
            {
                MessageBox.Show(validate.ValidateNewCalculation(newJuice).ErrorMessage);
                return false;
            }
                
        }

        #endregion
    }
}
