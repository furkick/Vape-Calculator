using VapeCalculator.Models;

namespace VapeCalculator.Validation
{
    public class ValidateControls
    {
        public ValidationResult ValidateNewCalculation(CalculationValuesModel data)
        {
            ValidationResult validateModel = new ValidationResult();

            if (data.JuiceAmount == -1)
            {
                validateModel.ErrorMessage = "You need to enter a juice amount.";
                validateModel.Passed = false;
                return validateModel;
            }                        
            if (data.FlavourOneWeight == -1)
            {
                validateModel.ErrorMessage = "You need to select at least one flavour.";
                validateModel.Passed = false;
                return validateModel;
            }
            if (data.FlavourOnePercent == -1)
            {
                validateModel.ErrorMessage = "You need to enter first flavour percent.";
                validateModel.Passed = false;
                return validateModel;
            }
            if (data.FlavourTwoWeight != 0 && data.FlavourTwoPercent == 0)
            {
                validateModel.ErrorMessage = "You need to enter second flavour percent.";
                validateModel.Passed = false;
                return validateModel;
            }
            if (data.FlavourTwoPercent != 0 && data.FlavourTwoWeight == 0)
            {
                validateModel.ErrorMessage = "You haven't selected a second flavour.";
                validateModel.Passed = false;
                return validateModel;
            }

            if (data.FlavourThreeWeight != 0 && data.FlavourThreePercent == 0)
            {
                validateModel.ErrorMessage = "You need to enter third flavour percent.";
                validateModel.Passed = false;
                return validateModel;
            }
            if (data.FlavourThreePercent != 0 && data.FlavourThreeWeight == 0)
            {
                validateModel.ErrorMessage = "You haven't selected a third flavour.";
                validateModel.Passed = false;
                return validateModel;
            }

            if (data.FlavorFourWeight != 0 && data.FlavourFourPercent == 0)
            {
                validateModel.ErrorMessage = "You need to enter fourth flavour percent.";
                validateModel.Passed = false;
                return validateModel;
            }
            if (data.FlavourFourPercent != 0 && data.FlavorFourWeight == 0)
            {
                validateModel.ErrorMessage = "You haven't selected a third flavour.";
                validateModel.Passed = false;
                return validateModel;
            }            
            if (data.VGPercent == -1)
            {
                validateModel.ErrorMessage = "You need to enter a VG value.";
                validateModel.Passed = false;
                return validateModel;
            }
            if (data.PGPercent == -1)
            {
                validateModel.ErrorMessage = "You need to enter a PG value.";
                validateModel.Passed = false;
                return validateModel;
            }
            if (data.NicPercent == -1)
            {
                validateModel.ErrorMessage = "You need to enter a nicotine value. 0 if nic free";
                validateModel.Passed = false;
                return validateModel;
            }
            if((data.PGPercent + data.VGPercent) != 100)
            {
                validateModel.ErrorMessage = "PG and VG percent must equal 100, not " + (data.PGPercent + data.VGPercent);
                validateModel.Passed = false;
                return validateModel;
            }
            else
            {
                validateModel.Passed = true;
                return validateModel;
            }
        }
    }
}
