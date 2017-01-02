using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VapeCalculator.Models;

namespace VapeCalculator.Validation
{
    public class ValidateFlavour
    {
        public ValidationResult ValidateNewFlavour(FlavourModel data)
        {
            ValidationResult validateModel = new ValidationResult();

            if (data.Id == -2)
            {
                validateModel.ErrorMessage = "You haven't selected a juice.";
                validateModel.Passed = false;
                return validateModel;
            }
            if (data.FlavourName == "")
            {
                validateModel.ErrorMessage = "You need to enter a juice name.";
                validateModel.Passed = false;
                return validateModel;
            }
            if (data.Weight == -1)
            {
                validateModel.ErrorMessage = "You need to enter a weight.";
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
